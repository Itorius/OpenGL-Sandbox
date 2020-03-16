using OpenTK;
using OpenTK.Graphics;
using System;

namespace Base
{
	[Serializable]
	public partial struct Color : IEquatable<Color>
	{
		public float R;
		public float G;
		public float B;
		public float A;

		public Color(float r, float g, float b, float a)
		{
			R = r;
			G = g;
			B = b;
			A = a;
		}

		public Color(byte r, byte g, byte b, byte a)
		{
			R = r / (float)byte.MaxValue;
			G = g / (float)byte.MaxValue;
			B = b / (float)byte.MaxValue;
			A = a / (float)byte.MaxValue;
		}

		public int ToArgb()
		{
			return (int)((uint)(((int)(uint)(A * byte.MaxValue) << 24) | ((int)(uint)(R * (double)byte.MaxValue) << 16) | ((int)(uint)(G * (double)byte.MaxValue) << 8)) | (uint)(B * (double)byte.MaxValue));
		}

		public static bool operator ==(Color left, Color right) => left.Equals(right);

		public static bool operator !=(Color left, Color right) => !left.Equals(right);

		public static implicit operator Color4(Color color) => new Color4(color.R, color.G, color.B, color.A);

		public static implicit operator Color(Color4 color) => new Color(color.R, color.G, color.B, color.A);

		public override bool Equals(object obj) => obj is Color other && Equals(other);

		public override int GetHashCode() => ToArgb();

		public override string ToString() => $"{{(R, G, B, A) = ({R}, {G}, {B}, {A})}}";

		public static Color FromSrgb(Color srgb)
		{
			return new Color((double)srgb.R > 0.0404499992728233 ? (float)Math.Pow((srgb.R + 0.0549999997019768) / 1.05499994754791, 2.40000009536743) : srgb.R / 12.92f, (double)srgb.G > 0.0404499992728233 ? (float)Math.Pow((srgb.G + 0.0549999997019768) / 1.05499994754791, 2.40000009536743) : srgb.G / 12.92f, (double)srgb.B > 0.0404499992728233 ? (float)Math.Pow((srgb.B + 0.0549999997019768) / 1.05499994754791, 2.40000009536743) : srgb.B / 12.92f, srgb.A);
		}

		public static Color ToSrgb(Color rgb)
		{
			return new Color((double)rgb.R > 0.0031308 ? (float)(1.05499994754791 * Math.Pow(rgb.R, 0.416666656732559) - 0.0549999997019768) : 12.92f * rgb.R, (double)rgb.G > 0.0031308 ? (float)(1.05499994754791 * Math.Pow(rgb.G, 0.416666656732559) - 0.0549999997019768) : 12.92f * rgb.G, (double)rgb.B > 0.0031308 ? (float)(1.05499994754791 * Math.Pow(rgb.B, 0.416666656732559) - 0.0549999997019768) : 12.92f * rgb.B, rgb.A);
		}

		public static Color FromHsl(Vector4 hsl)
		{
			float num1 = hsl.X * 360f;
			float y = hsl.Y;
			float z = hsl.Z;
			float num2 = (1f - Math.Abs((float)(2.0 * z - 1.0))) * y;
			float num3 = num1 / 60f;
			float num4 = num2 * (1f - Math.Abs((float)(num3 % 2.0 - 1.0)));
			float num5;
			float num6;
			float num7;
			if (0.0 <= num3 && num3 < 1.0)
			{
				num5 = num2;
				num6 = num4;
				num7 = 0.0f;
			}
			else if (1.0 <= num3 && num3 < 2.0)
			{
				num5 = num4;
				num6 = num2;
				num7 = 0.0f;
			}
			else if (2.0 <= num3 && num3 < 3.0)
			{
				num5 = 0.0f;
				num6 = num2;
				num7 = num4;
			}
			else if (3.0 <= num3 && num3 < 4.0)
			{
				num5 = 0.0f;
				num6 = num4;
				num7 = num2;
			}
			else if (4.0 <= num3 && num3 < 5.0)
			{
				num5 = num4;
				num6 = 0.0f;
				num7 = num2;
			}
			else if (5.0 <= num3 && num3 < 6.0)
			{
				num5 = num2;
				num6 = 0.0f;
				num7 = num4;
			}
			else
			{
				num5 = 0.0f;
				num6 = 0.0f;
				num7 = 0.0f;
			}

			float num8 = z - num2 / 2f;
			return new Color(num5 + num8, num6 + num8, num7 + num8, hsl.W);
		}

