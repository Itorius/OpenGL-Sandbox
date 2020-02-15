﻿#version 440 core

const float  EPSILON = 0.001;

layout(location = 0) out vec4 color;

uniform vec4 u_Color;

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

uniform mat4 _CameraToWorld;
uniform mat4 _CameraInverseProjection;

Ray CreateCameraRay(vec2 uv) {
    vec3 origin = (_CameraToWorld*vec4(0.0,0.0,0.0,1.0)).xyz;
    vec3 direction = (_CameraInverseProjection* vec4(uv,0.0,1.0)).xyz;
    direction = (_CameraToWorld* vec4(direction,0.0)).xyz;
    direction = normalize(direction);
    return CreateRay(origin,direction);
}

const float maxDst = 150.0;

float SphereDistance(vec3 eye, vec3 centre, float radius) {
    return distance(eye, centre) - radius;
}

vec3 opTx( in vec3 p, in mat4 t)
{
    return  (t * vec4(p,1) ).xyz;
}

float CubeDistance(vec3 eye, vec3 centre, vec3 size) {

    vec3 p =eye-centre;

    
    
    vec3 o = abs(p) -size;

    float ud = length(max(o,0));
    float n = max(max(min(o.x,0),min(o.y,0)), min(o.z,0));
    return ud+n;
}

float TorusDistance(vec3 eye, vec3 centre, float r1, float r2)
{
    vec2 q = vec2(length((eye-centre).xz)-r1,eye.y-centre.y);
    return length(q)-r2;
}

float PrismDistance(vec3 eye, vec3 centre, vec2 h) {
    vec3 q = abs(eye-centre);
    return max(q.z-h.y,max(q.x*0.866025+eye.y*0.5,-eye.y)-h.x*0.5);
}


float CylinderDistance(vec3 eye, vec3 centre, vec2 h) {
    vec2 d = abs(vec2(length((eye).xz), eye.y)) - h;
    return length(max(d,0.0)) + max(min(d.x,0),min(d. y,0));
}

vec4 Blend( float a, float b, vec3 colA, vec3 colB, float k )
{
    float h = clamp( 0.5+0.5*(b-a)/k, 0.0, 1.0 );
    float blendDst = mix( b, a, h ) - k*h*(1.0-h);
    vec3 blendCol = mix(colB,colA,h);
    return vec4(blendCol, blendDst);
}

