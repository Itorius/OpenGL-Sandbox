using OpenTK.Graphics;

namespace Base
{
	public struct Vertex
	{
		public Vector3 position;
		public Vector3 normal;
		public Vector3 uv;
		public Color4 color;

		public Vertex(Vector3 position, Vector3 uv, Vector3 normal, Color4 color)
		{
			this.position = position;
			this.uv = uv;
			this.normal = normal;
			this.color = color;
		}

		public Vertex(Vector3 position, Vector3 uv, Color4 color)
		{
			this.position = position;
			this.uv = uv;
			normal = Vector3.UnitZ;
			this.color = color;
		}

		public Vertex(Vector2 position, Vector3 uv, Color4 color)
		{
			this.position = new Vector3(position);
			this.uv = uv;
			normal = Vector3.UnitZ;
			this.color = color;
		}
	}
}