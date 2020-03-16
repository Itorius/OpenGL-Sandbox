using System;

namespace Base
{
	[Serializable]
	public partial struct Matrix4 : IEquatable<Matrix4>
	{
		/// <summary>The identity matrix.</summary>
		public static readonly Matrix4 Identity = new Matrix4(Vector4.UnitX, Vector4.UnitY, Vector4.UnitZ, Vector4.UnitW);

		/// <summary>The zero matrix.</summary>
		public static readonly Matrix4 Zero = new Matrix4(Vector4.Zero, Vector4.Zero, Vector4.Zero, Vector4.Zero);

		/// <summary>Top row of the matrix.</summary>
		public Vector4 Row0;

		/// <summary>2nd row of the matrix.</summary>
		public Vector4 Row1;

		/// <summary>3rd row of the matrix.</summary>
		public Vector4 Row2;

		/// <summary>Bottom row of the matrix.</summary>
		public Vector4 Row3;

		/// <summary>Constructs a new instance.</summary>
		/// <param name="row0">Top row of the matrix.</param>
		/// <param name="row1">Second row of the matrix.</param>
		/// <param name="row2">Third row of the matrix.</param>
		/// <param name="row3">Bottom row of the matrix.</param>
		public Matrix4(Vector4 row0, Vector4 row1, Vector4 row2, Vector4 row3)
		{
			Row0 = row0;
			Row1 = row1;
			Row2 = row2;
			Row3 = row3;
		}

		/// <summary>Constructs a new instance.</summary>
		/// <param name="m00">First item of the first row of the matrix.</param>
		/// <param name="m01">Second item of the first row of the matrix.</param>
		/// <param name="m02">Third item of the first row of the matrix.</param>
		/// <param name="m03">Fourth item of the first row of the matrix.</param>
		/// <param name="m10">First item of the second row of the matrix.</param>
		/// <param name="m11">Second item of the second row of the matrix.</param>
		/// <param name="m12">Third item of the second row of the matrix.</param>
		/// <param name="m13">Fourth item of the second row of the matrix.</param>
		/// <param name="m20">First item of the third row of the matrix.</param>
		/// <param name="m21">Second item of the third row of the matrix.</param>
		/// <param name="m22">Third item of the third row of the matrix.</param>
		/// <param name="m23">First item of the third row of the matrix.</param>
		/// <param name="m30">Fourth item of the fourth row of the matrix.</param>
		/// <param name="m31">Second item of the fourth row of the matrix.</param>
		/// <param name="m32">Third item of the fourth row of the matrix.</param>
		/// <param name="m33">Fourth item of the fourth row of the matrix.</param>
		public Matrix4(float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13, float m20, float m21, float m22, float m23, float m30, float m31, float m32, float m33)
		{
			Row0 = new Vector4(m00, m01, m02, m03);
			Row1 = new Vector4(m10, m11, m12, m13);
			Row2 = new Vector4(m20, m21, m22, m23);
			Row3 = new Vector4(m30, m31, m32, m33);
		}

		/// <summary>Constructs a new instance.</summary>
		/// <param name="topLeft">The top left 3x3 of the matrix.</param>
		public Matrix4(Matrix3 topLeft)
		{
			Row0.X = topLeft.Row0.X;
			Row0.Y = topLeft.Row0.Y;
			Row0.Z = topLeft.Row0.Z;
			Row0.W = 0.0f;
			Row1.X = topLeft.Row1.X;
			Row1.Y = topLeft.Row1.Y;
			Row1.Z = topLeft.Row1.Z;
			Row1.W = 0.0f;
			Row2.X = topLeft.Row2.X;
			Row2.Y = topLeft.Row2.Y;
			Row2.Z = topLeft.Row2.Z;
			Row2.W = 0.0f;
			Row3.X = 0.0f;
			Row3.Y = 0.0f;
			Row3.Z = 0.0f;
			Row3.W = 1f;
		}

