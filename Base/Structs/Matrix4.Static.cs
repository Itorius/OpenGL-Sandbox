using System;

namespace Base
{
	public partial struct Matrix4
	{
		/// <summary>
		///     Build a rotation matrix from the specified axis/angle rotation.
		/// </summary>
		/// <param name="axis">The axis to rotate about.</param>
		/// <param name="angle">Angle in radians to rotate counter-clockwise (looking in the direction of the given axis).</param>
		/// <returns>A matrix instance.</returns>
		public static Matrix4 CreateFromAxisAngle(Vector3 axis, float angle)
		{
			CreateFromAxisAngle(axis, angle, out Matrix4 result);
			return result;
		}

		/// <summary>Builds a rotation matrix from a quaternion.</summary>
		/// <param name="q">The quaternion to rotate by.</param>
		/// <param name="result">A matrix instance.</param>
		public static void CreateFromQuaternion(ref Quaternion q, out Matrix4 result)
		{
			q.ToAxisAngle(out Vector3 axis, out float angle);
			CreateFromAxisAngle(axis, angle, out result);
		}

		/// <summary>Builds a rotation matrix from a quaternion.</summary>
		/// <param name="q">The quaternion to rotate by.</param>
		/// <returns>A matrix instance.</returns>
		public static Matrix4 CreateFromQuaternion(Quaternion q)
		{
			CreateFromQuaternion(ref q, out Matrix4 result);
			return result;
		}

		/// <summary>
		///     Builds a rotation matrix for a rotation around the x-axis.
		/// </summary>
		/// <param name="angle">The counter-clockwise angle in radians.</param>
		/// <param name="result">The resulting Matrix4 instance.</param>
		public static void CreateRotationX(float angle, out Matrix4 result)
		{
			float num1 = MathF.Cos(angle);
			float num2 = MathF.Sin(angle);
			result = Identity;
			result.Row1.Y = num1;
			result.Row1.Z = num2;
			result.Row2.Y = -num2;
			result.Row2.Z = num1;
		}

		/// <summary>
		///     Builds a rotation matrix for a rotation around the x-axis.
		/// </summary>
		/// <param name="angle">The counter-clockwise angle in radians.</param>
		/// <returns>The resulting Matrix4 instance.</returns>
		public static Matrix4 CreateRotationX(float angle)
		{
			CreateRotationX(angle, out Matrix4 result);
			return result;
		}

		/// <summary>
		///     Builds a rotation matrix for a rotation around the y-axis.
		/// </summary>
		/// <param name="angle">The counter-clockwise angle in radians.</param>
		/// <param name="result">The resulting Matrix4 instance.</param>
		public static void CreateRotationY(float angle, out Matrix4 result)
		{
			float num1 = MathF.Cos(angle);
			float num2 = MathF.Sin(angle);
			result = Identity;
			result.Row0.X = num1;
			result.Row0.Z = -num2;
			result.Row2.X = num2;
			result.Row2.Z = num1;
		}

		/// <summary>
		///     Builds a rotation matrix for a rotation around the y-axis.
		/// </summary>
		/// <param name="angle">The counter-clockwise angle in radians.</param>
		/// <returns>The resulting Matrix4 instance.</returns>
		public static Matrix4 CreateRotationY(float angle)
		{
			CreateRotationY(angle, out Matrix4 result);
			return result;
		}

		/// <summary>
		///     Builds a rotation matrix for a rotation around the z-axis.
		/// </summary>
		/// <param name="angle">The counter-clockwise angle in radians.</param>
		/// <param name="result">The resulting Matrix4 instance.</param>
		public static void CreateRotationZ(float angle, out Matrix4 result)
		{
			float num1 = MathF.Cos(angle);
			float num2 = MathF.Sin(angle);
			result = Identity;
			result.Row0.X = num1;
			result.Row0.Y = num2;
			result.Row1.X = -num2;
			result.Row1.Y = num1;
		}

		/// <summary>
		///     Builds a rotation matrix for a rotation around the z-axis.
		/// </summary>
		/// <param name="angle">The counter-clockwise angle in radians.</param>
		/// <returns>The resulting Matrix4 instance.</returns>
		public static Matrix4 CreateRotationZ(float angle)
		{
			CreateRotationZ(angle, out Matrix4 result);
			return result;
		}

		/// <summary>Creates a translation matrix.</summary>
		/// <param name="x">X translation.</param>
		/// <param name="y">Y translation.</param>
		/// <param name="z">Z translation.</param>
		/// <param name="result">The resulting Matrix4 instance.</param>
		public static void CreateTranslation(float x, float y, float z, out Matrix4 result)
		{
			result = Identity;
			result.Row3.X = x;
			result.Row3.Y = y;
			result.Row3.Z = z;
		}

