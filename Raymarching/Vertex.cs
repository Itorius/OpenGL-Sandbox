using OpenTK;

namespace Raymarching
{
	public struct Vertex
	{
		public Vector3 position;
		public Vector2 uv;

		public Vertex(Vector3 positon, Vector2 uv)
		{
			position = positon;
			this.uv = uv;
		}
	}
}