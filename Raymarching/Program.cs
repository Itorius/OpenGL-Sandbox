using OpenTK;

namespace Raymarching
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			using Game game = new Game
			{
				VSync = VSyncMode.On, TargetRenderFrequency = 120.0
			};
			game.Run(60);
		}
	}
}