		/// <summary>Creates a translation matrix.</summary>
		/// <param name="vector">The translation vector.</param>
		/// <param name="result">The resulting Matrix4 instance.</param>
		public static void CreateTranslation(ref Vector3 vector, out Matrix4 result)
		{
			result = Identity;
			result.Row3.X = vector.X;
			result.Row3.Y = vector.Y;
			result.Row3.Z = vector.Z;
		}

		/// <summary>Creates a translation matrix.</summary>
		/// <param name="x">X translation.</param>
		/// <param name="y">Y translation.</param>
		/// <param name="z">Z translation.</param>
		/// <returns>The resulting Matrix4 instance.</returns>
		public static Matrix4 CreateTranslation(float x, float y, float z)
		{
			CreateTranslation(x, y, z, out Matrix4 result);
			return result;
		}

		/// <summary>Creates a translation matrix.</summary>
		/// <param name="vector">The translation vector.</param>
		/// <returns>The resulting Matrix4 instance.</returns>
		public static Matrix4 CreateTranslation(Vector3 vector)
		{
			CreateTranslation(vector.X, vector.Y, vector.Z, out Matrix4 result);
			return result;
		}

		/// <summary>Creates a scale matrix.</summary>
		/// <param name="scale">Single scale factor for the x, y, and z axes.</param>
		/// <returns>A scale matrix.</returns>
		public static Matrix4 CreateScale(float scale)
		{
			CreateScale(scale, out Matrix4 result);
			return result;
		}

		/// <summary>Creates a scale matrix.</summary>
		/// <param name="scale">Scale factors for the x, y, and z axes.</param>
		/// <returns>A scale matrix.</returns>
		public static Matrix4 CreateScale(Vector3 scale)
		{
			CreateScale(ref scale, out Matrix4 result);
			return result;
		}

		/// <summary>Creates a scale matrix.</summary>
		/// <param name="x">Scale factor for the x axis.</param>
		/// <param name="y">Scale factor for the y axis.</param>
		/// <param name="z">Scale factor for the z axis.</param>
		/// <returns>A scale matrix.</returns>
		public static Matrix4 CreateScale(float x, float y, float z)
		{
			CreateScale(x, y, z, out Matrix4 result);
			return result;
		}

		/// <summary>Creates a scale matrix.</summary>
		/// <param name="scale">Single scale factor for the x, y, and z axes.</param>
		/// <param name="result">A scale matrix.</param>
		public static void CreateScale(float scale, out Matrix4 result)
		{
			result = Identity;
			result.Row0.X = scale;
			result.Row1.Y = scale;
			result.Row2.Z = scale;
		}

		/// <summary>Creates a scale matrix.</summary>
		/// <param name="scale">Scale factors for the x, y, and z axes.</param>
		/// <param name="result">A scale matrix.</param>
		public static void CreateScale(ref Vector3 scale, out Matrix4 result)
		{
			result = Identity;
			result.Row0.X = scale.X;
			result.Row1.Y = scale.Y;
			result.Row2.Z = scale.Z;
		}

		/// <summary>Creates a scale matrix.</summary>
		/// <param name="x">Scale factor for the x axis.</param>
		/// <param name="y">Scale factor for the y axis.</param>
		/// <param name="z">Scale factor for the z axis.</param>
		/// <param name="result">A scale matrix.</param>
		public static void CreateScale(float x, float y, float z, out Matrix4 result)
		{
			result = Identity;
			result.Row0.X = x;
			result.Row1.Y = y;
			result.Row2.Z = z;
		}

		/// <summary>Creates an orthographic projection matrix.</summary>
		/// <param name="width">The width of the projection volume.</param>
		/// <param name="height">The height of the projection volume.</param>
		/// <param name="zNear">The near edge of the projection volume.</param>
		/// <param name="zFar">The far edge of the projection volume.</param>
		/// <param name="result">The resulting Matrix4 instance.</param>
		public static void CreateOrthographic(float width, float height, float zNear, float zFar, out Matrix4 result)
		{
			CreateOrthographicOffCenter((float)(-width / 2.0), width / 2f, (float)(-height / 2.0), height / 2f, zNear, zFar, out result);
		}

