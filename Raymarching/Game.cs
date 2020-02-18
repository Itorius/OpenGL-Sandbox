﻿using Base;
using Dear_ImGui_Sample;
using ImGuiNET;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;

namespace Raymarching
{
	internal class Game : GameWindow
	{
		private const double smoothing = 0.9;
		private float globalTime;
		private double frameTime;

		private Shader basicShader;
		private Matrix4 matrix;
		private ImGuiController ImGuiController;

		public Game(int width = 1280, int height = 720, string title = "Game") : base(width, height, GraphicsMode.Default, title)
		{
		}

		private int buffer;

		protected override unsafe void OnLoad(EventArgs e)
		{
			ImGuiController = new ImGuiController(Width, Height);

			basicShader = new Shader("Assets/Basic.vert", "Assets/Basic.frag");

			int index = GL.GetUniformBlockIndex(basicShader.ID, "LightingBlock");
			GL.UniformBlockBinding(basicShader.ID, index, 0);

			Light[] l =
			{
				new Light(new Vector4(0, 10, 0, 1))
			};

			GL.GenBuffers(1, out int lights);
			GL.BindBuffer(BufferTarget.UniformBuffer, lights);
			GL.BufferData(BufferTarget.UniformBuffer, 16 * sizeof(Light), l, BufferUsageHint.StaticDraw);
			GL.BindBuffer(BufferTarget.UniformBuffer, 0);

			GL.BindBufferRange(BufferRangeTarget.UniformBuffer, 0, lights, IntPtr.Zero, 16 * sizeof(Light));

			matrix = Matrix4.CreateOrthographicOffCenter(-1.6f, 1.6f, -0.9f, 0.9f, -1f, 1f);

			Vertex[] vertices =
			{
				new Vertex(new Vector3(-1.6f, -0.9f, 0f), new Vector2(-1f, -1f)),
				new Vertex(new Vector3(1.6f, -0.9f, 0f), new Vector2(1f, -1f)),
				new Vertex(new Vector3(1.6f, 0.9f, 0f), new Vector2(1f, 1f)),
				new Vertex(new Vector3(-1.6f, 0.9f, 0f), new Vector2(-1f, 1f))
			};

			GL.GenBuffers(1, out buffer);
			GL.BindBuffer(BufferTarget.ArrayBuffer, buffer);
			GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(Vertex), vertices, BufferUsageHint.StaticDraw);

			GL.EnableVertexAttribArray(0);
			GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, sizeof(Vertex), IntPtr.Zero);

			GL.EnableVertexAttribArray(1);
			GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, sizeof(Vertex), sizeof(Vector3));

			GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
		}

		protected override void OnResize(EventArgs e)
		{
			GL.Viewport(0, 0, Width, Height);

			ImGuiController.WindowResized(Width, Height);
		}

		protected override void OnUpdateFrame(FrameEventArgs e)
		{
			globalTime += (float)e.Time;
		}

		protected override void OnRenderFrame(FrameEventArgs e)
		{
			frameTime = frameTime * smoothing + e.Time * (1.0 - smoothing);

			GL.ClearColor(new Color4(40, 40, 40, 255));
			GL.Clear(ClearBufferMask.ColorBufferBit);

			basicShader.Bind();
			GL.BindBuffer(BufferTarget.ArrayBuffer, buffer);

			float ratio = (float)Width / Height;
			Matrix4 projection = Matrix4.CreatePerspectiveOffCenter(-ratio, ratio, -1f, 1f, 1.0f, 40.0f);

			const float radius = 10.0f;
			float camX = MathF.Sin(globalTime) * radius;
			float camZ = MathF.Cos(globalTime) * radius;

			Vector3 camera = new Vector3(1.5f, 1.5f, 1.5f);
			Matrix4 view = Matrix4.LookAt(camera, Vector3.Zero, Vector3.UnitY);

			basicShader.UploadUniformMat4("u_CameraToWorld", view.Inverted());
			basicShader.UploadUniformMat4("u_CameraInverseProjection", projection.Inverted());
			basicShader.UploadUniformMat4("u_ModelMatrix", Matrix4.Identity);
			basicShader.UploadUniformMat4("u_ViewProjection", matrix);
			basicShader.UploadUniformFloat("u_Time", globalTime);

			basicShader.UploadUniformFloat4("u_Color", Color4.CornflowerBlue);

			GL.DrawArrays(PrimitiveType.Quads, 0, 4);

			basicShader.Unbind();
			GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

			ImGuiController.Update(this, (float)e.Time);

			ImGui.Begin("Debug");
			ImGui.Text($"FPS: {1 / frameTime:N1}");
			ImGui.End();

			ImGuiController.Render();

			SwapBuffers();
		}
	}
}