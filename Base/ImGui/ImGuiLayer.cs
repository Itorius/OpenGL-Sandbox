using Base.ImGui;
using ImGuiNET;
using OpenTK;
using OpenTK.Input;

namespace Base
{
	public class ImGuiLayer : Layer
	{
		internal static ImGuiLayer Instance;

		private ImGuiController ImGuiController;

		public ImGuiLayer()
		{
			Instance = this;
		}

		public override void OnAttach()
		{
			ImGuiController = new ImGuiController(1280, 720);
		}

		public override void OnDetach() => ImGuiNET.ImGui.DestroyContext();

		public override void OnWindowResize(int width, int height)
		{
			ImGuiController.WindowResized(width, height);
		}

		public override bool OnMouseMove(MouseMoveEventArgs args)
		{
			ImGuiIOPtr io = ImGuiNET.ImGui.GetIO();

			io.MousePos = new OpenTK.Vector2(args.X, args.Y);

			return false;
		}

		public override bool OnMouseScroll(MouseWheelEventArgs args)
		{
			ImGuiIOPtr io = ImGuiNET.ImGui.GetIO();

			if (!io.WantCaptureMouse) return false;

			io.MouseWheel = args.DeltaPrecise;

			return true;
		}

		public override bool OnMouseDown(MouseButtonEventArgs args)
		{
			ImGuiIOPtr io = ImGuiNET.ImGui.GetIO();

			if (!io.WantCaptureMouse) return false;

			io.MouseDown[0] = args.Button == MouseButton.Left;
			io.MouseDown[1] = args.Button == MouseButton.Right;
			io.MouseDown[2] = args.Button == MouseButton.Middle;

			return true;
		}

		public override bool OnMouseUp(MouseButtonEventArgs args)
		{
			ImGuiIOPtr io = ImGuiNET.ImGui.GetIO();

			if (!io.WantCaptureMouse) return false;

			switch (args.Button)
			{
				case MouseButton.Left:
					io.MouseDown[0] = false;
					break;
				case MouseButton.Right:
					io.MouseDown[1] = false;
					break;
				case MouseButton.Middle:
					io.MouseDown[2] = false;
					break;
			}

			return true;
		}

		public override bool OnKeyDown(KeyboardKeyEventArgs args)
		{
			ImGuiIOPtr io = ImGuiNET.ImGui.GetIO();

			if (!io.WantCaptureKeyboard) return false;

			io.KeysDown[(int)args.Key] = true;
			UpdateModifiers(args);
			return true;
		}

		public override bool OnKeyUp(KeyboardKeyEventArgs args)
		{
			ImGuiIOPtr io = ImGuiNET.ImGui.GetIO();

			if (!io.WantCaptureKeyboard) return false;

			io.KeysDown[(int)args.Key] = false;
			UpdateModifiers(args);

			return true;
		}

		public override bool OnKeyPress(KeyPressEventArgs args)
		{
			ImGuiIOPtr io = ImGuiNET.ImGui.GetIO();

			if (!io.WantCaptureKeyboard) return false;

			io.AddInputCharacter(args.KeyChar);

			return true;
		}

		private static void UpdateModifiers(KeyboardKeyEventArgs e)
		{
			ImGuiIOPtr io = ImGuiNET.ImGui.GetIO();

			io.KeyAlt = e.Alt;
			io.KeyCtrl = e.Control;
			io.KeyShift = e.Shift;
		}

		public override void OnRender()
		{
			ImGuiController.Render();
		}

		public void Begin()
		{
			ImGuiController.Update(Time.DeltaDrawTime);
		}
	}
}