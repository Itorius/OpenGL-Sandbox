#version 440 core

const int MAX_LIGHTS = 16;
const float MAX_DISTANCE = 150.0;
const float EPSILON = 0.001;

layout(location = 0) out vec4 color;

in vec2 v_UV;

uniform vec4 u_Color;
uniform mat4 u_CameraToWorld;
uniform mat4 u_CameraInverseProjection;
uniform mat4 u_ModelMatrix;
uniform float u_Time;


uniform int u_LightCount;

struct Light{
	vec4 position;
	vec4 color;
};

uniform LightingBlock {
	Light u_Lights[MAX_LIGHTS];
};

struct Ray
{
	vec3 origin;
	vec3 direction;
};

Ray CreateRay(vec3 origin, vec3 direction) {
	Ray ray;
	ray.origin = origin;
	ray.direction = direction;
	return ray;
}

Ray CreateCameraRay(vec2 uv) {
	vec3 origin = (u_CameraToWorld * vec4(0.0, 0.0, 0.0, 1.0)).xyz;
	vec3 direction = (u_CameraInverseProjection * vec4(uv, 0.0, 1.0)).xyz;
	direction = (u_CameraToWorld * vec4(direction, 0.0)).xyz;
	direction = normalize(direction);
	return CreateRay(origin, direction);
}

vec3 mul(vec3 p, mat4 t)
{
	return (t * vec4(p, 1)).xyz;
}

float SphereDistance(vec3 position, vec3 center, float radius)
{
	return distance(position, center) - radius;
}

float BoxDistance(vec3 position, vec3 center, vec3 size)
{
	vec3 o = abs(position - center) - size;

	float ud = length(max(o, 0));
	float n = max(max(min(o.x, 0),min(o.y, 0)), min(o.z, 0));
	return ud + n;
}

float TorusDistance(vec3 position, vec3 center, float radiusMain, float ringRadius)
{
	vec2 q = vec2(length((position - center).xz) - radiusMain, position.y - center.y);
	return length(q) - ringRadius;
}

float PrismDistance(vec3 position, vec3 center, vec2 h)
{
	vec3 q = abs(position - center);
	return max(q.z - h.y, max(q.x * 0.866025 + position.y * 0.5, -position.y) - h.x * 0.5);
}

float CylinderDistance(vec3 position, vec3 center, vec2 h)
{
	vec2 d = abs(vec2(length((position).xz), position.y)) - h;
	return length(max(d, 0.0)) + max(min(d.x, 0.0), min(d.y, 0.0));
}

vec4 Blend(float dist1, float dist2, vec3 colA, vec3 colB, float factor)
{
	float h = clamp(0.5 + 0.5 * (dist2 - dist1) / factor, 0.0, 1.0);
	float blendDst = mix(dist2, dist1, h) - factor * h * (1.0 - h);
	vec3 blendCol = mix(colB, colA, h);
	return vec4(blendCol, blendDst);
}

vec4 Combine(float dstA, float dstB, vec3 colourA, vec3 colourB, int operation, float blendStrength)
{
	float dst = dstA;
	vec3 colour = colourA;

	if (operation == 0) {
		if (dstB < dstA) {
			dst = dstB;
			colour = colourB;
		}
	}
	// Blend
	else if (operation == 1) {
		vec4 blend = Blend(dstA,dstB,colourA,colourB, blendStrength);
		dst = blend.w;
		colour = blend.xyz;
	}
	// Cut
	else if (operation == 2) {
		// max(a,-b)
		if (-dstB > dst) {
			dst = -dstB;
			colour = colourB;
		}
	}
	// Mask
	else if (operation == 3) {
		// max(a,b)
		if (dstB > dst) {
			dst = dstB;
			colour = colourB;
		}
	}

	return vec4(colour,dst);
}

float Mandelbulb(in vec3 p, out vec4 color)
{
	vec3 w = p;
	float m = dot(w, w);

	vec4 trap = vec4(abs(w), m);
	float dz = 1.0;

	for(int i = 0; i < 4; i++)
	{
		float m2 = m * m;
		float m4 = m2 * m2;
		dz = 8.0 * sqrt(m4 * m2 * m) * dz + 1.0;

		float x = w.x; float x2 = x * x; float x4 = x2 * x2;
		float y = w.y; float y2 = y * y; float y4 = y2 * y2;
		float z = w.z; float z2 = z * z; float z4 = z2 * z2;

		float k3 = x2 + z2;
		float k2 = inversesqrt(k3 * k3 * k3 * k3 * k3 * k3 * k3);
		float k1 = x4 + y4 + z4 - 6.0 * y2 * z2 - 6.0 * x2 * y2 + 2.0 *  z2 * x2;
		float k4 = x2 - y2 + z2;

		w.x = p.x +  64.0 * x* y * z * (x2 - z2) * k4 * (x4 - 6.0 * x2 * z2 + z4) * k1 * k2;
		w.y = p.y + -16.0 * y2 * k3 * k4 * k4 + k1 * k1;
		w.z = p.z + -8.0 * y * k4 * (x4 * x4 - 28.0 * x4 * x2 * z2 + 70.0 * x4 * z4 - 28.0 * x2 * z2 * z4 + z4 * z4) * k1 * k2;
		
		trap = min(trap, vec4(abs(w), m));

		m = dot(w, w);
		if(m > 256.0) break;
	}

	color = vec4(m, trap.yzw);

	return 0.25 * log(m) * sqrt(m) / dz;
}