		/// <summary>Creates an orthographic projection matrix.</summary>
		/// <param name="width">The width of the projection volume.</param>
		/// <param name="height">The height of the projection volume.</param>
		/// <param name="zNear">The near edge of the projection volume.</param>
		/// <param name="zFar">The far edge of the projection volume.</param>
		/// <rereturns>The resulting Matrix4 instance.</rereturns>
		public static Matrix4 CreateOrthographic(float width, float height, float zNear, float zFar)
		{
			CreateOrthographicOffCenter((float)(-width / 2.0), width / 2f, (float)(-height / 2.0), height / 2f, zNear, zFar, out Matrix4 result);
			return result;
		}

		/// <summary>Creates an orthographic projection matrix.</summary>
		/// <param name="left">The left edge of the projection volume.</param>
		/// <param name="right">The right edge of the projection volume.</param>
		/// <param name="bottom">The bottom edge of the projection volume.</param>
		/// <param name="top">The top edge of the projection volume.</param>
		/// <param name="zNear">The near edge of the projection volume.</param>
		/// <param name="zFar">The far edge of the projection volume.</param>
		/// <param name="result">The resulting Matrix4 instance.</param>
		public static void CreateOrthographicOffCenter(float left, float right, float bottom, float top, float zNear, float zFar, out Matrix4 result)
		{
			result = Identity;
			float num1 = (float)(1.0 / (right - left));
			float num2 = (float)(1.0 / (top - bottom));
			float num3 = (float)(1.0 / (zFar - zNear));
			result.Row0.X = 2f * num1;
			result.Row1.Y = 2f * num2;
			result.Row2.Z = -2f * num3;
			result.Row3.X = -(right + left) * num1;
			result.Row3.Y = -(top + bottom) * num2;
			result.Row3.Z = -(zFar + zNear) * num3;
		}

		/// <summary>Creates an orthographic projection matrix.</summary>
		/// <param name="left">The left edge of the projection volume.</param>
		/// <param name="right">The right edge of the projection volume.</param>
		/// <param name="bottom">The bottom edge of the projection volume.</param>
		/// <param name="top">The top edge of the projection volume.</param>
		/// <param name="zNear">The near edge of the projection volume.</param>
		/// <param name="zFar">The far edge of the projection volume.</param>
		/// <returns>The resulting Matrix4 instance.</returns>
		public static Matrix4 CreateOrthographicOffCenter(float left, float right, float bottom, float top, float zNear, float zFar)
		{
			CreateOrthographicOffCenter(left, right, bottom, top, zNear, zFar, out Matrix4 result);
			return result;
		}

		/// <summary>Creates a perspective projection matrix.</summary>
		/// <param name="fovy">Angle of the field of view in the y direction (in radians)</param>
		/// <param name="aspect">Aspect ratio of the view (width / height)</param>
		/// <param name="zNear">Distance to the near clip plane</param>
		/// <param name="zFar">Distance to the far clip plane</param>
		/// <param name="result">A projection matrix that transforms camera space to raster space</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///     Thrown under the following conditions:
		///     <list type="bullet">
		///         <item>fovy is zero, less than zero or larger than MathF.PI</item>
		///         <item>aspect is negative or zero</item>
		///         <item>zNear is negative or zero</item>
		///         <item>zFar is negative or zero</item>
		///         <item>zNear is larger than zFar</item>
		///     </list>
		/// </exception>
		public static void CreatePerspectiveFieldOfView(float fovy, float aspect, float zNear, float zFar, out Matrix4 result)
		{
			if (fovy <= 0.0 || fovy > MathF.PI) throw new ArgumentOutOfRangeException(nameof(fovy));
			if (aspect <= 0.0) throw new ArgumentOutOfRangeException(nameof(aspect));
			if (zNear <= 0.0) throw new ArgumentOutOfRangeException(nameof(zNear));
			if (zFar <= 0.0) throw new ArgumentOutOfRangeException(nameof(zFar));
			float top = zNear * MathF.Tan(0.5f * fovy);
			float bottom = -top;
			CreatePerspectiveOffCenter(bottom * aspect, top * aspect, bottom, top, zNear, zFar, out result);
		}

