// using Base;
// using Dear_ImGui_Sample;
// using ImGuiNET;
// using OpenTK;
// using OpenTK.Graphics;
// using OpenTK.Graphics.OpenGL4;
// using System;
//
// namespace Raymarching
// {
// 	internal class Game : BaseWindow
// 	{
// 		private float shadowSpread = 40f;
//
// 		private Shader shader;
// 		private Matrix4 matrix;
// 		private ImGuiController ImGuiController;
//
// 		private int lightBuffer;
// 		private Light[] lights;
//
// 		private VertexBuffer<Vertex> buffer;
//
// 		protected override unsafe void OnLoad(EventArgs e)
// 		{
// 			ImGuiController = new ImGuiController(Width, Height);
//
// 			shader = new Shader("Assets/Basic.vert", "Assets/Basic.frag");
//
// 			int index = GL.GetUniformBlockIndex(shader.ID, "LightingBlock");
// 			GL.UniformBlockBinding(shader.ID, index, 0);
//
// 			lights = new[]
// 			{
// 				Light.CreateDirectional(new Vector3(0.6f, 0.9f, 0f), Color4.White)
// 				// Light.CreatePoint(new Vector3(0f, 5f, 0f), Color4.Red)
// 			};
//
// 			GL.GenBuffers(1, out lightBuffer);
// 			GL.BindBuffer(BufferTarget.UniformBuffer, lightBuffer);
// 			GL.BufferData(BufferTarget.UniformBuffer, 16 * sizeof(Light), lights, BufferUsageHint.StaticDraw);
// 			GL.BindBuffer(BufferTarget.UniformBuffer, 0);
//
// 			GL.BindBufferRange(BufferRangeTarget.UniformBuffer, 0, lightBuffer, IntPtr.Zero, 16 * sizeof(Light));
//
// 			matrix = Matrix4.CreateOrthographicOffCenter(-1.6f, 1.6f, -0.9f, 0.9f, -1f, 1f);
//
// 			buffer = new VertexBuffer<Vertex>(new[]
// 			{
// 				new Vertex(new Vector3(-1.6f, -0.9f, 0f), new Vector2(-1f, -1f)),
// 				new Vertex(new Vector3(1.6f, -0.9f, 0f), new Vector2(1f, -1f)),
// 				new Vertex(new Vector3(1.6f, 0.9f, 0f), new Vector2(1f, 1f)),
// 				new Vertex(new Vector3(-1.6f, 0.9f, 0f), new Vector2(-1f, 1f))
// 			});
// 		}
//
// 		protected override void OnResize(EventArgs e)
// 		{
// 			GL.Viewport(0, 0, Width, Height);
//
// 			ImGuiController.WindowResized(Width, Height);
// 		}
//
// 		protected override unsafe void Draw()
// 		{
// 			const float radius = 10.0f;
// 			float camX = MathF.Sin(Time.TotalDrawTime) * radius;
// 			float camZ = MathF.Cos(Time.TotalDrawTime) * radius;
//
// 			GL.ClearColor(new Color4(40, 40, 40, 255));
// 			GL.Clear(ClearBufferMask.ColorBufferBit);
//
// 			GL.Enable(EnableCap.CullFace);
// 			GL.CullFace(CullFaceMode.Back);
// 			GL.FrontFace(FrontFaceDirection.Ccw);
//
// 			shader.Bind();
// 			buffer.Bind();
//
// 			lights[0].position.X = camX / radius * 0.5f;
// 			lights[0].position.Z = camZ / radius * 0.5f;
// 			GL.NamedBufferSubData(lightBuffer, IntPtr.Zero, lights.Length * sizeof(Light), lights);
//
// 			float ratio = (float)Width / Height;
// 			Matrix4 projection = Matrix4.CreatePerspectiveOffCenter(-ratio, ratio, -1f, 1f, 1.0f, 40.0f);
//
// 			Vector3 camera = new Vector3(camX, 3f, camZ);
// 			// Vector3 camera = new Vector3(3f, 3f, 3f);
// 			Matrix4 view = Matrix4.LookAt(camera, Vector3.Zero, Vector3.UnitY);
//
// 			shader.UploadUniformMat4("u_CameraToWorld", view.Inverted());
// 			shader.UploadUniformMat4("u_CameraInverseProjection", projection.Inverted());
// 			shader.UploadUniformMat4("u_ModelMatrix", Matrix4.Identity);
// 			shader.UploadUniformMat4("u_ViewProjection", matrix);
// 			shader.UploadUniformFloat("u_Time", Time.TotalDrawTime);
// 			shader.UploadUniformInt("u_LightCount", lights.Length);
// 			shader.UploadUniformFloat("u_Test", shadowSpread);
//
// 			shader.UploadUniformFloat4("u_Color", Color4.CornflowerBlue);
//
// 			GL.DrawArrays(PrimitiveType.Quads, 0, 4);
//
// 			shader.Unbind();
// 			buffer.Unbind();
//
// 			ImGuiController.Update(this, Time.DeltaDrawTime);
//
// 			ImGui.Begin("Debug");
// 			ImGui.Text($"FPS: {1 / frameTime:N1}");
//
// 			ImGui.Separator();
//
// 			ImGui.SliderFloat("Shadow Spread", ref shadowSpread, 10f, 50f);
//
// 			ImGui.End();
//
// 			ImGuiController.Render();
//
// 			SwapBuffers();
// 		}
// 	}
// }