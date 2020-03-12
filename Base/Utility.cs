using System;

namespace Base
{
	public static class Utility
	{
		public const float DegToRad = 0.01745329f;
		public const float RadToDeg = 57.29578f;

		public static float NextFloat(this Random random) => (float)random.NextDouble();
	}
}