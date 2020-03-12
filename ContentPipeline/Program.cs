using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ContentPipeline
{
	internal static class Program
	{
		/*msdfgen.exe metrics -font Roboto-Regular.ttf %%x -size 64 64 -pxrange 12 -translate 6 12 -o %%x.txt -yflip
		msdfgen.exe msdf -font Roboto-Regular.ttf %%x -size 64 64 -pxrange 12 -translate 6 12 -o %%x.png -yflip*/

		public static readonly string AppRoot = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

		private static void Main(string[] args)
		{
			if (Directory.Exists($"{AppRoot}/out")) Directory.Delete($"{AppRoot}/out", true);
			Directory.CreateDirectory($"{AppRoot}/out");

			const int width = 64;
			const int height = 64;
			const int pxrange = 12;
			const int translateX = 10;
			const int translateY = 10;

			ProcessStartInfo startInfo = new ProcessStartInfo("msdfgen.exe")
			{
				UseShellExecute = false
			};

			for (char c = (char)1; c < 256; c++)
			{
				// if (char.IsWhiteSpace(c) || char.IsControl(c)) continue;

				startInfo.Arguments = $"msdf -font Roboto-Regular.ttf {(int)c} -size {width} {height} -pxrange {pxrange} -translate {translateX} {translateY} -o {(int)c}.png -yflip";
				Process.Start(startInfo).WaitForExit();

				Image image = Image.FromFile($"{(int)c}.png");
				Bitmap bmp = new Bitmap(image);
				var data = bmp.LockBits(new Rectangle(0, 0, 64, 64), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

				int numbytes = data.Stride * bmp.Height;
				byte[] bytes = new byte[numbytes];
				IntPtr ptr = data.Scan0;

				Marshal.Copy(ptr, bytes, 0, numbytes);

				bmp.UnlockBits(data);

				image.Dispose();

				File.Delete($"{(int)c}.png");

				startInfo.Arguments = $"metrics -font Roboto-Regular.ttf {(int)c} -size {width} {height} -pxrange {pxrange} -translate {translateX} {translateY} -o {(int)c}.txt -yflip";
				Process.Start(startInfo).WaitForExit();

				var lines = File.ReadAllLines($"{(int)c}.txt");
				File.Delete($"{(int)c}.txt");

				using BinaryWriter stream = new BinaryWriter(File.OpenWrite($"out/{(int)c}.dat"));

				stream.Write(c);

				string? advanceLine = lines.FirstOrDefault(s => s.StartsWith("advance = "));
				if (advanceLine != null)
				{
					string advance = advanceLine.Replace("advance = ", null);
					stream.Write(float.Parse(advance));
				}

				string? boundsLine = lines.FirstOrDefault(s => s.StartsWith("bounds = "));
				if (boundsLine != null)
				{
					string bounds = boundsLine.Replace("bounds = ", null);
					string[] split = bounds.Split(", ");

					stream.Write(float.Parse(split[0]));
					stream.Write(float.Parse(split[1]));
					stream.Write(float.Parse(split[2]));
					stream.Write(float.Parse(split[3]));
				}

				stream.Write(bytes);
			}
		}
	}
}