		/// <summary>Creates a perspective projection matrix.</summary>
		/// <param name="fovy">Angle of the field of view in the y direction (in radians)</param>
		/// <param name="aspect">Aspect ratio of the view (width / height)</param>
		/// <param name="zNear">Distance to the near clip plane</param>
		/// <param name="zFar">Distance to the far clip plane</param>
		/// <returns>A projection matrix that transforms camera space to raster space</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///     Thrown under the following conditions:
		///     <list type="bullet">
		///         <item>fovy is zero, less than zero or larger than MathF.PI</item>
		///         <item>aspect is negative or zero</item>
		///         <item>zNear is negative or zero</item>
		///         <item>zFar is negative or zero</item>
		///         <item>zNear is larger than zFar</item>
		///     </list>
		/// </exception>
		public static Matrix4 CreatePerspectiveFieldOfView(float fovy, float aspect, float zNear, float zFar)
		{
			CreatePerspectiveFieldOfView(fovy, aspect, zNear, zFar, out Matrix4 result);
			return result;
		}

		/// <summary>Creates an perspective projection matrix.</summary>
		/// <param name="left">Left edge of the view frustum</param>
		/// <param name="right">Right edge of the view frustum</param>
		/// <param name="bottom">Bottom edge of the view frustum</param>
		/// <param name="top">Top edge of the view frustum</param>
		/// <param name="zNear">Distance to the near clip plane</param>
		/// <param name="zFar">Distance to the far clip plane</param>
		/// <param name="result">A projection matrix that transforms camera space to raster space</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///     Thrown under the following conditions:
		///     <list type="bullet">
		///         <item>zNear is negative or zero</item>
		///         <item>zFar is negative or zero</item>
		///         <item>zNear is larger than zFar</item>
		///     </list>
		/// </exception>
		public static void CreatePerspectiveOffCenter(float left, float right, float bottom, float top, float zNear, float zFar, out Matrix4 result)
		{
			if (zNear <= 0.0) throw new ArgumentOutOfRangeException(nameof(zNear));
			if (zFar <= 0.0) throw new ArgumentOutOfRangeException(nameof(zFar));
			if (zNear >= zFar) throw new ArgumentOutOfRangeException(nameof(zNear));
			float num1 = (float)(2.0 * zNear / (right - left));
			float num2 = (float)(2.0 * zNear / (top - bottom));
			float num3 = (right + left) / (right - left);
			float num4 = (top + bottom) / (top - bottom);
			float num5 = -(zFar + zNear) / (zFar - zNear);
			float num6 = (float)(-(2.0 * zFar * zNear) / (zFar - zNear));
			result.Row0.X = num1;
			result.Row0.Y = 0.0f;
			result.Row0.Z = 0.0f;
			result.Row0.W = 0.0f;
			result.Row1.X = 0.0f;
			result.Row1.Y = num2;
			result.Row1.Z = 0.0f;
			result.Row1.W = 0.0f;
			result.Row2.X = num3;
			result.Row2.Y = num4;
			result.Row2.Z = num5;
			result.Row2.W = -1f;
			result.Row3.X = 0.0f;
			result.Row3.Y = 0.0f;
			result.Row3.Z = num6;
			result.Row3.W = 0.0f;
		}

		/// <summary>Creates an perspective projection matrix.</summary>
		/// <param name="left">Left edge of the view frustum</param>
		/// <param name="right">Right edge of the view frustum</param>
		/// <param name="bottom">Bottom edge of the view frustum</param>
		/// <param name="top">Top edge of the view frustum</param>
		/// <param name="zNear">Distance to the near clip plane</param>
		/// <param name="zFar">Distance to the far clip plane</param>
		/// <returns>A projection matrix that transforms camera space to raster space</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///     Thrown under the following conditions:
		///     <list type="bullet">
		///         <item>zNear is negative or zero</item>
		///         <item>zFar is negative or zero</item>
		///         <item>zNear is larger than zFar</item>
		///     </list>
		/// </exception>
		public static Matrix4 CreatePerspectiveOffCenter(float left, float right, float bottom, float top, float zNear, float zFar)
		{
			CreatePerspectiveOffCenter(left, right, bottom, top, zNear, zFar, out Matrix4 result);
			return result;
		}