		public static Vector4 ToHsl(Color rgb)
		{
			float num1 = Math.Max(rgb.R, Math.Max(rgb.G, rgb.B));
			float num2 = Math.Min(rgb.R, Math.Min(rgb.G, rgb.B));
			float num3 = num1 - num2;
			float num4 = 0.0f;
			if (num1 == (double)rgb.R) num4 = (rgb.G - rgb.B) / num3;
			else if (num1 == (double)rgb.G) num4 = (float)((rgb.B - (double)rgb.R) / num3 + 2.0);
			else if (num1 == (double)rgb.B) num4 = (float)((rgb.R - (double)rgb.G) / num3 + 4.0);
			float x = num4 / 6f;
			if (x < 0.0) ++x;
			float z = (float)((num1 + (double)num2) / 2.0);
			float y = 0.0f;
			if (0.0 != z && z != 1.0) y = num3 / (1f - Math.Abs((float)(2.0 * z - 1.0)));
			return new Vector4(x, y, z, rgb.A);
		}

		public static Color FromHsv(Vector4 hsv) => FromHsv(hsv.X, hsv.Y, hsv.Z, hsv.W);

		public static Color FromHsv(float hue, float saturation, float value, float alpha)
		{
			float num1 = hue * 360f;
			float y = saturation;
			float z = value;
			float num2 = z * y;
			float num3 = num1 / 60f;
			float num4 = num2 * (1f - Math.Abs((float)(num3 % 2.0 - 1.0)));
			float num5;
			float num6;
			float num7;
			if (0.0 <= num3 && num3 < 1.0)
			{
				num5 = num2;
				num6 = num4;
				num7 = 0.0f;
			}
			else if (1.0 <= num3 && num3 < 2.0)
			{
				num5 = num4;
				num6 = num2;
				num7 = 0.0f;
			}
			else if (2.0 <= num3 && num3 < 3.0)
			{
				num5 = 0.0f;
				num6 = num2;
				num7 = num4;
			}
			else if (3.0 <= num3 && num3 < 4.0)
			{
				num5 = 0.0f;
				num6 = num4;
				num7 = num2;
			}
			else if (4.0 <= num3 && num3 < 5.0)
			{
				num5 = num4;
				num6 = 0.0f;
				num7 = num2;
			}
			else if (5.0 <= num3 && num3 < 6.0)
			{
				num5 = num2;
				num6 = 0.0f;
				num7 = num4;
			}
			else
			{
				num5 = 0.0f;
				num6 = 0.0f;
				num7 = 0.0f;
			}

			float num8 = z - num2;
			return new Color(num5 + num8, num6 + num8, num7 + num8, alpha);
		}

		public static Vector4 ToHsv(Color rgb)
		{
			float z = Math.Max(rgb.R, Math.Max(rgb.G, rgb.B));
			float num1 = Math.Min(rgb.R, Math.Min(rgb.G, rgb.B));
			float num2 = z - num1;
			float num3 = 0.0f;
			if (z == (double)rgb.R) num3 = (float)((rgb.G - (double)rgb.B) / num2 % 6.0);
			else if (z == (double)rgb.G) num3 = (float)((rgb.B - (double)rgb.R) / num2 + 2.0);
			else if (z == (double)rgb.B) num3 = (float)((rgb.R - (double)rgb.G) / num2 + 4.0);
			float x = (float)(num3 * 60.0 / 360.0);
			float y = 0.0f;
			if (0.0 != z) y = num2 / z;
			return new Vector4(x, y, z, rgb.A);
		}

		public static Color FromXyz(Vector4 xyz)
		{
			return new Color((float)(0.418469995260239 * xyz.X + -0.158659994602203 * xyz.Y + -0.0828349962830544 * xyz.Z), (float)(-0.091168999671936 * xyz.X + 0.252429991960526 * xyz.Y + 0.0157079994678497 * xyz.Z), (float)(0.000920900027267635 * xyz.X + -0.00254980009049177 * xyz.Y + 0.178599998354912 * xyz.Z), xyz.W);
		}

		public static Vector4 ToXyz(Color rgb)
		{
			return new Vector4((float)((0.490000009536743 * rgb.R + 0.310000002384186 * rgb.G + 0.200000002980232 * rgb.B) / 0.1769700050354), (float)((0.1769700050354 * rgb.R + 0.812399983406067 * rgb.G + 0.0106300003826618 * rgb.B) / 0.1769700050354), (float)((0.0 * rgb.R + 0.00999999977648258 * rgb.G + 0.990000009536743 * rgb.B) / 0.1769700050354), rgb.A);
		}

