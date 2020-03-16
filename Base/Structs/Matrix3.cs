using System;

namespace Base
{
	/// <summary>
	///     Represents a 3x3 matrix containing 3D rotation and scale.
	/// </summary>
	[Serializable]
	public struct Matrix3 : IEquatable<Matrix3>
	{
		/// <summary>The identity matrix.</summary>
		public static readonly Matrix3 Identity = new Matrix3(Vector3.UnitX, Vector3.UnitY, Vector3.UnitZ);

		/// <summary>The zero matrix.</summary>
		public static readonly Matrix3 Zero = new Matrix3(Vector3.Zero, Vector3.Zero, Vector3.Zero);

		/// <summary>First row of the matrix.</summary>
		public Vector3 Row0;

		/// <summary>Second row of the matrix.</summary>
		public Vector3 Row1;

		/// <summary>Third row of the matrix.</summary>
		public Vector3 Row2;

		/// <summary>Constructs a new instance.</summary>
		/// <param name="row0">Top row of the matrix</param>
		/// <param name="row1">Second row of the matrix</param>
		/// <param name="row2">Bottom row of the matrix</param>
		public Matrix3(Vector3 row0, Vector3 row1, Vector3 row2)
		{
			Row0 = row0;
			Row1 = row1;
			Row2 = row2;
		}

		public unsafe float* ToPointer()
		{
			fixed (float* ptr = &Row0.X)
			{
				return ptr;
			}
		}

		/// <summary>Constructs a new instance.</summary>
		/// <param name="m00">First item of the first row of the matrix.</param>
		/// <param name="m01">Second item of the first row of the matrix.</param>
		/// <param name="m02">Third item of the first row of the matrix.</param>
		/// <param name="m10">First item of the second row of the matrix.</param>
		/// <param name="m11">Second item of the second row of the matrix.</param>
		/// <param name="m12">Third item of the second row of the matrix.</param>
		/// <param name="m20">First item of the third row of the matrix.</param>
		/// <param name="m21">Second item of the third row of the matrix.</param>
		/// <param name="m22">Third item of the third row of the matrix.</param>
		public Matrix3(
			float m00,
			float m01,
			float m02,
			float m10,
			float m11,
			float m12,
			float m20,
			float m21,
			float m22)
		{
			Row0 = new Vector3(m00, m01, m02);
			Row1 = new Vector3(m10, m11, m12);
			Row2 = new Vector3(m20, m21, m22);
		}

		/// <summary>Constructs a new instance.</summary>
		/// <param name="matrix">A Matrix4 to take the upper-left 3x3 from.</param>
		public Matrix3(Matrix4 matrix)
		{
			Row0 = matrix.Row0.Xyz;
			Row1 = matrix.Row1.Xyz;
			Row2 = matrix.Row2.Xyz;
		}

		/// <summary>Gets the determinant of this matrix.</summary>
		public float Determinant
		{
			get
			{
				float x1 = Row0.X;
				float y1 = Row0.Y;
				float z1 = Row0.Z;
				float x2 = Row1.X;
				float y2 = Row1.Y;
				float z2 = Row1.Z;
				float x3 = Row2.X;
				float y3 = Row2.Y;
				float z3 = Row2.Z;
				return x1 * y2 * z3 + y1 * z2 * x3 + z1 * x2 * y3 - z1 * y2 * x3 - x1 * z2 * y3 - y1 * x2 * z3;
			}
		}

		/// <summary>Gets the first column of this matrix.</summary>
		public Vector3 Column0 => new Vector3(Row0.X, Row1.X, Row2.X);

		/// <summary>Gets the second column of this matrix.</summary>
		public Vector3 Column1 => new Vector3(Row0.Y, Row1.Y, Row2.Y);

		/// <summary>Gets the third column of this matrix.</summary>
		public Vector3 Column2 => new Vector3(Row0.Z, Row1.Z, Row2.Z);

		/// <summary>
		///     Gets or sets the value at row 1, column 1 of this instance.
		/// </summary>
		public float M11
		{
			get => Row0.X;
			set => Row0.X = value;
		}