		/// <summary>Build a world space to camera space matrix</summary>
		/// <param name="eye">Eye (camera) position in world space</param>
		/// <param name="target">Target position in world space</param>
		/// <param name="up">Up vector in world space (should not be parallel to the camera direction, that is target - eye)</param>
		/// <returns>A Matrix4 that transforms world space to camera space</returns>
		public static Matrix4 LookAt(Vector3 eye, Vector3 target, Vector3 up)
		{
			Vector3 vector3_1 = Vector3.Normalize(eye - target);
			Vector3 right = Vector3.Normalize(Vector3.Cross(up, vector3_1));
			Vector3 vector3_2 = Vector3.Normalize(Vector3.Cross(vector3_1, right));
			Matrix4 matrix4;
			matrix4.Row0.X = right.X;
			matrix4.Row0.Y = vector3_2.X;
			matrix4.Row0.Z = vector3_1.X;
			matrix4.Row0.W = 0.0f;
			matrix4.Row1.X = right.Y;
			matrix4.Row1.Y = vector3_2.Y;
			matrix4.Row1.Z = vector3_1.Y;
			matrix4.Row1.W = 0.0f;
			matrix4.Row2.X = right.Z;
			matrix4.Row2.Y = vector3_2.Z;
			matrix4.Row2.Z = vector3_1.Z;
			matrix4.Row2.W = 0.0f;
			matrix4.Row3.X = -(right.X * eye.X + right.Y * eye.Y + right.Z * eye.Z);
			matrix4.Row3.Y = -(vector3_2.X * eye.X + vector3_2.Y * eye.Y + vector3_2.Z * eye.Z);
			matrix4.Row3.Z = -(vector3_1.X * eye.X + vector3_1.Y * eye.Y + vector3_1.Z * eye.Z);
			matrix4.Row3.W = 1f;
			return matrix4;
		}

		/// <summary>Build a world space to camera space matrix</summary>
		/// <param name="eyeX">Eye (camera) position in world space</param>
		/// <param name="eyeY">Eye (camera) position in world space</param>
		/// <param name="eyeZ">Eye (camera) position in world space</param>
		/// <param name="targetX">Target position in world space</param>
		/// <param name="targetY">Target position in world space</param>
		/// <param name="targetZ">Target position in world space</param>
		/// <param name="upX">Up vector in world space (should not be parallel to the camera direction, that is target - eye)</param>
		/// <param name="upY">Up vector in world space (should not be parallel to the camera direction, that is target - eye)</param>
		/// <param name="upZ">Up vector in world space (should not be parallel to the camera direction, that is target - eye)</param>
		/// <returns>A Matrix4 that transforms world space to camera space</returns>
		public static Matrix4 LookAt(
			float eyeX,
			float eyeY,
			float eyeZ,
			float targetX,
			float targetY,
			float targetZ,
			float upX,
			float upY,
			float upZ)
		{
			return LookAt(new Vector3(eyeX, eyeY, eyeZ), new Vector3(targetX, targetY, targetZ), new Vector3(upX, upY, upZ));
		}

		/// <summary>Adds two instances.</summary>
		/// <param name="left">The left operand of the addition.</param>
		/// <param name="right">The right operand of the addition.</param>
		/// <returns>A new instance that is the result of the addition.</returns>
		public static Matrix4 Add(Matrix4 left, Matrix4 right)
		{
			Add(ref left, ref right, out Matrix4 result);
			return result;
		}

		/// <summary>Adds two instances.</summary>
		/// <param name="left">The left operand of the addition.</param>
		/// <param name="right">The right operand of the addition.</param>
		/// <param name="result">A new instance that is the result of the addition.</param>
		public static void Add(ref Matrix4 left, ref Matrix4 right, out Matrix4 result)
		{
			result.Row0 = left.Row0 + right.Row0;
			result.Row1 = left.Row1 + right.Row1;
			result.Row2 = left.Row2 + right.Row2;
			result.Row3 = left.Row3 + right.Row3;
		}

		/// <summary>Subtracts one instance from another.</summary>
		/// <param name="left">The left operand of the subraction.</param>
		/// <param name="right">The right operand of the subraction.</param>
		/// <returns>A new instance that is the result of the subraction.</returns>
		public static Matrix4 Subtract(Matrix4 left, Matrix4 right)
		{
			Subtract(ref left, ref right, out Matrix4 result);
			return result;
		}

		/// <summary>Subtracts one instance from another.</summary>
		/// <param name="left">The left operand of the subraction.</param>
		/// <param name="right">The right operand of the subraction.</param>
		/// <param name="result">A new instance that is the result of the subraction.</param>
		public static void Subtract(ref Matrix4 left, ref Matrix4 right, out Matrix4 result)
		{
			result.Row0 = left.Row0 - right.Row0;
			result.Row1 = left.Row1 - right.Row1;
			result.Row2 = left.Row2 - right.Row2;
			result.Row3 = left.Row3 - right.Row3;
		}

		/// <summary>Multiplies two instances.</summary>
		/// <param name="left">The left operand of the multiplication.</param>
		/// <param name="right">The right operand of the multiplication.</param>
		/// <returns>A new instance that is the result of the multiplication.</returns>
		public static Matrix4 Mult(Matrix4 left, Matrix4 right)
		{
			Mult(ref left, ref right, out Matrix4 result);
			return result;
		}

