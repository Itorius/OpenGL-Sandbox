using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using System;

namespace Base
{
	public class MultisampleFramebuffer
	{
		private int samples;

		private int framebuffer;
		private int renderbuffer;
		private int texture;

		private Mesh mesh;

		public MultisampleFramebuffer(int width, int height, int samples = 4)
		{
			this.samples = samples;

			GL.GenFramebuffers(1, out framebuffer);
			GL.BindFramebuffer(FramebufferTarget.Framebuffer, framebuffer);

			GL.GenTextures(1, out texture);
			GL.BindTexture(TextureTarget.Texture2DMultisample, texture);

			GL.TexImage2DMultisample(TextureTargetMultisample.Texture2DMultisample, samples, PixelInternalFormat.Rgb, width, height, true);
			GL.BindTexture(TextureTarget.Texture2DMultisample, 0);

			GL.FramebufferTexture2D(FramebufferTarget.Framebuffer, FramebufferAttachment.ColorAttachment0, TextureTarget.Texture2DMultisample, texture, 0);

			GL.GenRenderbuffers(1, out renderbuffer);
			GL.BindRenderbuffer(RenderbufferTarget.Renderbuffer, renderbuffer);
			GL.RenderbufferStorageMultisample(RenderbufferTarget.Renderbuffer, samples, RenderbufferStorage.Depth24Stencil8, width, height);
			GL.BindRenderbuffer(RenderbufferTarget.Renderbuffer, 0);
			GL.FramebufferRenderbuffer(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthStencilAttachment, RenderbufferTarget.Renderbuffer, renderbuffer);

			if (GL.CheckFramebufferStatus(FramebufferTarget.Framebuffer) != FramebufferErrorCode.FramebufferComplete) throw new Exception("Not complete");
			GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);

			mesh = new Mesh();

			Vertex[] vertices =
			{
				new Vertex(new Vector2(-1f, -1f), new Vector3(0f, 0f, 0f), Color4.White),
				new Vertex(new Vector2(1f, -1f), new Vector3(1f, 0f, 0f), Color4.White),
				new Vertex(new Vector2(1f, 1f), new Vector3(1f, 1f, 1f), Color4.White),
				new Vertex(new Vector2(-1f, 1f), new Vector3(0f, 1f, 1f), Color4.White)
			};
			mesh.SetVertices(ref vertices);

			uint[] indices = { 0, 1, 2, 2, 3, 0 };
			mesh.SetIndices(ref indices);
		}

		public void SetSize(int width, int height)
		{
			GL.BindTexture(TextureTarget.Texture2DMultisample, texture);
			GL.TexImage2DMultisample(TextureTargetMultisample.Texture2DMultisample, samples, PixelInternalFormat.Rgb, width, height, true);
			GL.BindTexture(TextureTarget.Texture2DMultisample, 0);

			GL.BindRenderbuffer(RenderbufferTarget.Renderbuffer, renderbuffer);
			GL.RenderbufferStorageMultisample(RenderbufferTarget.Renderbuffer, samples, RenderbufferStorage.Depth24Stencil8, width, height);
			GL.BindRenderbuffer(RenderbufferTarget.Renderbuffer, 0);
		}

		public void Bind()
		{
			GL.BindFramebuffer(FramebufferTarget.Framebuffer, framebuffer);
		}

		public void Unbind()
		{
			GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
		}

		public void Draw()
		{
			GL.BindTexture(TextureTarget.Texture2DMultisample, texture);
			GL.ActiveTexture(TextureUnit.Texture0);

			mesh.Draw();
		}

		public void BindTexture()
		{
			GL.BindTexture(TextureTarget.Texture2DMultisample, texture);
			GL.ActiveTexture(TextureUnit.Texture0);
		}

		public void Clear(Color? color = null)
		{
			if (color != null) GL.ClearColor((Color4)color);
			GL.Clear(ClearBufferMask.ColorBufferBit);
		}
	}
}