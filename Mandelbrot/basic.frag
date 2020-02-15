﻿#version 440 core

#define product(a, b) vec2(a.x*b.x-a.y*b.y, a.x*b.y+a.y*b.x)
#define conjugate(a) vec2(a.x,-a.y)
#define divide(a, b) vec2(((a.x*b.x+a.y*b.y)/(b.x*b.x+b.y*b.y)),((a.y*b.x-a.x*b.y)/(b.x*b.x+b.y*b.y)))

layout(location = 0) out vec4 color;

in vec3 v_Position;

uniform int u_MaxIterations;

void main()
{
        vec2 z = vec2(0f, 0f);

        // Iterate z = z^2 + c until z moves more than 2 units
        // away from (0, 0), or we've iterated too many times.
        int iterations = 0;
        while (length(z) < 2.0 && iterations < u_MaxIterations)
        {
            z =product(z,z) + v_Position.xy;

            ++iterations;
        }

//	color=vec4((1.0/u_MaxIterations)*iterations,0.0,0.0,1.0);
	
        if (iterations == u_MaxIterations)
        {
            color=vec4(1.0,0.0,0.0,1.0);
        }
        else
        {
		    color=vec4(0);
        }
}