		/// <summary>Multiplies two instances.</summary>
		/// <param name="left">The left operand of the multiplication.</param>
		/// <param name="right">The right operand of the multiplication.</param>
		/// <param name="result">A new instance that is the result of the multiplication.</param>
		public static void Mult(ref Matrix4 left, ref Matrix4 right, out Matrix4 result)
		{
			float x1 = left.Row0.X;
			float y1 = left.Row0.Y;
			float z1 = left.Row0.Z;
			float w1 = left.Row0.W;
			float x2 = left.Row1.X;
			float y2 = left.Row1.Y;
			float z2 = left.Row1.Z;
			float w2 = left.Row1.W;
			float x3 = left.Row2.X;
			float y3 = left.Row2.Y;
			float z3 = left.Row2.Z;
			float w3 = left.Row2.W;
			float x4 = left.Row3.X;
			float y4 = left.Row3.Y;
			float z4 = left.Row3.Z;
			float w4 = left.Row3.W;
			float x5 = right.Row0.X;
			float y5 = right.Row0.Y;
			float z5 = right.Row0.Z;
			float w5 = right.Row0.W;
			float x6 = right.Row1.X;
			float y6 = right.Row1.Y;
			float z6 = right.Row1.Z;
			float w6 = right.Row1.W;
			float x7 = right.Row2.X;
			float y7 = right.Row2.Y;
			float z7 = right.Row2.Z;
			float w7 = right.Row2.W;
			float x8 = right.Row3.X;
			float y8 = right.Row3.Y;
			float z8 = right.Row3.Z;
			float w8 = right.Row3.W;
			result.Row0.X = x1 * x5 + y1 * x6 + z1 * x7 + w1 * x8;
			result.Row0.Y = x1 * y5 + y1 * y6 + z1 * y7 + w1 * y8;
			result.Row0.Z = x1 * z5 + y1 * z6 + z1 * z7 + w1 * z8;
			result.Row0.W = x1 * w5 + y1 * w6 + z1 * w7 + w1 * w8;
			result.Row1.X = x2 * x5 + y2 * x6 + z2 * x7 + w2 * x8;
			result.Row1.Y = x2 * y5 + y2 * y6 + z2 * y7 + w2 * y8;
			result.Row1.Z = x2 * z5 + y2 * z6 + z2 * z7 + w2 * z8;
			result.Row1.W = x2 * w5 + y2 * w6 + z2 * w7 + w2 * w8;
			result.Row2.X = x3 * x5 + y3 * x6 + z3 * x7 + w3 * x8;
			result.Row2.Y = x3 * y5 + y3 * y6 + z3 * y7 + w3 * y8;
			result.Row2.Z = x3 * z5 + y3 * z6 + z3 * z7 + w3 * z8;
			result.Row2.W = x3 * w5 + y3 * w6 + z3 * w7 + w3 * w8;
			result.Row3.X = x4 * x5 + y4 * x6 + z4 * x7 + w4 * x8;
			result.Row3.Y = x4 * y5 + y4 * y6 + z4 * y7 + w4 * y8;
			result.Row3.Z = x4 * z5 + y4 * z6 + z4 * z7 + w4 * z8;
			result.Row3.W = x4 * w5 + y4 * w6 + z4 * w7 + w4 * w8;
		}

		/// <summary>Multiplies an instance by a scalar.</summary>
		/// <param name="left">The left operand of the multiplication.</param>
		/// <param name="right">The right operand of the multiplication.</param>
		/// <returns>A new instance that is the result of the multiplication</returns>
		public static Matrix4 Mult(Matrix4 left, float right)
		{
			Mult(ref left, right, out Matrix4 result);
			return result;
		}

		/// <summary>Multiplies an instance by a scalar.</summary>
		/// <param name="left">The left operand of the multiplication.</param>
		/// <param name="right">The right operand of the multiplication.</param>
		/// <param name="result">A new instance that is the result of the multiplication</param>
		public static void Mult(ref Matrix4 left, float right, out Matrix4 result)
		{
			result.Row0 = left.Row0 * right;
			result.Row1 = left.Row1 * right;
			result.Row2 = left.Row2 * right;
			result.Row3 = left.Row3 * right;
		}

