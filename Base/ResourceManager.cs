using System.Collections.Generic;

namespace Base
{
	public static class ResourceManager
	{
		private static Dictionary<string, Shader> ShaderCache = new Dictionary<string, Shader>();

		public static Shader GetShader(string vertexPath, string fragmentPath)
		{
			if (ShaderCache.TryGetValue(vertexPath, out Shader shader)) return shader;

			Shader n = new Shader(vertexPath, fragmentPath);
			ShaderCache.Add(vertexPath, n);
			return n;
		}
	}
}