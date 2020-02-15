using OpenTK;
using OpenTK.Input;
using System;

namespace Base
{
	public class OrthographicCameraController
	{
		public OrthographicCamera Camera { get; }

		private float CameraTranslationSpeed = 2.5f;
		private GameWindow app;

		private float aspectRatio;
		private float zoom = 1f;

		private Vector2 position;

		public OrthographicCameraController(GameWindow app)
		{
			this.app = app;
			aspectRatio = (float)app.Width / app.Height;

			Camera = new OrthographicCamera(-aspectRatio * zoom, aspectRatio * zoom, -zoom, zoom);
		}

		public void Update(float deltaTime)
		{
			KeyboardState state = Keyboard.GetState();

			if (state.IsKeyDown(Key.A)) position.X -= CameraTranslationSpeed * deltaTime;
			if (state.IsKeyDown(Key.D)) position.X += CameraTranslationSpeed * deltaTime;
			if (state.IsKeyDown(Key.W)) position.Y += CameraTranslationSpeed * deltaTime;
			if (state.IsKeyDown(Key.S)) position.Y -= CameraTranslationSpeed * deltaTime;

			Camera.Position = new Vector3(position);
		}

		public void OnWindowResize()
		{
			aspectRatio = (float)app.Width / app.Height;
			Camera.SetProjection(-aspectRatio * zoom, aspectRatio * zoom, -zoom, zoom);
		}

		public float MaxZoom = 0.25f;
		public float MinZoom = 10f;
		
		public void OnMouseScroll(MouseWheelEventArgs args)
		{
			zoom -= args.DeltaPrecise * 0.25f;
			
			zoom = Math.Max(zoom, MaxZoom);
			zoom = Math.Min(zoom, MinZoom);
			
			Camera.SetProjection(-aspectRatio * zoom, aspectRatio * zoom, -zoom, zoom);

			CameraTranslationSpeed = Math.Max(5f, Math.Min(zoom, MaxZoom));
		}
	}
}