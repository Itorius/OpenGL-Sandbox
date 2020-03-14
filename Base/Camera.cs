using OpenTK;

namespace Raytracer
{
	public class Camera
	{
		private Base.Vector2 position;

		public Matrix4 View { get; private set; }
		public Matrix4 Projection { get; private set; }
		public Matrix4 ViewProjection { get; private set; }

		public Camera()
		{
			View = Matrix4.Identity;
			Projection = Matrix4.Identity;
			ViewProjection = Matrix4.Identity;
		}

		public void SetViewport(int width, int height)
		{
			Projection = Matrix4.CreateOrthographic(width, height, -1f, 1f);
			ViewProjection = View * Projection;
		}

		public void SetViewportOffCenter(float left, float right, float bottom, float top)
		{
			Projection = Matrix4.CreateOrthographicOffCenter(left, right, bottom, top, -1f, 1f);
			ViewProjection = View * Projection;
		}

		public void SetPosition(Base.Vector2 position)
		{
			this.position = position;

			View = Matrix4.CreateTranslation(position.X, position.Y, 0f);
			ViewProjection = View * Projection;
		}
	}
}