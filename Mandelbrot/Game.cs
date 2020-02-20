using Base;
using Dear_ImGui_Sample;
using ImGuiNET;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;

namespace Mandelbrot
{
	internal class Game : GameWindow
	{
		private Shader shader;
		private const double smoothing = 0.9;
		private double frameTime;
		private ImGuiController ImGuiController;

		public Game(int width = 1280, int height = 720, string title = "Game") : base(width, height, GraphicsMode.Default, title)
		{
		}

		protected override void OnResize(EventArgs e)
		{
			GL.Viewport(0, 0, Width, Height);

			ImGuiController.WindowResized(Width, Height);
		}

		private Texture1D texture;

		protected override unsafe void OnLoad(EventArgs e)
		{
			ImGuiController = new ImGuiController(Width, Height);

			shader = new Shader("Assets/basic.vert", "Assets/basic.frag");

			texture = new Texture1D("Assets/gradient.png");

			GL.GenBuffers(1, out int quad);
			GL.BindBuffer(BufferTarget.ArrayBuffer, quad);

			Vector4[] vertices =
			{
				new Vector4(-1f, 1f, 0f, 1f),
				new Vector4(1f, 1f, 1f, 1f),
				new Vector4(1f, -1f, 1f, 0f),
				new Vector4(-1f, -1f, 0f, 0f)
			};

			GL.BufferStorage(BufferTarget.ArrayBuffer, 4 * sizeof(Vector4), vertices, BufferStorageFlags.None);

			GL.EnableVertexAttribArray(0);
			GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, sizeof(Vector4), IntPtr.Zero);

			GL.EnableVertexAttribArray(1);
			GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, sizeof(Vector4), sizeof(Vector2));
		}

		private int timer;
		private int max_iterations;

		private float gameTime;

		protected override void OnUpdateFrame(FrameEventArgs e)
		{
			gameTime += (float)e.Time;

			if (++timer > 10)
			{
				if (++max_iterations > 100) max_iterations = 0;

				timer = 0;
			}

			if (!Focused) return;

			var state = Keyboard.GetState();
			if (state.IsKeyDown(Key.KeypadPlus)) scale *= 0.99f;
			if (state.IsKeyDown(Key.KeypadMinus)) scale *= 1.01f;

			Vector2 dirX = new Vector2(0.01f * scale, 0f);

			float s = MathF.Sin(rotation);
			float c = MathF.Cos(rotation);

			dirX = new Vector2(dirX.X * c, dirX.X * s);

			if (state.IsKeyDown(Key.A)) position -= dirX;
			if (state.IsKeyDown(Key.D)) position += dirX;

			dirX = new Vector2(-dirX.Y, dirX.X);
			if (state.IsKeyDown(Key.W)) position += dirX;
			if (state.IsKeyDown(Key.S)) position -= dirX;

			if (state.IsKeyDown(Key.Q)) rotation -= 0.01f;
			if (state.IsKeyDown(Key.E)) rotation += 0.01f;
		}

		private float scale = 4f;
		private Vector2 position;
		private float rotation;

		private float radius = 20f;
		private float repeat = 10f;
		private Vector2 pivot = Vector2.Zero;

		protected override void OnRenderFrame(FrameEventArgs e)
		{
			frameTime = frameTime * smoothing + e.Time * (1.0 - smoothing);

			GL.ClearColor(new Color4(40, 40, 40, 255));
			GL.Clear(ClearBufferMask.ColorBufferBit);

			float aspectRatio = (float)Width / Height;
			float scaleX = scale;
			float scaleY = scale;
			if (aspectRatio > 1f) scaleY /= aspectRatio;
			else scaleX *= aspectRatio;

			texture.Bind();
			shader.Bind();
			shader.UploadUniformMat4("u_ViewProjection", Matrix4.Identity);
			shader.UploadUniformInt("u_MaxIterations", 255);
			shader.UploadUniformFloat4("u_Area", new Vector4(position.X, position.Y, scaleX, scaleY));
			shader.UploadUniformFloat("u_Angle", rotation);
			shader.UploadUniformFloat("u_Time", gameTime);

			shader.UploadUniformFloat("u_Radius", radius);
			shader.UploadUniformFloat("u_Repeat", repeat);
			shader.UploadUniformFloat2("u_Pivot", pivot);

			GL.DrawArrays(PrimitiveType.Quads, 0, 4);

			ImGuiController.Update(this, (float)e.Time);

			ImGui.Begin("Debug");
			ImGui.Text($"FPS: {1 / frameTime:N1}");
			ImGui.Text("Zoom: " + scale);

			ImGui.Separator();

			ImGui.SliderFloat("Radius", ref radius, 2f, 50f);
			ImGui.SliderFloat("Repeat", ref repeat, 0.1f, 20f);

			ImGui.SliderFloat2("Pivot", ref pivot, 0.1f, 20f);

			bool pressed = ImGui.Button("Reset");
			if (pressed)
			{
				radius = 20f;
				repeat = 10f;
				pivot = Vector2.Zero;

				position = Vector2.Zero;
				scale = 4f;
				rotation = 0f;
			}

			ImGui.End();

			ImGuiController.Render();

			SwapBuffers();
		}
	}
}