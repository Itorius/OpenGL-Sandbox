using System;

namespace Base
{
	public static class Utility
	{
		public const float DegToRad = 0.01745329f;
		public const float RadToDeg = 57.29578f;

		public static float NextFloat(this Random random) => (float)random.NextDouble();

		public static float Clamp(in float value, in float min, in float max)
		{
			if (value > max) return max;
			return value < min ? min : value;
		}

		public static float UnsignedSin(float angle) => MathF.Sin(angle) * 0.5f + 0.5f;
	}
}