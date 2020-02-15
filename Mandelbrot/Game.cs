using Base;
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
		private OrthographicCameraController controller;

		public Game(int width = 1280, int height = 720, string title = "Game") : base(width, height, GraphicsMode.Default, title)
		{
		}

		protected override void OnResize(EventArgs e)
		{
			GL.Viewport(0, 0, Width, Height);
			controller.OnWindowResize();
		}

		protected override void OnMouseWheel(MouseWheelEventArgs e)
		{
			controller.OnMouseScroll(e);
		}

		protected override unsafe void OnLoad(EventArgs e)
		{
			shader = new Shader("basic.vert", "basic.frag");
			controller = new OrthographicCameraController(this) { MaxZoom = 0.01f };

			GL.GenBuffers(1, out int quad);
			GL.BindBuffer(BufferTarget.ArrayBuffer, quad);

			Vector2[] vertices =
			{
				new Vector2(-2f, 1.125f),
				new Vector2(1f, 1.125f),
				new Vector2(1f, -1.125f),
				new Vector2(-2f, -1.125f)
			};

			for (int i = 0; i < vertices.Length; i++)
			{
				vertices[i] *= 5f;
			}

			GL.BufferStorage(BufferTarget.ArrayBuffer, 4 * sizeof(Vector2), vertices, BufferStorageFlags.None);
			GL.EnableVertexAttribArray(0);
			GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, 0, IntPtr.Zero);
		}

		private int timer;
		private int max_iterations;

		protected override void OnUpdateFrame(FrameEventArgs e)
		{
			controller.Update((float)e.Time);

			if (++timer > 10)
			{
				if (++max_iterations > 50) max_iterations = 0;

				timer = 0;
			}
		}

		protected override void OnRenderFrame(FrameEventArgs e)
		{
			frameTime = frameTime * smoothing + e.Time * (1.0 - smoothing);

			GL.ClearColor(new Color4(40, 40, 40, 255));
			GL.Clear(ClearBufferMask.ColorBufferBit);

			shader.Bind();
			shader.UploadUniformMat4("u_ViewProjection", controller.Camera.ViewProjectionMatrix);
			shader.UploadUniformInt("u_MaxIterations", 500);

			GL.DrawArrays(PrimitiveType.Quads, 0, 4);

			SwapBuffers();
		}
	}
}