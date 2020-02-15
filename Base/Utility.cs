using System;

namespace Base
{
	public static class Utility
	{
		public static float NextFloat(this Random random) => (float)random.NextDouble();
	}
}