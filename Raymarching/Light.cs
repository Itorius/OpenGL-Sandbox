using OpenTK;
using OpenTK.Graphics;
using System.Runtime.InteropServices;

namespace Raymarching
{
	[StructLayout(LayoutKind.Explicit)]
	public struct Light
	{
		[FieldOffset(0)]
		public Vector4 position;

		[FieldOffset(4 * sizeof(float))]
		public Color4 color;

		public static Light CreatePoint(Vector3 position, Color4 color) => new Light
		{
			position = new Vector4(position, 1f),
			color = color
		};

		public static Light CreateDirectional(Vector3 position, Color4 color) => new Light
		{
			position = new Vector4(position, 0f),
			color = color
		};
	}
}