		/// <summary>
		///     Gets or sets the value at row 1, column 2 of this instance.
		/// </summary>
		public float M12
		{
			get => Row0.Y;
			set => Row0.Y = value;
		}

		/// <summary>
		///     Gets or sets the value at row 1, column 3 of this instance.
		/// </summary>
		public float M13
		{
			get => Row0.Z;
			set => Row0.Z = value;
		}

		/// <summary>
		///     Gets or sets the value at row 2, column 1 of this instance.
		/// </summary>
		public float M21
		{
			get => Row1.X;
			set => Row1.X = value;
		}

		/// <summary>
		///     Gets or sets the value at row 2, column 2 of this instance.
		/// </summary>
		public float M22
		{
			get => Row1.Y;
			set => Row1.Y = value;
		}

		/// <summary>
		///     Gets or sets the value at row 2, column 3 of this instance.
		/// </summary>
		public float M23
		{
			get => Row1.Z;
			set => Row1.Z = value;
		}

		/// <summary>
		///     Gets or sets the value at row 3, column 1 of this instance.
		/// </summary>
		public float M31
		{
			get => Row2.X;
			set => Row2.X = value;
		}

		/// <summary>
		///     Gets or sets the value at row 3, column 2 of this instance.
		/// </summary>
		public float M32
		{
			get => Row2.Y;
			set => Row2.Y = value;
		}

		/// <summary>
		///     Gets or sets the value at row 3, column 3 of this instance.
		/// </summary>
		public float M33
		{
			get => Row2.Z;
			set => Row2.Z = value;
		}

		/// <summary>
		///     Gets or sets the values along the main diagonal of the matrix.
		/// </summary>
		public Vector3 Diagonal
		{
			get => new Vector3(Row0.X, Row1.Y, Row2.Z);
			set
			{
				Row0.X = value.X;
				Row1.Y = value.Y;
				Row2.Z = value.Z;
			}
		}

		/// <summary>
		///     Gets the trace of the matrix, the sum of the values along the diagonal.
		/// </summary>
		public float Trace => Row0.X + Row1.Y + Row2.Z;

		/// <summary>Gets or sets the value at a specified row and column.</summary>
		public float this[int rowIndex, int columnIndex]
		{
			get
			{
				switch (rowIndex)
				{
					case 0:
						return Row0[columnIndex];
					case 1:
						return Row1[columnIndex];
					case 2:
						return Row2[columnIndex];
					default:
						throw new IndexOutOfRangeException("You tried to access this matrix at: (" + rowIndex + ", " + columnIndex + ")");
				}
			}
			set
			{
				switch (rowIndex)
				{
					case 0:
						Row0[columnIndex] = value;
						break;
					case 1:
						Row1[columnIndex] = value;
						break;
					case 2:
						Row2[columnIndex] = value;
						break;
					default:
						throw new IndexOutOfRangeException("You tried to set this matrix at: (" + rowIndex + ", " + columnIndex + ")");
				}
			}
		}

		/// <summary>Converts this instance into its inverse.</summary>
		public void Invert()
		{
			this = Invert(this);
		}

		/// <summary>Converts this instance into its transpose.</summary>
		public void Transpose()
		{
			this = Transpose(this);
		}

		/// <summary>Returns a normalised copy of this instance.</summary>
		public Matrix3 Normalized()
		{
			Matrix3 matrix3 = this;
			matrix3.Normalize();
			return matrix3;
		}

		/// <summary>
		///     Divides each element in the Matrix by the <see cref="P:OpenTK.Matrix3.Determinant" />.
		/// </summary>
		public void Normalize()
		{
			float determinant = Determinant;
			Row0 /= determinant;
			Row1 /= determinant;
			Row2 /= determinant;
		}

		/// <summary>Returns an inverted copy of this instance.</summary>
		public Matrix3 Inverted()
		{
			Matrix3 matrix3 = this;
			if (matrix3.Determinant != 0.0) matrix3.Invert();
			return matrix3;
		}

