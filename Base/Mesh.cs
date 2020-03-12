using OpenTK;
using OpenTK.Graphics.OpenGL4;
using System;

namespace Base
{
	public class Mesh
	{
		private int vao, vbo, ebo;
		public uint[] indices;
		public Vertex[] vertices;

		public unsafe Mesh()
		{
			GL.GenVertexArrays(1, out vao);
			GL.GenBuffers(1, out vbo);
			GL.GenBuffers(1, out ebo);

			GL.BindVertexArray(vao);
			GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);

			GL.BufferData(BufferTarget.ArrayBuffer, 0, IntPtr.Zero, BufferUsageHint.StaticDraw);

			GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
			GL.BufferData(BufferTarget.ElementArrayBuffer, 0, IntPtr.Zero, BufferUsageHint.StaticDraw);

			// position
			GL.EnableVertexAttribArray(0);
			GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, sizeof(Vertex), 0);

			// normal
			GL.EnableVertexAttribArray(1);
			GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, sizeof(Vertex), sizeof(Vector3));

			// uv
			GL.EnableVertexAttribArray(2);
			GL.VertexAttribPointer(2, 3, VertexAttribPointerType.Float, false, sizeof(Vertex), sizeof(Vector3) * 2);

			// color
			GL.EnableVertexAttribArray(3);
			GL.VertexAttribPointer(3, 4, VertexAttribPointerType.Float, false, sizeof(Vertex), sizeof(Vector3) * 3);

			GL.BindVertexArray(0);
		}

		public unsafe void SetVertices(ref Vertex[] array)
		{
			vertices = array;
			GL.NamedBufferData(vbo, sizeof(Vertex) * array.Length, array, BufferUsageHint.StaticDraw);
		}

		public void SetIndices(ref uint[] array)
		{
			indices = array;
			GL.NamedBufferData(ebo, sizeof(uint) * array.Length, array, BufferUsageHint.StaticDraw);
		}

		public void Bind()
		{
			GL.BindVertexArray(vao);
		}

		public void Unbind()
		{
			GL.BindVertexArray(0);
		}

		public void Draw()
		{
			Bind();
			GL.DrawElements(BeginMode.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);
			Unbind();
		}
	}
}