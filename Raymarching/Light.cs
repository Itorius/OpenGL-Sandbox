using OpenTK;
using System.Runtime.InteropServices;

namespace Raymarching
{
	[StructLayout(LayoutKind.Explicit)]
	public struct Light
	{
		[FieldOffset(0)]
		private Vector4 position;

		public Light(Vector4 position) => this.position = position;
	}
}