		/// <summary>Returns a copy of this Matrix3 without scale.</summary>
		public Matrix3 ClearScale()
		{
			Matrix3 matrix3 = this;
			matrix3.Row0 = matrix3.Row0.Normalized();
			matrix3.Row1 = matrix3.Row1.Normalized();
			matrix3.Row2 = matrix3.Row2.Normalized();
			return matrix3;
		}

		/// <summary>Returns a copy of this Matrix3 without rotation.</summary>
		public Matrix3 ClearRotation()
		{
			Matrix3 matrix3 = this;
			matrix3.Row0 = new Vector3(matrix3.Row0.Length, 0.0f, 0.0f);
			matrix3.Row1 = new Vector3(0.0f, matrix3.Row1.Length, 0.0f);
			matrix3.Row2 = new Vector3(0.0f, 0.0f, matrix3.Row2.Length);
			return matrix3;
		}

		/// <summary>Returns the scale component of this instance.</summary>
		public Vector3 ExtractScale()
		{
			return new Vector3(Row0.Length, Row1.Length, Row2.Length);
		}

		/// <summary>
		///     Returns the rotation component of this instance. Quite slow.
		/// </summary>
		/// <param name="row_normalise">
		///     Whether the method should row-normalise (i.e. remove scale from) the Matrix. Pass false if
		///     you know it's already normalised.
		/// </param>
		public Quaternion ExtractRotation(bool row_normalise = true)
		{
			Vector3 vector3_1 = Row0;
			Vector3 vector3_2 = Row1;
			Vector3 vector3_3 = Row2;
			if (row_normalise)
			{
				vector3_1 = vector3_1.Normalized();
				vector3_2 = vector3_2.Normalized();
				vector3_3 = vector3_3.Normalized();
			}

			Quaternion quaternion = new Quaternion();
			float d = 0.25f * (vector3_1[0] + vector3_2[1] + vector3_3[2] + 1.0f);
			if (d > 0.0f)
			{
				float num1 = MathF.Sqrt(d);
				quaternion.W = num1;
				float num2 = 1.0f / (4.0f * num1);
				quaternion.X = (vector3_2[2] - vector3_3[1]) * num2;
				quaternion.Y = (vector3_3[0] - vector3_1[2]) * num2;
				quaternion.Z = (vector3_1[1] - vector3_2[0]) * num2;
			}
			else if (vector3_1[0] > vector3_2[1] && vector3_1[0] > vector3_3[2])
			{
				float num1 = 2.0f * MathF.Sqrt(1.0f + vector3_1[0] - vector3_2[1] - vector3_3[2]);
				quaternion.X = 0.25f * num1;
				float num2 = 1.0f / num1;
				quaternion.W = (vector3_3[1] - vector3_2[2]) * num2;
				quaternion.Y = (vector3_2[0] + vector3_1[1]) * num2;
				quaternion.Z = (vector3_3[0] + vector3_1[2]) * num2;
			}
			else if (vector3_2[1] > vector3_3[2])
			{
				float num1 = 2.0f * MathF.Sqrt(1.0f + vector3_2[1] - vector3_1[0] - vector3_3[2]);
				quaternion.Y = 0.25f * num1;
				float num2 = 1.0f / num1;
				quaternion.W = (vector3_3[0] - vector3_1[2]) * num2;
				quaternion.X = (vector3_2[0] + vector3_1[1]) * num2;
				quaternion.Z = (vector3_3[1] + vector3_2[2]) * num2;
			}
			else
			{
				float num1 = 2.0f * MathF.Sqrt(1.0f + vector3_3[2] - vector3_1[0] - vector3_2[1]);
				quaternion.Z = 0.25f * num1;
				float num2 = 1.0f / num1;
				quaternion.W = (vector3_2[0] - vector3_1[1]) * num2;
				quaternion.X = (vector3_3[0] + vector3_1[2]) * num2;
				quaternion.Y = (vector3_3[1] + vector3_2[2]) * num2;
			}

			quaternion.Normalize();
			return quaternion;
		}