		/// <summary>Gets the determinant of this matrix.</summary>
		public float Determinant
		{
			get
			{
				float x1 = Row0.X;
				float y1 = Row0.Y;
				float z1 = Row0.Z;
				float w1 = Row0.W;
				float x2 = Row1.X;
				float y2 = Row1.Y;
				float z2 = Row1.Z;
				float w2 = Row1.W;
				float x3 = Row2.X;
				float y3 = Row2.Y;
				float z3 = Row2.Z;
				float w3 = Row2.W;
				float x4 = Row3.X;
				float y4 = Row3.Y;
				float z4 = Row3.Z;
				float w4 = Row3.W;
				return x1 * y2 * z3 * w4 - x1 * y2 * w3 * z4 + x1 * z2 * w3 * y4 - x1 * z2 * y3 * w4 + x1 * w2 * y3 * z4 - x1 * w2 * z3 * y4 - y1 * z2 * w3 * x4 + y1 * z2 * x3 * w4 - y1 * w2 * x3 * z4 + y1 * w2 * z3 * x4 - y1 * x2 * z3 * w4 + y1 * x2 * w3 * z4 + z1 * w2 * x3 * y4 - z1 * w2 * y3 * x4 + z1 * x2 * y3 * w4 - z1 * x2 * w3 * y4 + z1 * y2 * w3 * x4 - z1 * y2 * x3 * w4 - w1 * x2 * y3 * z4 + w1 * x2 * z3 * y4 - w1 * y2 * z3 * x4 + w1 * y2 * x3 * z4 - w1 * z2 * x3 * y4 + w1 * z2 * y3 * x4;
			}
		}

		/// <summary>Gets the first column of this matrix.</summary>
		public Vector4 Column0
		{
			get => new Vector4(Row0.X, Row1.X, Row2.X, Row3.X);
			set
			{
				Row0.X = value.X;
				Row1.X = value.Y;
				Row2.X = value.Z;
				Row3.X = value.W;
			}
		}

		/// <summary>Gets the second column of this matrix.</summary>
		public Vector4 Column1
		{
			get => new Vector4(Row0.Y, Row1.Y, Row2.Y, Row3.Y);
			set
			{
				Row0.Y = value.X;
				Row1.Y = value.Y;
				Row2.Y = value.Z;
				Row3.Y = value.W;
			}
		}

		/// <summary>Gets the third column of this matrix.</summary>
		public Vector4 Column2
		{
			get => new Vector4(Row0.Z, Row1.Z, Row2.Z, Row3.Z);
			set
			{
				Row0.Z = value.X;
				Row1.Z = value.Y;
				Row2.Z = value.Z;
				Row3.Z = value.W;
			}
		}

