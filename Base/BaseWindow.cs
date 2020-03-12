using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Base
{
	public abstract class BaseWindow : GameWindow
	{
		public static BaseWindow Instance;

		internal static Version OpenGLVersion;
		internal static List<string> Extensions;

		protected LayerStack Layers;

		public BaseWindow(int width = 1280, int height = 720, string title = "Game") : base(width, height, GraphicsMode.Default, title)
		{
			Instance = this;

			GL.GetInteger(GetPName.MajorVersion, out int major);
			GL.GetInteger(GetPName.MinorVersion, out int minor);
			OpenGLVersion = new Version(major, minor);

			Extensions = GL.GetString(StringName.Extensions).Split(' ').ToList();

			Layers = new LayerStack();
		}

		private const double smoothing = 0.9;
		protected double frameTime;

		protected override void OnResize(EventArgs e)
		{
			GL.Viewport(0, 0, Width, Height);

			foreach (Layer layer in Layers) layer.OnWindowResize(Width, Height);
		}

		protected override void OnMouseMove(MouseMoveEventArgs e)
		{
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

		protected override void OnKeyDown(KeyboardKeyEventArgs e)
		{
			foreach (Layer layer in Layers.TrickleDown()) layer.OnKeyDown(e);
		}

		protected override void OnKeyUp(KeyboardKeyEventArgs e)
		{
			foreach (Layer layer in Layers.TrickleDown()) layer.OnKeyUp(e);
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
			GL.ClearColor(0.175f, 0.175f, 0.175f, 1f);
			GL.Clear(ClearBufferMask.ColorBufferBit);

			frameTime = frameTime * smoothing + e.Time * (1.0 - smoothing);

			Time.DeltaDrawTime = (float)e.Time;
			Time.TotalDrawTime += Time.DeltaDrawTime;

			(Layers.FirstOrDefault(x => x is ImGuiLayer) as ImGuiLayer)?.Begin();

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