		/// <summary>
		///     Build a rotation matrix from the specified axis/angle rotation.
		/// </summary>
		/// <param name="axis">The axis to rotate about.</param>
		/// <param name="angle">Angle in radians to rotate counter-clockwise (looking in the direction of the given axis).</param>
		/// <param name="result">A matrix instance.</param>
		public static void CreateFromAxisAngle(Vector3 axis, float angle, out Matrix3 result)
		{
			axis.Normalize();
			float x = axis.X;
			float y = axis.Y;
			float z = axis.Z;
			float num1 = MathF.Cos(-angle);
			float num2 = MathF.Sin(-angle);
			float num3 = 1f - num1;
			float num4 = num3 * x * x;
			float num5 = num3 * x * y;
			float num6 = num3 * x * z;
			float num7 = num3 * y * y;
			float num8 = num3 * y * z;
			float num9 = num3 * z * z;
			float num10 = num2 * x;
			float num11 = num2 * y;
			float num12 = num2 * z;
			result.Row0.X = num4 + num1;
			result.Row0.Y = num5 - num12;
			result.Row0.Z = num6 + num11;
			result.Row1.X = num5 + num12;
			result.Row1.Y = num7 + num1;
			result.Row1.Z = num8 - num10;
			result.Row2.X = num6 - num11;
			result.Row2.Y = num8 + num10;
			result.Row2.Z = num9 + num1;
		}

		/// <summary>
		///     Build a rotation matrix from the specified axis/angle rotation.
		/// </summary>
		/// <param name="axis">The axis to rotate about.</param>
		/// <param name="angle">Angle in radians to rotate counter-clockwise (looking in the direction of the given axis).</param>
		/// <returns>A matrix instance.</returns>
		public static Matrix3 CreateFromAxisAngle(Vector3 axis, float angle)
		{
			CreateFromAxisAngle(axis, angle, out Matrix3 result);
			return result;
		}

		/// <summary>
		///     Build a rotation matrix from the specified quaternion.
		/// </summary>
		/// <param name="q">Quaternion to translate.</param>
		/// <param name="result">Matrix result.</param>
		public static void CreateFromQuaternion(ref Quaternion q, out Matrix3 result)
		{
			q.ToAxisAngle(out Vector3 axis, out float angle);
			CreateFromAxisAngle(axis, angle, out result);
		}

		/// <summary>
		///     Build a rotation matrix from the specified quaternion.
		/// </summary>
		/// <param name="q">Quaternion to translate.</param>
		/// <returns>A matrix instance.</returns>
		public static Matrix3 CreateFromQuaternion(Quaternion q)
		{
			CreateFromQuaternion(ref q, out Matrix3 result);
			return result;
		}

		/// <summary>
		///     Builds a rotation matrix for a rotation around the x-axis.
		/// </summary>
		/// <param name="angle">The counter-clockwise angle in radians.</param>
		/// <param name="result">The resulting Matrix3 instance.</param>
		public static void CreateRotationX(float angle, out Matrix3 result)
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
		/// <returns>The resulting Matrix3 instance.</returns>
		public static Matrix3 CreateRotationX(float angle)
		{
			CreateRotationX(angle, out Matrix3 result);
			return result;
		}

		/// <summary>
		///     Builds a rotation matrix for a rotation around the y-axis.
		/// </summary>
		/// <param name="angle">The counter-clockwise angle in radians.</param>
		/// <param name="result">The resulting Matrix3 instance.</param>
		public static void CreateRotationY(float angle, out Matrix3 result)
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
		/// <returns>The resulting Matrix3 instance.</returns>
		public static Matrix3 CreateRotationY(float angle)
		{
			CreateRotationY(angle, out Matrix3 result);
			return result;
		}

		/// <summary>
		///     Builds a rotation matrix for a rotation around the z-axis.
		/// </summary>
		/// <param name="angle">The counter-clockwise angle in radians.</param>
		/// <param name="result">The resulting Matrix3 instance.</param>
		public static void CreateRotationZ(float angle, out Matrix3 result)
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
		/// <returns>The resulting Matrix3 instance.</returns>
		public static Matrix3 CreateRotationZ(float angle)
		{
			CreateRotationZ(angle, out Matrix3 result);
			return result;
		}