vec4 SceneInfo(vec3 position)
{
	float plane = position.y;

	float globalDst = MAX_DISTANCE;
	vec3 globalColour = vec3(1.0);
	
	vec4 color;
	float localDst = Mandelbulb(position, color);
	
	vec3 localColour = vec3(1.0,0.0,0.0);

	globalColour = localColour.xyz;
	globalDst = localDst;

	return vec4(globalColour, globalDst);
}

vec3 GetNormal(vec3 p)
{
	float h = 0.0001;
	vec2 k = vec2(1.0, -1.0);
	vec3 n = normalize(k.xyy * SceneInfo(p + k.xyy * h).w + k.yyx * SceneInfo(p + k.yyx * h).w + k.yxy * SceneInfo(p + k.yxy * h).w + k.xxx * SceneInfo(p + k.xxx * h).w);
	return n;
}

float RayMarch(vec3 origin, vec3 direction)
{
	float rayDst = 0.0;

	int iterations = 0;
	
	while (rayDst < MAX_DISTANCE && iterations < 128)
	{
		iterations++;		
		
		vec4 scene = SceneInfo(origin);
		float dst = scene.w;

		origin += direction * dst;
		rayDst += dst;

		if (dst <= EPSILON) {
			break;
		}
	}

	return rayDst;
}

uniform float u_Test;

vec3 calcNormal( in vec3 pos )
{
	vec2 e = vec2(1.0,-1.0)*0.5773*0.0005;
	return normalize( e.xyy*SceneInfo( pos + e.xyy ).w +
	e.yyx*SceneInfo( pos + e.yyx ).w +
	e.yxy*SceneInfo( pos + e.yxy ).w +
	e.xxx*SceneInfo( pos + e.xxx ).w );
}

float calcAO( in vec3 pos, in vec3 nor )
{
	float occ = 0.0;
	float sca = 1.0;
	for( int i=0; i<5; i++ )
	{
		float h = 0.001 + 0.15*float(i)/4.0;
		float d = SceneInfo( pos + h*nor ).w;
		occ += (h-d)*sca;
		sca *= 0.95;
	}
	return clamp( 1.0 - 1.5*occ, 0.0, 1.0 );
}

float softshadow( in vec3 ro, in vec3 rd, in float mint, in float tmax, int technique )
{
	float res = 1.0;
	float t = mint;
	float ph = 1e10; // big, such that y = 0 on the first iteration

	for( int i=0; i<32; i++ )
	{
		float h = SceneInfo( ro + rd*t ).w;

		// traditional technique
		if( technique==0 )
		{
			res = min( res, u_Test*h/t );
		}
		// improved technique
		else
		{
			// use this if you are getting artifact on the first iteration, or unroll the
			// first iteration out of the loop
//			float y = (i==0) ? 0.0 : h*h/(2.0*ph); 

			float y = h*h/(2.0*ph);
			float d = sqrt(h*h-y*y);
			res = min( res, u_Test*d/max(0.0,t-y) );
			ph = h;
		}

		t += h;

		if( res<EPSILON || t>tmax ) break;

	}
	return clamp( res, 0.0, 1.0 );
}



void main()
{
	Ray ray = CreateCameraRay(v_UV);

	float dst = RayMarch(ray.origin, ray.direction);

	if(dst < MAX_DISTANCE && dst > 0.0)
	{
		vec3 pointOnSurface = ray.origin + ray.direction * dst;

		vec3 normal = calcNormal(pointOnSurface - ray.direction * EPSILON);

		float brightness = 0.0;
		vec4 totalColor = vec4(1.0);
float mate = 0.3;
		
		for (int i = 0; i < u_LightCount; i++)
		{
			Light light = u_Lights[i];	
			
			if(light.position.w == 0.0) // directional
			{
				vec3 lightDir = normalize(light.position.xyz);

				float lighting = clamp(dot(normal, lightDir), 0.0, 1.0);

				vec3 shiftedPoint = pointOnSurface + normal * EPSILON * 5;
				
				float d = RayMarch(shiftedPoint, lightDir);

				float shadow = softshadow(shiftedPoint, lightDir, 0.01, 10.0, 1);

				float ao = calcAO(shiftedPoint, normal);

				brightness += 1.0 * (lighting * shadow + ao * 0.3);
			}
			else if (light.position.w == 1.0) // point
			{
				vec3 lightDir = normalize(light.position.xyz - pointOnSurface);

				float lighting = clamp(dot(normal, lightDir), 0.0, 1.0);

				vec3 shiftedPoint = pointOnSurface + normal * EPSILON * 5;

				float d = RayMarch(shiftedPoint, lightDir);

				float shadow = softshadow(shiftedPoint, lightDir, 0.01, 30.0, 1);

				float ao = calcAO(shiftedPoint, normal);
				
				brightness += lighting * shadow * ao;
			}
		}

//		color = vec4(abs(normal), 1.0); // normal mapping

		vec3 col = u_Color.xyz;
		
		color = vec4(col * clamp(brightness, 0.0, 1.0), u_Color.w);
	}
}