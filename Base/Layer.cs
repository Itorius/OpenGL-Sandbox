using OpenTK;
using OpenTK.Input;

namespace Base
{
	public class Layer
	{
		private string debugName;

		public Layer(string debugName = "Layer")
		{
			this.debugName = debugName;
		}

		public virtual void OnAttach()
		{
		}

		public virtual void OnDetach()
		{
		}

		public virtual void OnUpdate()
		{
		}

		public virtual void OnRender()
		{
		}

		public virtual void OnGUI()
		{
		}

		public virtual void OnWindowClose()
		{
		}

		public virtual void OnWindowResize(int width, int height)
		{
		}

		public virtual bool OnMouseMove(MouseMoveEventArgs args) => false;

		public virtual bool OnMouseScroll(MouseWheelEventArgs args) => false;

		public virtual bool OnMouseDown(MouseButtonEventArgs args) => false;

		public virtual bool OnMouseUp(MouseButtonEventArgs args) => false;

		public virtual bool OnKeyDown(KeyboardKeyEventArgs args) => false;

		public virtual bool OnKeyUp(KeyboardKeyEventArgs args) => false;

		public virtual bool OnKeyPress(KeyPressEventArgs args) => false;

		public string GetDebugName() => debugName;
	}
}