		/// <summary>Creates a scale matrix.</summary>
		/// <param name="scale">Single scale factor for the x, y, and z axes.</param>
		/// <returns>A scale matrix.</returns>
		public static Matrix3 CreateScale(float scale)
		{
			CreateScale(scale, out Matrix3 result);
			return result;
		}

		/// <summary>Creates a scale matrix.</summary>
		/// <param name="scale">Scale factors for the x, y, and z axes.</param>
		/// <returns>A scale matrix.</returns>
		public static Matrix3 CreateScale(Vector3 scale)
		{
			CreateScale(ref scale, out Matrix3 result);
			return result;
		}

		/// <summary>Creates a scale matrix.</summary>
		/// <param name="x">Scale factor for the x axis.</param>
		/// <param name="y">Scale factor for the y axis.</param>
		/// <param name="z">Scale factor for the z axis.</param>
		/// <returns>A scale matrix.</returns>
		public static Matrix3 CreateScale(float x, float y, float z)
		{
			CreateScale(x, y, z, out Matrix3 result);
			return result;
		}

		/// <summary>Creates a scale matrix.</summary>
		/// <param name="scale">Single scale factor for the x, y, and z axes.</param>
		/// <param name="result">A scale matrix.</param>
		public static void CreateScale(float scale, out Matrix3 result)
		{
			result = Identity;
			result.Row0.X = scale;
			result.Row1.Y = scale;
			result.Row2.Z = scale;
		}

		/// <summary>Creates a scale matrix.</summary>
		/// <param name="scale">Scale factors for the x, y, and z axes.</param>
		/// <param name="result">A scale matrix.</param>
		public static void CreateScale(ref Vector3 scale, out Matrix3 result)
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
		public static void CreateScale(float x, float y, float z, out Matrix3 result)
		{
			result = Identity;
			result.Row0.X = x;
			result.Row1.Y = y;
			result.Row2.Z = z;
		}

		/// <summary>Adds two instances.</summary>
		/// <param name="left">The left operand of the addition.</param>
		/// <param name="right">The right operand of the addition.</param>
		/// <returns>A new instance that is the result of the addition.</returns>
		public static Matrix3 Add(Matrix3 left, Matrix3 right)
		{
			Add(ref left, ref right, out Matrix3 result);
			return result;
		}

		/// <summary>Adds two instances.</summary>
		/// <param name="left">The left operand of the addition.</param>
		/// <param name="right">The right operand of the addition.</param>
		/// <param name="result">A new instance that is the result of the addition.</param>
		public static void Add(ref Matrix3 left, ref Matrix3 right, out Matrix3 result)
		{
			Vector3.Add(ref left.Row0, ref right.Row0, out result.Row0);
			Vector3.Add(ref left.Row1, ref right.Row1, out result.Row1);
			Vector3.Add(ref left.Row2, ref right.Row2, out result.Row2);
		}

		/// <summary>Multiplies two instances.</summary>
		/// <param name="left">The left operand of the multiplication.</param>
		/// <param name="right">The right operand of the multiplication.</param>
		/// <returns>A new instance that is the result of the multiplication</returns>
		public static Matrix3 Mult(Matrix3 left, Matrix3 right)
		{
			Mult(ref left, ref right, out Matrix3 result);
			return result;
		}

		/// <summary>Multiplies two instances.</summary>
		/// <param name="left">The left operand of the multiplication.</param>
		/// <param name="right">The right operand of the multiplication.</param>
		/// <param name="result">A new instance that is the result of the multiplication</param>
		public static void Mult(ref Matrix3 left, ref Matrix3 right, out Matrix3 result)
		{
			float x1 = left.Row0.X;
			float y1 = left.Row0.Y;
			float z1 = left.Row0.Z;
			float x2 = left.Row1.X;
			float y2 = left.Row1.Y;
			float z2 = left.Row1.Z;
			float x3 = left.Row2.X;
			float y3 = left.Row2.Y;
			float z3 = left.Row2.Z;
			float x4 = right.Row0.X;
			float y4 = right.Row0.Y;
			float z4 = right.Row0.Z;
			float x5 = right.Row1.X;
			float y5 = right.Row1.Y;
			float z5 = right.Row1.Z;
			float x6 = right.Row2.X;
			float y6 = right.Row2.Y;
			float z6 = right.Row2.Z;
			result.Row0.X = x1 * x4 + y1 * x5 + z1 * x6;
			result.Row0.Y = x1 * y4 + y1 * y5 + z1 * y6;
			result.Row0.Z = x1 * z4 + y1 * z5 + z1 * z6;
			result.Row1.X = x2 * x4 + y2 * x5 + z2 * x6;
			result.Row1.Y = x2 * y4 + y2 * y5 + z2 * y6;
			result.Row1.Z = x2 * z4 + y2 * z5 + z2 * z6;
			result.Row2.X = x3 * x4 + y3 * x5 + z3 * x6;
			result.Row2.Y = x3 * y4 + y3 * y5 + z3 * y6;
			result.Row2.Z = x3 * z4 + y3 * z5 + z3 * z6;
		}