		/// <summary>Calculate the inverse of the given matrix</summary>
		/// <param name="mat">The matrix to invert</param>
		/// <param name="result">The inverse of the given matrix if it has one, or the input if it is singular</param>
		/// <exception cref="T:System.InvalidOperationException">Thrown if the Matrix4 is singular.</exception>
		public static unsafe void Invert(ref Matrix4 mat, out Matrix4 result)
		{
			result = mat;
			float* numPtr1 = stackalloc float[16];
			fixed (Matrix4* matrix4Ptr1 = &mat)
			fixed (Matrix4* matrix4Ptr2 = &result)
			{
				float* numPtr2 = (float*)matrix4Ptr1;
				float* numPtr3 = (float*)matrix4Ptr2;
				numPtr1[0] = numPtr2[5] * numPtr2[10] * numPtr2[15] - numPtr2[5] * numPtr2[11] * numPtr2[14] - numPtr2[9] * numPtr2[6] * numPtr2[15] + numPtr2[9] * numPtr2[7] * numPtr2[14] + numPtr2[13] * numPtr2[6] * numPtr2[11] - numPtr2[13] * numPtr2[7] * numPtr2[10];
				numPtr1[4] = -numPtr2[4] * numPtr2[10] * numPtr2[15] + numPtr2[4] * numPtr2[11] * numPtr2[14] + numPtr2[8] * numPtr2[6] * numPtr2[15] - numPtr2[8] * numPtr2[7] * numPtr2[14] - numPtr2[12] * numPtr2[6] * numPtr2[11] + numPtr2[12] * numPtr2[7] * numPtr2[10];
				numPtr1[8] = numPtr2[4] * numPtr2[9] * numPtr2[15] - numPtr2[4] * numPtr2[11] * numPtr2[13] - numPtr2[8] * numPtr2[5] * numPtr2[15] + numPtr2[8] * numPtr2[7] * numPtr2[13] + numPtr2[12] * numPtr2[5] * numPtr2[11] - numPtr2[12] * numPtr2[7] * numPtr2[9];
				numPtr1[12] = -numPtr2[4] * numPtr2[9] * numPtr2[14] + numPtr2[4] * numPtr2[10] * numPtr2[13] + numPtr2[8] * numPtr2[5] * numPtr2[14] - numPtr2[8] * numPtr2[6] * numPtr2[13] - numPtr2[12] * numPtr2[5] * numPtr2[10] + numPtr2[12] * numPtr2[6] * numPtr2[9];
				numPtr1[1] = -numPtr2[1] * numPtr2[10] * numPtr2[15] + numPtr2[1] * numPtr2[11] * numPtr2[14] + numPtr2[9] * numPtr2[2] * numPtr2[15] - numPtr2[9] * numPtr2[3] * numPtr2[14] - numPtr2[13] * numPtr2[2] * numPtr2[11] + numPtr2[13] * numPtr2[3] * numPtr2[10];
				numPtr1[5] = *numPtr2 * numPtr2[10] * numPtr2[15] - *numPtr2 * numPtr2[11] * numPtr2[14] - numPtr2[8] * numPtr2[2] * numPtr2[15] + numPtr2[8] * numPtr2[3] * numPtr2[14] + numPtr2[12] * numPtr2[2] * numPtr2[11] - numPtr2[12] * numPtr2[3] * numPtr2[10];
				numPtr1[9] = -*numPtr2 * numPtr2[9] * numPtr2[15] + *numPtr2 * numPtr2[11] * numPtr2[13] + numPtr2[8] * numPtr2[1] * numPtr2[15] - numPtr2[8] * numPtr2[3] * numPtr2[13] - numPtr2[12] * numPtr2[1] * numPtr2[11] + numPtr2[12] * numPtr2[3] * numPtr2[9];
				numPtr1[13] = *numPtr2 * numPtr2[9] * numPtr2[14] - *numPtr2 * numPtr2[10] * numPtr2[13] - numPtr2[8] * numPtr2[1] * numPtr2[14] + numPtr2[8] * numPtr2[2] * numPtr2[13] + numPtr2[12] * numPtr2[1] * numPtr2[10] - numPtr2[12] * numPtr2[2] * numPtr2[9];
				numPtr1[2] = numPtr2[1] * numPtr2[6] * numPtr2[15] - numPtr2[1] * numPtr2[7] * numPtr2[14] - numPtr2[5] * numPtr2[2] * numPtr2[15] + numPtr2[5] * numPtr2[3] * numPtr2[14] + numPtr2[13] * numPtr2[2] * numPtr2[7] - numPtr2[13] * numPtr2[3] * numPtr2[6];
				numPtr1[6] = -*numPtr2 * numPtr2[6] * numPtr2[15] + *numPtr2 * numPtr2[7] * numPtr2[14] + numPtr2[4] * numPtr2[2] * numPtr2[15] - numPtr2[4] * numPtr2[3] * numPtr2[14] - numPtr2[12] * numPtr2[2] * numPtr2[7] + numPtr2[12] * numPtr2[3] * numPtr2[6];
				numPtr1[10] = *numPtr2 * numPtr2[5] * numPtr2[15] - *numPtr2 * numPtr2[7] * numPtr2[13] - numPtr2[4] * numPtr2[1] * numPtr2[15] + numPtr2[4] * numPtr2[3] * numPtr2[13] + numPtr2[12] * numPtr2[1] * numPtr2[7] - numPtr2[12] * numPtr2[3] * numPtr2[5];
				numPtr1[14] = -*numPtr2 * numPtr2[5] * numPtr2[14] + *numPtr2 * numPtr2[6] * numPtr2[13] + numPtr2[4] * numPtr2[1] * numPtr2[14] - numPtr2[4] * numPtr2[2] * numPtr2[13] - numPtr2[12] * numPtr2[1] * numPtr2[6] + numPtr2[12] * numPtr2[2] * numPtr2[5];
				numPtr1[3] = -numPtr2[1] * numPtr2[6] * numPtr2[11] + numPtr2[1] * numPtr2[7] * numPtr2[10] + numPtr2[5] * numPtr2[2] * numPtr2[11] - numPtr2[5] * numPtr2[3] * numPtr2[10] - numPtr2[9] * numPtr2[2] * numPtr2[7] + numPtr2[9] * numPtr2[3] * numPtr2[6];
				numPtr1[7] = *numPtr2 * numPtr2[6] * numPtr2[11] - *numPtr2 * numPtr2[7] * numPtr2[10] - numPtr2[4] * numPtr2[2] * numPtr2[11] + numPtr2[4] * numPtr2[3] * numPtr2[10] + numPtr2[8] * numPtr2[2] * numPtr2[7] - numPtr2[8] * numPtr2[3] * numPtr2[6];
				numPtr1[11] = -*numPtr2 * numPtr2[5] * numPtr2[11] + *numPtr2 * numPtr2[7] * numPtr2[9] + numPtr2[4] * numPtr2[1] * numPtr2[11] - numPtr2[4] * numPtr2[3] * numPtr2[9] - numPtr2[8] * numPtr2[1] * numPtr2[7] + numPtr2[8] * numPtr2[3] * numPtr2[5];
				numPtr1[15] = *numPtr2 * numPtr2[5] * numPtr2[10] - *numPtr2 * numPtr2[6] * numPtr2[9] - numPtr2[4] * numPtr2[1] * numPtr2[10] + numPtr2[4] * numPtr2[2] * numPtr2[9] + numPtr2[8] * numPtr2[1] * numPtr2[6] - numPtr2[8] * numPtr2[2] * numPtr2[5];
				float num1 = *numPtr2 * numPtr1[0] + numPtr2[1] * numPtr1[4] + numPtr2[2] * numPtr1[8] + numPtr2[3] * numPtr1[12];
				if (num1 == 0.0) throw new InvalidOperationException("Matrix is singular and cannot be inverted.");
				float num2 = 1f / num1;
				for (int index = 0; index < 16; ++index) numPtr3[index] = numPtr1[index] * num2;
			}
		}

		/// <summary>Calculate the inverse of the given matrix</summary>
		/// <param name="mat">The matrix to invert</param>
		/// <returns>The inverse of the given matrix if it has one, or the input if it is singular</returns>
		/// <exception cref="T:System.InvalidOperationException">Thrown if the Matrix4 is singular.</exception>
		public static Matrix4 Invert(Matrix4 mat)
		{
			Invert(ref mat, out Matrix4 result);
			return result;
		}

		/// <summary>Calculate the transpose of the given matrix</summary>
		/// <param name="mat">The matrix to transpose</param>
		/// <returns>The transpose of the given matrix</returns>
		public static Matrix4 Transpose(Matrix4 mat)
		{
			return new Matrix4(mat.Column0, mat.Column1, mat.Column2, mat.Column3);
		}

		/// <summary>Calculate the transpose of the given matrix</summary>
		/// <param name="mat">The matrix to transpose</param>
		/// <param name="result">The result of the calculation</param>
		public static void Transpose(ref Matrix4 mat, out Matrix4 result)
		{
			result.Row0 = mat.Column0;
			result.Row1 = mat.Column1;
			result.Row2 = mat.Column2;
			result.Row3 = mat.Column3;
		}
	}
}