using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;

namespace Base
{
	public abstract class BaseWindow : GameWindow
	{
		protected readonly LayerStack Layers;

		public BaseWindow(int width = 1280, int height = 720, string title = "Game") : base(width, height, GraphicsMode.Default, title)
		{
			Layers = new LayerStack();
		}

		protected override void OnResize(EventArgs e)
		{
			GL.Viewport(0, 0, Width, Height);
			Renderer2D.Viewport = new Vector2(Width, Height);

			foreach (Layer layer in Layers) layer.OnWindowResize(Width, Height);
		}

		private Vector2 mouse;

		protected override void OnMouseMove(MouseMoveEventArgs e)
		{
			mouse = new Vector2(e.X, e.Y);

			foreach (Layer layer in Layers) layer.OnMouseMove(e);
		}

		protected override void OnMouseDown(MouseButtonEventArgs e)
		{
			foreach (Layer layer in Layers)
			{
				bool handled = layer.OnMouseDown(e);
				if (handled) break;
			}
		}

		protected override void OnMouseUp(MouseButtonEventArgs e)
		{
			foreach (Layer layer in Layers)
			{
				bool handled = layer.OnMouseUp(e);
				if (handled) break;
			}
		}

		protected override void OnMouseWheel(MouseWheelEventArgs e)
		{
			foreach (Layer layer in Layers)
			{
				bool handled = layer.OnMouseScroll(e);
				if (handled) break;
			}
		}

		protected override void OnKeyDown(KeyboardKeyEventArgs e)
		{
			foreach (Layer layer in Layers.TrickleDown())
			{
				if (layer.OnKeyDown(e)) break;
			}
		}

		protected override void OnKeyUp(KeyboardKeyEventArgs e)
		{
			foreach (Layer layer in Layers.TrickleDown())
			{
				if (layer.OnKeyUp(e)) break;
			}
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			foreach (Layer layer in Layers.TrickleDown()) layer.OnKeyPress(e);
		}

		protected override void OnUpdateFrame(FrameEventArgs e)
		{
			Time.DeltaUpdateTime = (float)e.Time;
			Time.TotalUpdateTime += Time.DeltaUpdateTime;

			foreach (Layer layer in Layers) layer.OnUpdate();
		}

		protected override void OnRenderFrame(FrameEventArgs e)
		{
			if (WindowState == WindowState.Minimized) return;

			GL.ClearColor(0.175f, 0.175f, 0.175f, 1f);
			GL.Clear(ClearBufferMask.ColorBufferBit);

			Time.DeltaDrawTime = (float)e.Time;
			Time.TotalDrawTime += Time.DeltaDrawTime;

			ImGuiLayer.Instance?.Begin();

			foreach (Layer layer in Layers) layer.OnGUI();

			foreach (Layer layer in Layers.BobUp()) layer.OnRender();

			SwapBuffers();
		}
	}

	public static class Time
	{
		public static float DeltaDrawTime;
		public static float TotalDrawTime;

		public static float DeltaUpdateTime;
		public static float TotalUpdateTime;
	}
}