		/// <summary>Calculate the inverse of the given matrix</summary>
		/// <param name="mat">The matrix to invert</param>
		/// <param name="result">The inverse of the given matrix if it has one, or the input if it is singular</param>
		/// <exception cref="T:System.InvalidOperationException">Thrown if the Matrix3 is singular.</exception>
		public static void Invert(ref Matrix3 mat, out Matrix3 result)
		{
			int[] numArray1 = new int[3];
			int[] numArray2 = new int[3];
			int[] numArray3 = new int[3] { -1, -1, -1 };
			float[,] numArray4 = new float[3, 3]
			{
				{
					mat.Row0.X,
					mat.Row0.Y,
					mat.Row0.Z
				},
				{
					mat.Row1.X,
					mat.Row1.Y,
					mat.Row1.Z
				},
				{
					mat.Row2.X,
					mat.Row2.Y,
					mat.Row2.Z
				}
			};
			int index1 = 0;
			int index2 = 0;
			for (int index3 = 0; index3 < 3; ++index3)
			{
				float num1 = 0.0f;
				for (int index4 = 0; index4 < 3; ++index4)
				{
					if (numArray3[index4] != 0)
					{
						for (int index5 = 0; index5 < 3; ++index5)
						{
							if (numArray3[index5] == -1)
							{
								float num2 = MathF.Abs(numArray4[index4, index5]);
								if (num2 > num1)
								{
									num1 = num2;
									index2 = index4;
									index1 = index5;
								}
							}
							else if (numArray3[index5] > 0)
							{
								result = mat;
								return;
							}
						}
					}
				}

				++numArray3[index1];
				if (index2 != index1)
				{
					for (int index4 = 0; index4 < 3; ++index4)
					{
						float num2 = numArray4[index2, index4];
						numArray4[index2, index4] = numArray4[index1, index4];
						numArray4[index1, index4] = num2;
					}
				}

				numArray2[index3] = index2;
				numArray1[index3] = index1;
				float num3 = numArray4[index1, index1];
				if (num3 == 0.0) throw new InvalidOperationException("Matrix is singular and cannot be inverted.");
				float num4 = 1f / num3;
				numArray4[index1, index1] = 1f;
				for (int index4 = 0; index4 < 3; ++index4) numArray4[index1, index4] *= num4;
				for (int index4 = 0; index4 < 3; ++index4)
				{
					if (index1 != index4)
					{
						float num2 = numArray4[index4, index1];
						numArray4[index4, index1] = 0.0f;
						for (int index5 = 0; index5 < 3; ++index5) numArray4[index4, index5] -= numArray4[index1, index5] * num2;
					}
				}
			}

			for (int index3 = 2; index3 >= 0; --index3)
			{
				int index4 = numArray2[index3];
				int index5 = numArray1[index3];
				for (int index6 = 0; index6 < 3; ++index6)
				{
					float num = numArray4[index6, index4];
					numArray4[index6, index4] = numArray4[index6, index5];
					numArray4[index6, index5] = num;
				}
			}

			result.Row0.X = numArray4[0, 0];
			result.Row0.Y = numArray4[0, 1];
			result.Row0.Z = numArray4[0, 2];
			result.Row1.X = numArray4[1, 0];
			result.Row1.Y = numArray4[1, 1];
			result.Row1.Z = numArray4[1, 2];
			result.Row2.X = numArray4[2, 0];
			result.Row2.Y = numArray4[2, 1];
			result.Row2.Z = numArray4[2, 2];
		}