		public static Color FromYcbcr(Vector4 ycbcr)
		{
			return new Color((float)(1.0 * ycbcr.X + 0.0 * ycbcr.Y + 1.40199995040894 * ycbcr.Z), (float)(1.0 * ycbcr.X + -0.344135999679565 * ycbcr.Y + -0.714136004447937 * ycbcr.Z), (float)(1.0 * ycbcr.X + 1.77199995517731 * ycbcr.Y + 0.0 * ycbcr.Z), ycbcr.W);
		}

		public static Vector4 ToYcbcr(Color rgb)
		{
			return new Vector4((float)(0.29899999499321 * rgb.R + 0.587000012397766 * rgb.G + 57.0 / 500.0 * rgb.B), (float)(-0.16873599588871 * rgb.R + -0.331263989210129 * rgb.G + 0.5 * rgb.B), (float)(0.5 * rgb.R + -0.418687999248505 * rgb.G + -0.0813120007514954 * rgb.B), rgb.A);
		}

		public static Color FromHcy(Vector4 hcy)
		{
			float num1 = hcy.X * 360f;
			float y = hcy.Y;
			float z = hcy.Z;
			float num2 = num1 / 60f;
			float num3 = y * (1f - Math.Abs((float)(num2 % 2.0 - 1.0)));
			float num4;
			float num5;
			float num6;
			if (0.0 <= num2 && num2 < 1.0)
			{
				num4 = y;
				num5 = num3;
				num6 = 0.0f;
			}
			else if (1.0 <= num2 && num2 < 2.0)
			{
				num4 = num3;
				num5 = y;
				num6 = 0.0f;
			}
			else if (2.0 <= num2 && num2 < 3.0)
			{
				num4 = 0.0f;
				num5 = y;
				num6 = num3;
			}
			else if (3.0 <= num2 && num2 < 4.0)
			{
				num4 = 0.0f;
				num5 = num3;
				num6 = y;
			}
			else if (4.0 <= num2 && num2 < 5.0)
			{
				num4 = num3;
				num5 = 0.0f;
				num6 = y;
			}
			else if (5.0 <= num2 && num2 < 6.0)
			{
				num4 = y;
				num5 = 0.0f;
				num6 = num3;
			}
			else
			{
				num4 = 0.0f;
				num5 = 0.0f;
				num6 = 0.0f;
			}

			float num7 = z - (float)(0.300000011920929 * num4 + 0.589999973773956 * num5 + 0.109999999403954 * num6);
			return new Color(num4 + num7, num5 + num7, num6 + num7, hcy.W);
		}

		public static Vector4 ToHcy(Color rgb)
		{
			float num1 = Math.Max(rgb.R, Math.Max(rgb.G, rgb.B));
			float num2 = Math.Min(rgb.R, Math.Min(rgb.G, rgb.B));
			float y = num1 - num2;
			float num3 = 0.0f;
			if (num1 == (double)rgb.R) num3 = (float)((rgb.G - (double)rgb.B) / y % 6.0);
			else if (num1 == (double)rgb.G) num3 = (float)((rgb.B - (double)rgb.R) / y + 2.0);
			else if (num1 == (double)rgb.B) num3 = (float)((rgb.R - (double)rgb.G) / y + 4.0);
			float x = (float)(num3 * 60.0 / 360.0);
			float z = (float)(0.300000011920929 * rgb.R + 0.589999973773956 * rgb.G + 0.109999999403954 * rgb.B);
			return new Vector4(x, y, z, rgb.A);
		}

		public bool Equals(Color other)
		{
			return R == (double)other.R && G == (double)other.G && B == (double)other.B && A == (double)other.A;
		}

		public static Color operator *(Color color, float scalar) => new Color(color.R * scalar, color.G * scalar, color.B * scalar, color.A);

		public static Color Lerp(Color a, Color b, float blend)
		{
			blend = MathHelper.Clamp(blend, 0f, 1f);

			a.R = blend * (b.R - a.R) + a.R;
			a.G = blend * (b.G - a.G) + a.G;
			a.B = blend * (b.B - a.B) + a.B;
			a.A = blend * (b.A - a.A) + a.A;
			return a;
		}
	}
}