vec4 Combine(float dstA, float dstB, vec3 colourA, vec3 colourB, int operation, float blendStrength) {
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

uniform mat4 modelMatrix;

mat3 rotateY(float angle) {
    float c = cos(angle), s = sin(angle);
    return mat3(c, 0, s, 0, 1, 0, -s, 0, c);
}



vec4 SceneInfo(vec3 eye) {
    float globalDst = maxDst;
    vec3 globalColour = vec3(1.0);
    eye = opTx(eye, modelMatrix);
    
    vec3 origin = vec3(0);
    vec3 size = vec3(1.0,2.0,1.0);


    float localDst = CubeDistance(eye, origin, size);
    localDst = Combine(localDst, TorusDistance(eye, vec3(0.0),1.2,  0.3 ), vec3(0.0),vec3(0.0), 2, 0.5).w;
    
    vec3 localColour = vec3(1.0,0.0,0.0);

    globalColour = localColour.xyz;
    globalDst = localDst;

    return vec4(globalColour, globalDst);
}

vec3 EstimateNormal(vec3 p) {
        float pDist = SceneInfo(p).w;
        return normalize(vec3(
        SceneInfo(vec3(p.x + EPSILON, p.y, p.z)).w - pDist,
        SceneInfo(vec3(p.x, p.y + EPSILON, p.z)).w - pDist,
        SceneInfo(vec3(p.x, p.y, p.z  + EPSILON)).w - pDist
        ));
}

vec3 nor( vec3 pos, float prec )
{
    vec2 e = vec2( prec, 0. );
    vec3 n = vec3(
    SceneInfo(pos+e.xyy).w - SceneInfo(pos-e.xyy).w,
    SceneInfo(pos+e.yxy).w - SceneInfo(pos-e.yxy).w,
    SceneInfo(pos+e.yyx).w - SceneInfo(pos-e.yyx).w );
    return normalize(n);
}

in vec2 v_UV;

float saturate(float value)
{
    return clamp(value,0.0,1.0);
}

//vec3 calcNormal( in vec3 pos )
//{
//    #if 0
//    vec2 e = vec2(1.0,-1.0)*0.5773*0.0005;
//    return normalize( e.xyy*SceneInfo( pos + e.xyy ).w +
//    e.yyx*SceneInfo( pos + e.yyx ).w +
//    e.yxy*SceneInfo( pos + e.yxy ).w +
//    e.xxx*SceneInfo( pos + e.xxx ).w );
//    #else
//    // inspired by klems - a way to prevent the compiler from inlining map() 4 times
//    vec3 n = vec3(0.0);
//    for( int i=0; i<4; i++ )
//    {
//        vec3 e = 0.5773*(2.0*vec3((((i+3)>>1)&1),((i>>1)&1),(i&1))-1.0);
//        n += e*SceneInfo(pos+0.00001*e).w;
//    }
//    return normalize(n);
//    #endif
//}

float march(vec3 ro, vec3 rd) {
    float t = 0., i = 0.;
    for(i=0.; i < 64; i++) {
        vec3 p = ro + t * rd;
        float dt = SceneInfo(p).w;
        t += dt;
        if(dt < 0.01) {
            return t-0.01;
        }
    }
    return 0.;
}

vec3 calcNormal(vec3 p) {
    float h = 0.0001;
    vec2 k = vec2(1,-1);
    vec3 n = normalize( k.xyy*SceneInfo( p + k.xyy*h ).w +
    k.yyx*SceneInfo( p + k.yyx*h ).w +
    k.yxy*SceneInfo( p + k.yxy*h ).w +
    k.xxx*SceneInfo( p + k.xxx*h ).w );
    return n;
}

void main()
{
    float rayDst = 0.0;


    double angle = tan((3.1415926 * 0.5 * 60.0) / 180.0);
    double y =v_UV.y* angle;
    double x =v_UV.x* (16.0/9.0) * angle;
    
    Ray ray = CreateCameraRay(vec2(x,y));
    
//    float d= march(ray.origin, ray.direction);
//    
//    if(d > EPSILON) {
//        vec3 p = ray.origin + d * ray.direction;
//        vec3 normal = calcNormal(p);
//      color=vec4(abs(normal), 1.0);
//    }
//else     color=vec4(0);
    
    while (rayDst < maxDst+EPSILON) {

        vec4 scene = SceneInfo(ray.origin);
        float dst = scene.w;

        if (dst <= EPSILON) {
            vec3 pointOnSurface = ray.origin + ray.direction * dst;

            vec3 normal =calcNormal(pointOnSurface - ray.direction * EPSILON*2);

//            vec3 normal = nor(pointOnSurface - ray.direction * EPSILON, 0.025);

//            vec3 normal = EstimateNormal(pointOnSurface - ray.direction * EPSILON);

            vec3 lightDir = normalize(vec3(0.0,0.0,10.0)-ray.origin);
            float lighting = saturate(dot(normal,lightDir));

            vec3 col = vec3(1.0,0.0,0.0);

            // Shadow
//            vec3 offsetPos = pointOnSurface + normal * shadowBias;
//            vec3 dirToLight = (positionLight)?normalize(_Light- offsetPos):-_Light;

//            ray.origin = offsetPos;
//            ray.direction = dirToLight;

//            float dstToLight = (positionLight)?distance(offsetPos,_Light):maxDst;
//            float shadow = CalculateShadow(ray, dstToLight);

            color = vec4(col * lighting, 1.0);
//            color = vec4(abs(normal),1.0);


            break;
        }

        ray.origin += ray.direction * dst;
        rayDst += dst;
    }
    
    
}