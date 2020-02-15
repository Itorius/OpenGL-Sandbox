using OpenTK;

namespace Base
{
	public class OrthographicCamera
	{
		public Matrix4 ProjectionMatrix { get; private set; }
		public Matrix4 ViewMatrix { get; private set; }
		public Matrix4 ViewProjectionMatrix { get; private set; }

		private Vector3 _position;

		public Vector3 Position
		{
			get => _position;
			set
			{
				_position = value;
				RecalculateViewMatrix();
			}
		}

		private float _rotation;

		public float Rotation
		{
			get => _rotation;
			set
			{
				_rotation = value;
				RecalculateViewMatrix();
			}
		}

		public OrthographicCamera(float left, float right, float bottom, float top)
		{
			ProjectionMatrix = Matrix4.CreateOrthographicOffCenter(left, right, bottom, top, -1f, 1f);
			ViewMatrix = Matrix4.Identity;

			ViewProjectionMatrix = ProjectionMatrix * ViewMatrix;
		}

		public void SetProjection(float left, float right, float bottom, float top)
		{
			ProjectionMatrix = Matrix4.CreateOrthographicOffCenter(left, right, bottom, top, -1f, 1f);
			ViewProjectionMatrix = ProjectionMatrix * ViewMatrix;
		}

		private void RecalculateViewMatrix()
		{
			Matrix4 transform = Matrix4.CreateTranslation(Position) * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Rotation));

			ViewMatrix = Matrix4.Invert(transform);

			ViewProjectionMatrix = ProjectionMatrix * ViewMatrix;
		}
	}
}