		/// <summary>Gets the fourth column of this matrix.</summary>
		public Vector4 Column3
		{
			get => new Vector4(Row0.W, Row1.W, Row2.W, Row3.W);
			set
			{
				Row0.W = value.X;
				Row1.W = value.Y;
				Row2.W = value.Z;
				Row3.W = value.W;
			}
		}

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
		///     Gets or sets the value at row 1, column 4 of this instance.
		/// </summary>
		public float M14
		{
			get => Row0.W;
			set => Row0.W = value;
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
		///     Gets or sets the value at row 2, column 4 of this instance.
		/// </summary>
		public float M24
		{
			get => Row1.W;
			set => Row1.W = value;
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
		///     Gets or sets the value at row 3, column 4 of this instance.
		/// </summary>
		public float M34
		{
			get => Row2.W;
			set => Row2.W = value;
		}

		/// <summary>
		///     Gets or sets the value at row 4, column 1 of this instance.
		/// </summary>
		public float M41
		{
			get => Row3.X;
			set => Row3.X = value;
		}

		/// <summary>
		///     Gets or sets the value at row 4, column 2 of this instance.
		/// </summary>
		public float M42
		{
			get => Row3.Y;
			set => Row3.Y = value;
		}

		/// <summary>
		///     Gets or sets the value at row 4, column 3 of this instance.
		/// </summary>
		public float M43
		{
			get => Row3.Z;
			set => Row3.Z = value;
		}

		/// <summary>
		///     Gets or sets the value at row 4, column 4 of this instance.
		/// </summary>
		public float M44
		{
			get => Row3.W;
			set => Row3.W = value;
		}

		/// <summary>
		///     Gets or sets the values along the main diagonal of the matrix.
		/// </summary>
		public Vector4 Diagonal
		{
			get => new Vector4(Row0.X, Row1.Y, Row2.Z, Row3.W);
			set
			{
				Row0.X = value.X;
				Row1.Y = value.Y;
				Row2.Z = value.Z;
				Row3.W = value.W;
			}
		}

		/// <summary>
		///     Gets the trace of the matrix, the sum of the values along the diagonal.
		/// </summary>
		public float Trace => Row0.X + Row1.Y + Row2.Z + Row3.W;

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
					case 3:
						return Row3[columnIndex];
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
					case 3:
						Row3[columnIndex] = value;
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
		public Matrix4 Normalized()
		{
			Matrix4 matrix4 = this;
			matrix4.Normalize();
			return matrix4;
		}

		/// <summary>
		///     Divides each element in the Matrix by the <see cref="P:OpenTK.Matrix4.Determinant" />.
		/// </summary>
		public void Normalize()
		{
			float determinant = Determinant;
			Row0 /= determinant;
			Row1 /= determinant;
			Row2 /= determinant;
			Row3 /= determinant;
		}

		/// <summary>Returns an inverted copy of this instance.</summary>
		public Matrix4 Inverted()
		{
			Matrix4 matrix4 = this;
			if (matrix4.Determinant != 0.0) matrix4.Invert();
			return matrix4;
		}

		/// <summary>Returns a copy of this Matrix4 without translation.</summary>
		public Matrix4 ClearTranslation()
		{
			Matrix4 matrix4 = this;
			matrix4.Row3.Xyz = Vector3.Zero;
			return matrix4;
		}

		/// <summary>Returns a copy of this Matrix4 without scale.</summary>
		public Matrix4 ClearScale()
		{
			Matrix4 matrix4 = this;
			matrix4.Row0.Xyz = matrix4.Row0.Xyz.Normalized();
			matrix4.Row1.Xyz = matrix4.Row1.Xyz.Normalized();
			matrix4.Row2.Xyz = matrix4.Row2.Xyz.Normalized();
			return matrix4;
		}

		/// <summary>Returns a copy of this Matrix4 without rotation.</summary>
		public Matrix4 ClearRotation()
		{
			Matrix4 matrix4 = this;
			matrix4.Row0.Xyz = new Vector3(matrix4.Row0.Xyz.Length, 0.0f, 0.0f);
			matrix4.Row1.Xyz = new Vector3(0.0f, matrix4.Row1.Xyz.Length, 0.0f);
			matrix4.Row2.Xyz = new Vector3(0.0f, 0.0f, matrix4.Row2.Xyz.Length);
			return matrix4;
		}

		/// <summary>Returns a copy of this Matrix4 without projection.</summary>
		public Matrix4 ClearProjection()
		{
			Matrix4 matrix4 = this;
			matrix4.Column3 = Vector4.Zero;
			return matrix4;
		}

		/// <summary>Returns the translation component of this instance.</summary>
		public Vector3 ExtractTranslation()
		{
			return Row3.Xyz;
		}

		/// <summary>Returns the scale component of this instance.</summary>
		public Vector3 ExtractScale()
		{
			Vector3 xyz = Row0.Xyz;
			float length1 = xyz.Length;
			xyz = Row1.Xyz;
			float length2 = xyz.Length;
			xyz = Row2.Xyz;
			float length3 = xyz.Length;
			return new Vector3(length1, length2, length3);
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
			Vector3 vector3_1 = Row0.Xyz;
			Vector3 vector3_2 = Row1.Xyz;
			Vector3 vector3_3 = Row2.Xyz;
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

		/// <summary>Returns the projection component of this instance.</summary>
		public Vector4 ExtractProjection()
		{
			return Column3;
		}

		/// <summary>
		///     Build a rotation matrix from the specified axis/angle rotation.
		/// </summary>
		/// <param name="axis">The axis to rotate about.</param>
		/// <param name="angle">Angle in radians to rotate counter-clockwise (looking in the direction of the given axis).</param>
		/// <param name="result">A matrix instance.</param>
		public static void CreateFromAxisAngle(Vector3 axis, float angle, out Matrix4 result)
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
			result.Row0.W = 0.0f;
			result.Row1.X = num5 + num12;
			result.Row1.Y = num7 + num1;
			result.Row1.Z = num8 - num10;
			result.Row1.W = 0.0f;
			result.Row2.X = num6 - num11;
			result.Row2.Y = num8 + num10;
			result.Row2.Z = num9 + num1;
			result.Row2.W = 0.0f;
			result.Row3 = Vector4.UnitW;
		}

		/// <summary>Matrix multiplication</summary>
		/// <param name="left">left-hand operand</param>
		/// <param name="right">right-hand operand</param>
		/// <returns>A new Matrix4 which holds the result of the multiplication</returns>
		public static Matrix4 operator *(Matrix4 left, Matrix4 right)
		{
			return Mult(left, right);
		}

		/// <summary>Matrix-scalar multiplication</summary>
		/// <param name="left">left-hand operand</param>
		/// <param name="right">right-hand operand</param>
		/// <returns>A new Matrix4 which holds the result of the multiplication</returns>
		public static Matrix4 operator *(Matrix4 left, float right)
		{
			return Mult(left, right);
		}

		/// <summary>Matrix addition</summary>
		/// <param name="left">left-hand operand</param>
		/// <param name="right">right-hand operand</param>
		/// <returns>A new Matrix4 which holds the result of the addition</returns>
		public static Matrix4 operator +(Matrix4 left, Matrix4 right)
		{
			return Add(left, right);
		}

		/// <summary>Matrix subtraction</summary>
		/// <param name="left">left-hand operand</param>
		/// <param name="right">right-hand operand</param>
		/// <returns>A new Matrix4 which holds the result of the subtraction</returns>
		public static Matrix4 operator -(Matrix4 left, Matrix4 right)
		{
			return Subtract(left, right);
		}

		/// <summary>Compares two instances for equality.</summary>
		/// <param name="left">The first instance.</param>
		/// <param name="right">The second instance.</param>
		/// <returns>True, if left equals right; false otherwise.</returns>
		public static bool operator ==(Matrix4 left, Matrix4 right)
		{
			return left.Equals(right);
		}

		/// <summary>Compares two instances for inequality.</summary>
		/// <param name="left">The first instance.</param>
		/// <param name="right">The second instance.</param>
		/// <returns>True, if left does not equal right; false otherwise.</returns>
		public static bool operator !=(Matrix4 left, Matrix4 right)
		{
			return !left.Equals(right);
		}

		/// <summary>
		///     Returns a System.String that represents the current Matrix4.
		/// </summary>
		/// <returns>The string representation of the matrix.</returns>
		public override string ToString()
		{
			return $"{(object)Row0}\n{(object)Row1}\n{(object)Row2}\n{(object)Row3}";
		}

		/// <summary>Returns the hashcode for this instance.</summary>
		/// <returns>A System.Int32 containing the unique hashcode for this instance.</returns>
		public override int GetHashCode()
		{
			return (((((Row0.GetHashCode() * 397) ^ Row1.GetHashCode()) * 397) ^ Row2.GetHashCode()) * 397) ^ Row3.GetHashCode();
		}

		/// <summary>
		///     Indicates whether this instance and a specified object are equal.
		/// </summary>
		/// <param name="obj">The object to compare tresult.</param>
		/// <returns>True if the instances are equal; false otherwise.</returns>
		public override bool Equals(object obj)
		{
			return obj is Matrix4 other && Equals(other);
		}

		/// <summary>Indicates whether the current matrix is equal to another matrix.</summary>
		/// <param name="other">An matrix to compare with this matrix.</param>
		/// <returns>true if the current matrix is equal to the matrix parameter; otherwise, false.</returns>
		public bool Equals(Matrix4 other)
		{
			return Row0 == other.Row0 && Row1 == other.Row1 && Row2 == other.Row2 && Row3 == other.Row3;
		}

		public unsafe float* ToPointer()
		{
			fixed (float* ptr = &Row0.X)
			{
				return ptr;
			}
		}
	}
}