#version 440 core

layout(location = 0) out vec4 color;

in vec2 v_Position;

uniform int u_MaxIterations;
uniform vec4 u_Area;
uniform float u_Angle;
uniform sampler1D texGradient;
uniform float u_Time;

vec2 product(vec2 a, vec2 b)
{
	return  vec2(a.x*b.x-a.y*b.y, a.x*b.y+a.y*b.x);
}

vec2 rotate(vec2 point, vec2 pivot, float angle)
{
	float s = sin(angle);
	float c = cos(angle);

	point -= pivot;
	point = vec2(point.x*c-point.y*s, point.x*s+point.y*c);
	point += pivot;

	return point;
}

uniform float u_Radius;
uniform vec2 u_Pivot;
uniform float u_Repeat;

void main()
{
	vec2 z, zPrev;
	vec2 uv = v_Position;
	uv = u_Area.xy + (uv - 0.5) * u_Area.zw;
	uv = rotate(uv, u_Area.xy, u_Angle);

	float radius = u_Radius;
	float radius2 = radius * radius;
	
	float iterations = 0.0;
	while (dot(z, zPrev) < radius2 && iterations < u_MaxIterations)
	{
		zPrev = rotate(z, u_Pivot, u_Time);
		z = product(z, z) + uv;

		iterations++;
	}

	if (iterations == u_MaxIterations) color = vec4(0);
	else
	{
		float dist = length(z);

		float i = (dist - radius) / (radius2 - radius);
		i = log2(log(dist) / log(radius));

		float angle = atan(z.x, z.y);
		
		float m = sqrt(iterations / u_MaxIterations);
		color = texture(texGradient, m * u_Repeat + u_Time * 0.25);
		
		color *= smoothstep(3.0, 0.0, i);
		color *= 1.0 + sin(angle * 2.0 + u_Time * 4.0) * 0.2;
		
	}
}