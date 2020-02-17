﻿#version 440 core

layout(location = 0) in vec2 a_Position;
layout(location = 1) in vec2 a_UV;

uniform mat4 u_ViewProjection;

out vec2 v_Position;

void main()
{
	v_Position = a_UV;
	gl_Position = u_ViewProjection * vec4(a_Position, 0.0, 1.0);
}