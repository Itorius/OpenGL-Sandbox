using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using Raytracer;
using System;
using System.IO;
using System.Linq;

namespace Base
{
	public static class Renderer2D
	{
		private const int QuadCount = 10000;
		private const int VertexCount = QuadCount * 4;
		private const int IndexCount = QuadCount * 6;

		private static Vertex[] Vertices = new Vertex[VertexCount];
		private static uint[] Indices = new uint[IndexCount];

		private static Mesh Quads;

		private static Shader fontShader;
		private static int fontTexture;
		private static Glyph[] glyphs = new Glyph[256];

		private struct SceneData
		{
			public Shader Shader;
			public Matrix4 ViewProjection;
			public MultisampleFramebuffer Framebuffer;
		}

		private static SceneData scene;

		static Renderer2D()
		{
			Quads = new Mesh();
			Quads.SetVertices(ref Vertices);
			Quads.SetIndices(ref Indices);

			fontShader = new Shader("Assets/Shaders/Font.vert", "Assets/Shaders/Font.frag");

			string[] files = Directory.GetFiles(@"Assets/Font");

			GL.GenTextures(1, out fontTexture);
			GL.BindTexture(TextureTarget.Texture2DArray, fontTexture);

			GL.TexStorage3D(TextureTarget3d.Texture2DArray, 1, SizedInternalFormat.Rgba8, 64, 64, files.Length);
			GL.PixelStore(PixelStoreParameter.UnpackAlignment, 1);

			GL.TextureParameter(fontTexture, TextureParameterName.TextureMinFilter, (int)All.Linear);
			GL.TextureParameter(fontTexture, TextureParameterName.TextureMagFilter, (int)All.Linear);

			int index = 0;
			foreach (string file in files)
			{
				using BinaryReader reader = new BinaryReader(File.OpenRead(file));
				char ch = reader.ReadChar();
				float adv = reader.ReadSingle();
				float bX = reader.ReadSingle();
				float bY = reader.ReadSingle();
				float bW = reader.ReadSingle();
				float bH = reader.ReadSingle();
				byte[] bytes = new byte[16384];
				reader.Read(bytes);

				GL.TexSubImage3D(TextureTarget.Texture2DArray, 0, 0, 0, index, 64, 64, 1, PixelFormat.Rgba, PixelType.UnsignedByte, bytes);

				ref Glyph glyph = ref glyphs[ch];

				glyph.TextureSlot = index;
				glyph.Advance = adv;
				glyph.Bearing = new Vector2(bX, bY);
				glyph.Size = new Vector2(bW, bH);

				index++;
			}
		}

		public static void BeginScene(Matrix4 camera, Shader shader, MultisampleFramebuffer framebuffer = null)
		{
			scene.Shader = shader;
			scene.ViewProjection = camera;
			scene.Framebuffer = framebuffer;

			framebuffer?.Bind();

			shader.Bind();
			shader.UploadUniformMat4("u_ViewProjection", camera);

			Quads.Bind();
		}

		public static void EndScene()
		{
			Flush();

			scene.Shader.Unbind();
			scene.Framebuffer?.Unbind();

			Quads.Unbind();
		}

		private static int quad;
		private static int index;
		private static uint vertex;

		public static void DrawMesh(ref Mesh mesh)
		{
			Quads.Unbind();

			mesh.Draw();

			Quads.Bind();
		}

		public static void DrawQuad(Vector2 position, Vector2 size, Color4? color = null, Quaternion? rotation = null, float texture = 0f)
		{
			if (quad >= QuadCount) Flush();

			rotation ??= Quaternion.Identity;
			color ??= Color4.White;

			Matrix4 m = Matrix4.CreateScale(size.X, size.Y, 1f) * Matrix4.CreateFromQuaternion(rotation.Value) * Matrix4.CreateTranslation(position.X, position.Y, 0f);

			Vertices[vertex] = new Vertex((new Vector4(-0.5f, 0.5f, 0f, 1f) * m).Xyz, new Vector3(0f, 1f, texture), color.Value);
			Vertices[vertex + 1] = new Vertex((new Vector4(0.5f, 0.5f, 0f, 1f) * m).Xyz, new Vector3(1f, 1f, texture), color.Value);
			Vertices[vertex + 2] = new Vertex((new Vector4(0.5f, -0.5f, 0f, 1f) * m).Xyz, new Vector3(1f, 0f, texture), color.Value);
			Vertices[vertex + 3] = new Vertex((new Vector4(-0.5f, -0.5f, 0f, 1f) * m).Xyz, new Vector3(0f, 0f, texture), color.Value);

			Indices[index] = vertex;
			Indices[index + 1] = vertex + 1;
			Indices[index + 2] = vertex + 2;
			Indices[index + 3] = vertex + 2;
			Indices[index + 4] = vertex + 3;
			Indices[index + 5] = vertex + 0;

			vertex += 4;
			index += 6;

			quad++;
		}

		public static void DrawLine(Vector2 start, Vector2 end, Color4? color = null, float width = 2f)
		{
			if (quad >= QuadCount) Flush();

			color ??= Color4.White;
			width *= 0.5f;

			Vector2 direction = Vector2.Normalize(end - start);
			Vector2 normal = new Vector2(direction.Y, -direction.X);

			Vertices[vertex] = new Vertex(start + normal * width, new Vector3(0f, 1f, 0f), color.Value);
			Vertices[vertex + 1] = new Vertex(end + normal * width, new Vector3(1f, 1f, 0f), color.Value);
			Vertices[vertex + 2] = new Vertex(end - normal * width, new Vector3(1f, 0f, 0f), color.Value);
			Vertices[vertex + 3] = new Vertex(start - normal * width, new Vector3(0f, 0f, 0f), color.Value);

			Indices[index] = vertex;
			Indices[index + 1] = vertex + 1;
			Indices[index + 2] = vertex + 2;
			Indices[index + 3] = vertex + 2;
			Indices[index + 4] = vertex + 3;
			Indices[index + 5] = vertex + 0;

			vertex += 4;
			index += 6;

			quad++;
		}

		public static void DrawString(string text, float x, float y, Color4? color = null, float scale = 1f)
		{
			var data = scene;
			EndScene();

			BeginScene(data.ViewProjection, fontShader);
			fontShader.UploadUniformFloat2("u_ViewportSize", new Vector2(BaseWindow.Instance.Width, BaseWindow.Instance.Height));

			GL.BindTexture(TextureTarget.Texture2DArray, fontTexture);
			GL.ActiveTexture(TextureUnit.Texture0);

			color ??= Color4.White;

			foreach (char c in text)
			{
				Glyph glyph = glyphs[c];

				if (c == '\n')
				{
					y -= (glyphs.Max(glyph => glyph.Size.Y) + 5f) * scale;
					x = -500f;
					continue;
				}

				if (c != ' ')
				{
					float xpos = x;
					float ypos = y - MathF.Min(0, (glyph.Size.Y - glyph.Bearing.Y) * scale);

					DrawQuad(new Vector2(xpos, ypos), new Vector2(64f) * scale, color, texture: glyph.TextureSlot);
				}

				x += glyph.Advance * scale;
			}

			EndScene();

			BeginScene(data.ViewProjection, data.Shader);
		}

		public static void Flush()
		{
			if (quad <= 0) return;

			Quads.Bind();

			Quads.SetVertices(ref Vertices);
			Quads.SetIndices(ref Indices);

			GL.DrawElements(BeginMode.Triangles, quad * 6, DrawElementsType.UnsignedInt, 0);

			quad = 0;
			vertex = 0;
			index = 0;
		}
	}
}