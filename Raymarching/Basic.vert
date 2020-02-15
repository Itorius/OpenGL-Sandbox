﻿﻿#version 440 core

layout(location = 0) in vec3 a_Position;
layout(location = 1) in vec2 a_UV;

uniform mat4 u_ViewProjection;

out vec3 u_Pos;
out vec2 v_UV;

void main()
{
	v_UV = a_UV;
	
	u_Pos = a_Position;	
	gl_Position = u_ViewProjection * vec4(a_Position, 1.0);
}