		/// <summary>Calculate the inverse of the given matrix</summary>
		/// <param name="mat">The matrix to invert</param>
		/// <returns>The inverse of the given matrix if it has one, or the input if it is singular</returns>
		/// <exception cref="T:System.InvalidOperationException">Thrown if the Matrix4 is singular.</exception>
		public static Matrix3 Invert(Matrix3 mat)
		{
			Invert(ref mat, out Matrix3 result);
			return result;
		}

		/// <summary>Calculate the transpose of the given matrix</summary>
		/// <param name="mat">The matrix to transpose</param>
		/// <returns>The transpose of the given matrix</returns>
		public static Matrix3 Transpose(Matrix3 mat)
		{
			return new Matrix3(mat.Column0, mat.Column1, mat.Column2);
		}

		/// <summary>Calculate the transpose of the given matrix</summary>
		/// <param name="mat">The matrix to transpose</param>
		/// <param name="result">The result of the calculation</param>
		public static void Transpose(ref Matrix3 mat, out Matrix3 result)
		{
			result.Row0.X = mat.Row0.X;
			result.Row0.Y = mat.Row1.X;
			result.Row0.Z = mat.Row2.X;
			result.Row1.X = mat.Row0.Y;
			result.Row1.Y = mat.Row1.Y;
			result.Row1.Z = mat.Row2.Y;
			result.Row2.X = mat.Row0.Z;
			result.Row2.Y = mat.Row1.Z;
			result.Row2.Z = mat.Row2.Z;
		}

		/// <summary>Matrix multiplication</summary>
		/// <param name="left">left-hand operand</param>
		/// <param name="right">right-hand operand</param>
		/// <returns>A new Matrix3d which holds the result of the multiplication</returns>
		public static Matrix3 operator *(Matrix3 left, Matrix3 right)
		{
			return Mult(left, right);
		}

		/// <summary>Compares two instances for equality.</summary>
		/// <param name="left">The first instance.</param>
		/// <param name="right">The second instance.</param>
		/// <returns>True, if left equals right; false otherwise.</returns>
		public static bool operator ==(Matrix3 left, Matrix3 right)
		{
			return left.Equals(right);
		}

		/// <summary>Compares two instances for inequality.</summary>
		/// <param name="left">The first instance.</param>
		/// <param name="right">The second instance.</param>
		/// <returns>True, if left does not equal right; false otherwise.</returns>
		public static bool operator !=(Matrix3 left, Matrix3 right)
		{
			return !left.Equals(right);
		}

		/// <summary>
		///     Returns a System.String that represents the current Matrix3d.
		/// </summary>
		/// <returns>The string representation of the matrix.</returns>
		public override string ToString()
		{
			return $"{Row0}\n{Row1}\n{Row2}";
		}

		/// <summary>Returns the hashcode for this instance.</summary>
		/// <returns>A System.Int32 containing the unique hashcode for this instance.</returns>
		public override int GetHashCode()
		{
			return (((Row0.GetHashCode() * 397) ^ Row1.GetHashCode()) * 397) ^ Row2.GetHashCode();
		}

		/// <summary>
		///     Indicates whether this instance and a specified object are equal.
		/// </summary>
		/// <param name="obj">The object to compare to.</param>
		/// <returns>True if the instances are equal; false otherwise.</returns>
		public override bool Equals(object obj)
		{
			return obj is Matrix3 other && Equals(other);
		}

		/// <summary>Indicates whether the current matrix is equal to another matrix.</summary>
		/// <param name="other">A matrix to compare with this matrix.</param>
		/// <returns>true if the current matrix is equal to the matrix parameter; otherwise, false.</returns>
		public bool Equals(Matrix3 other)
		{
			return Row0 == other.Row0 && Row1 == other.Row1 && Row2 == other.Row2;
		}
	}
}