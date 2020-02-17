using OpenTK.Graphics.OpenGL4;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.PixelFormats;
using System.Collections.Generic;

namespace Base
{
	public abstract class Texture
	{
		public int ID;
	}

	public class Texture1D : Texture
	{
		public Texture1D(string path)
		{
			Image<Rgba32> image = Image.Load<Rgba32>(path);

			List<byte> pixels = new List<byte>();
			foreach (Rgba32 p in image.GetPixelSpan())
			{
				pixels.Add(p.R);
				pixels.Add(p.G);
				pixels.Add(p.B);
				pixels.Add(p.A);
			}

			GL.GenTextures(1, out ID);
			GL.BindTexture(TextureTarget.Texture1D, ID);

			GL.TextureStorage1D(ID, 1, SizedInternalFormat.Rgba8, image.Width);

			GL.TextureParameter(ID, TextureParameterName.TextureMinFilter, (int)All.Linear);
			GL.TextureParameter(ID, TextureParameterName.TextureMagFilter, (int)All.Nearest);

			GL.TextureSubImage1D(ID, 0, 0, image.Width, PixelFormat.Rgba, PixelType.UnsignedByte, pixels.ToArray());
		}

		public void Bind()
		{
			GL.ActiveTexture(TextureUnit.Texture0);
			GL.BindTexture(TextureTarget.Texture1D, ID);
		}
	}

	public class Texture2D : Texture
	{
		public Texture2D(string path)
		{
			Image<Rgba32> image = Image.Load<Rgba32>(path);

			List<byte> pixels = new List<byte>();
			foreach (Rgba32 p in image.GetPixelSpan())
			{
				pixels.Add(p.R);
				pixels.Add(p.G);
				pixels.Add(p.B);
				pixels.Add(p.A);
			}

			GL.GenTextures(1, out ID);
			GL.BindTexture(TextureTarget.Texture2D, ID);

			GL.TextureStorage2D(ID, 1, SizedInternalFormat.Rgba8, image.Width, image.Height);

			GL.TextureParameter(ID, TextureParameterName.TextureMinFilter, (int)All.Linear);
			GL.TextureParameter(ID, TextureParameterName.TextureMagFilter, (int)All.Nearest);

			GL.TextureSubImage2D(ID, 0, 0, 0, image.Width, image.Height, PixelFormat.Rgba, PixelType.UnsignedByte, pixels.ToArray());
		}
	}
}