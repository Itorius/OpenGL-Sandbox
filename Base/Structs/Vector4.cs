// Decompiled with JetBrains decompiler
// Type: OpenTK.Vector4
// Assembly: OpenTK, Version=3.1.0.0, Culture=neutral, PublicKeyToken=bad199fe84eb3df4
// MVID: 6764F93F-9A3E-4037-817C-5D176911BDEA
// Assembly location: C:\Users\Itorius\.nuget\packages\opentk\3.1.0\lib\net20\OpenTK.dll

using OpenTK;
using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace Base
{
	/// <summary>Represents a 4D vector using four single-precision floating-point numbers.</summary>
	/// <remarks>
	///     The Vector4 structure is suitable for interoperation with unmanaged code requiring four consecutive floats.
	/// </remarks>
	[Serializable]
	public struct Vector4 : IEquatable<Vector4>
	{
		/// <summary>
		///     Defines a unit-length Vector4 that points towards the X-axis.
		/// </summary>
		public static readonly Vector4 UnitX = new Vector4(1f, 0.0f, 0.0f, 0.0f);

		/// <summary>
		///     Defines a unit-length Vector4 that points towards the Y-axis.
		/// </summary>
		public static readonly Vector4 UnitY = new Vector4(0.0f, 1f, 0.0f, 0.0f);

		/// <summary>
		///     Defines a unit-length Vector4 that points towards the Z-axis.
		/// </summary>
		public static readonly Vector4 UnitZ = new Vector4(0.0f, 0.0f, 1f, 0.0f);

		/// <summary>
		///     Defines a unit-length Vector4 that points towards the W-axis.
		/// </summary>
		public static readonly Vector4 UnitW = new Vector4(0.0f, 0.0f, 0.0f, 1f);

		/// <summary>Defines a zero-length Vector4.</summary>
		public static readonly Vector4 Zero = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);

		/// <summary>Defines an instance with all components set to 1.</summary>
		public static readonly Vector4 One = new Vector4(1f, 1f, 1f, 1f);

		/// <summary>Defines the size of the Vector4 struct in bytes.</summary>
		public static readonly int SizeInBytes = Marshal.SizeOf((object)new Vector4());

		private static string listSeparator = CultureInfo.CurrentCulture.TextInfo.ListSeparator;

		/// <summary>The X component of the Vector4.</summary>
		public float X;

		/// <summary>The Y component of the Vector4.</summary>
		public float Y;

		/// <summary>The Z component of the Vector4.</summary>
		public float Z;

		/// <summary>The W component of the Vector4.</summary>
		public float W;

		/// <summary>Constructs a new instance.</summary>
		/// <param name="value">The value that will initialize this instance.</param>
		public Vector4(float value)
		{
			X = value;
			Y = value;
			Z = value;
			W = value;
		}

		/// <summary>Constructs a new Vector4.</summary>
		/// <param name="x">The x component of the Vector4.</param>
		/// <param name="y">The y component of the Vector4.</param>
		/// <param name="z">The z component of the Vector4.</param>
		/// <param name="w">The w component of the Vector4.</param>
		public Vector4(float x, float y, float z, float w)
		{
			X = x;
			Y = y;
			Z = z;
			W = w;
		}

		/// <summary>Constructs a new Vector4 from the given Vector2.</summary>
		/// <param name="v">The Vector2 to copy components from.</param>
		public Vector4(Vector2 v)
		{
			X = v.X;
			Y = v.Y;
			Z = 0.0f;
			W = 0.0f;
		}

		/// <summary>
		///     Constructs a new Vector4 from the given Vector3.
		///     The w component is initialized to 0.
		/// </summary>
		/// <param name="v">The Vector3 to copy components from.</param>
		/// <remarks>
		///     <seealso cref="M:OpenTK.Vector4.#ctor(OpenTK.Vector3,System.Single)" />
		/// </remarks>
		public Vector4(Vector3 v)
		{
			X = v.X;
			Y = v.Y;
			Z = v.Z;
			W = 0.0f;
		}

		/// <summary>
		///     Constructs a new Vector4 from the specified Vector3 and w component.
		/// </summary>
		/// <param name="v">The Vector3 to copy components from.</param>
		/// <param name="w">The w component of the new Vector4.</param>
		public Vector4(Vector3 v, float w)
		{
			X = v.X;
			Y = v.Y;
			Z = v.Z;
			W = w;
		}

		/// <summary>Constructs a new Vector4 from the given Vector4.</summary>
		/// <param name="v">The Vector4 to copy components from.</param>
		public Vector4(Vector4 v)
		{
			X = v.X;
			Y = v.Y;
			Z = v.Z;
			W = v.W;
		}

		/// <summary>Gets or sets the value at the index of the Vector.</summary>
		public float this[int index]
		{
			get
			{
				switch (index)
				{
					case 0:
						return X;
					case 1:
						return Y;
					case 2:
						return Z;
					case 3:
						return W;
					default:
						throw new IndexOutOfRangeException("You tried to access this vector at index: " + index);
				}
			}
			set
			{
				switch (index)
				{
					case 0:
						X = value;
						break;
					case 1:
						Y = value;
						break;
					case 2:
						Z = value;
						break;
					case 3:
						W = value;
						break;
					default:
						throw new IndexOutOfRangeException("You tried to set this vector at index: " + index);
				}
			}
		}

		/// <summary>Gets the length (magnitude) of the vector.</summary>
		/// <see cref="P:OpenTK.Vector4.LengthFast" />
		/// <seealso cref="P:OpenTK.Vector4.LengthSquared" />
		public float Length => MathF.Sqrt(X * X + Y * Y + Z * Z + W * W);

		/// <summary>
		///     Gets an approximation of the vector length (magnitude).
		/// </summary>
		/// <remarks>
		///     This property uses an approximation of the square root function to calculate vector magnitude, with
		///     an upper error bound of 0.001.
		/// </remarks>
		/// <see cref="P:OpenTK.Vector4.Length" />
		/// <seealso cref="P:OpenTK.Vector4.LengthSquared" />
		public float LengthFast => 1f / MathHelper.InverseSqrtFast((float)(X * (double)X + Y * (double)Y + Z * (double)Z + W * (double)W));

		/// <summary>Gets the square of the vector length (magnitude).</summary>
		/// <remarks>
		///     This property avoids the costly square root operation required by the Length property. This makes it more suitable
		///     for comparisons.
		/// </remarks>
		/// <see cref="P:OpenTK.Vector4.Length" />
		/// <seealso cref="P:OpenTK.Vector4.LengthFast" />
		public float LengthSquared => (float)(X * (double)X + Y * (double)Y + Z * (double)Z + W * (double)W);

		/// <summary>Returns a copy of the Vector4 scaled to unit length.</summary>
		public Vector4 Normalized()
		{
			var vector4 = this;
			vector4.Normalize();
			return vector4;
		}

		/// <summary>Scales the Vector4 to unit length.</summary>
		public void Normalize()
		{
			var num = 1f / Length;
			X *= num;
			Y *= num;
			Z *= num;
			W *= num;
		}

		/// <summary>Scales the Vector4 to approximately unit length.</summary>
		public void NormalizeFast()
		{
			var num = MathHelper.InverseSqrtFast((float)(X * (double)X + Y * (double)Y + Z * (double)Z + W * (double)W));
			X *= num;
			Y *= num;
			Z *= num;
			W *= num;
		}

		/// <summary>Adds two vectors.</summary>
		/// <param name="a">Left operand.</param>
		/// <param name="b">Right operand.</param>
		/// <returns>Result of operation.</returns>
		public static Vector4 Add(Vector4 a, Vector4 b)
		{
			Add(ref a, ref b, out a);
			return a;
		}

		/// <summary>Adds two vectors.</summary>
		/// <param name="a">Left operand.</param>
		/// <param name="b">Right operand.</param>
		/// <param name="result">Result of operation.</param>
		public static void Add(ref Vector4 a, ref Vector4 b, out Vector4 result)
		{
			result.X = a.X + b.X;
			result.Y = a.Y + b.Y;
			result.Z = a.Z + b.Z;
			result.W = a.W + b.W;
		}

		/// <summary>Subtract one Vector from another</summary>
		/// <param name="a">First operand</param>
		/// <param name="b">Second operand</param>
		/// <returns>Result of subtraction</returns>
		public static Vector4 Subtract(Vector4 a, Vector4 b)
		{
			Subtract(ref a, ref b, out a);
			return a;
		}

		/// <summary>Subtract one Vector from another</summary>
		/// <param name="a">First operand</param>
		/// <param name="b">Second operand</param>
		/// <param name="result">Result of subtraction</param>
		public static void Subtract(ref Vector4 a, ref Vector4 b, out Vector4 result)
		{
			result.X = a.X - b.X;
			result.Y = a.Y - b.Y;
			result.Z = a.Z - b.Z;
			result.W = a.W - b.W;
		}

		/// <summary>Multiplies a vector by a scalar.</summary>
		/// <param name="vector">Left operand.</param>
		/// <param name="scale">Right operand.</param>
		/// <returns>Result of the operation.</returns>
		public static Vector4 Multiply(Vector4 vector, float scale)
		{
			Multiply(ref vector, scale, out vector);
			return vector;
		}

		/// <summary>Multiplies a vector by a scalar.</summary>
		/// <param name="vector">Left operand.</param>
		/// <param name="scale">Right operand.</param>
		/// <param name="result">Result of the operation.</param>
		public static void Multiply(ref Vector4 vector, float scale, out Vector4 result)
		{
			result.X = vector.X * scale;
			result.Y = vector.Y * scale;
			result.Z = vector.Z * scale;
			result.W = vector.W * scale;
		}

		/// <summary>
		///     Multiplies a vector by the components a vector (scale).
		/// </summary>
		/// <param name="vector">Left operand.</param>
		/// <param name="scale">Right operand.</param>
		/// <returns>Result of the operation.</returns>
		public static Vector4 Multiply(Vector4 vector, Vector4 scale)
		{
			Multiply(ref vector, ref scale, out vector);
			return vector;
		}

		/// <summary>
		///     Multiplies a vector by the components of a vector (scale).
		/// </summary>
		/// <param name="vector">Left operand.</param>
		/// <param name="scale">Right operand.</param>
		/// <param name="result">Result of the operation.</param>
		public static void Multiply(ref Vector4 vector, ref Vector4 scale, out Vector4 result)
		{
			result.X = vector.X * scale.X;
			result.Y = vector.Y * scale.Y;
			result.Z = vector.Z * scale.Z;
			result.W = vector.W * scale.W;
		}

		/// <summary>Divides a vector by a scalar.</summary>
		/// <param name="vector">Left operand.</param>
		/// <param name="scale">Right operand.</param>
		/// <returns>Result of the operation.</returns>
		public static Vector4 Divide(Vector4 vector, float scale)
		{
			Divide(ref vector, scale, out vector);
			return vector;
		}

		/// <summary>Divides a vector by a scalar.</summary>
		/// <param name="vector">Left operand.</param>
		/// <param name="scale">Right operand.</param>
		/// <param name="result">Result of the operation.</param>
		public static void Divide(ref Vector4 vector, float scale, out Vector4 result)
		{
			result.X = vector.X / scale;
			result.Y = vector.Y / scale;
			result.Z = vector.Z / scale;
			result.W = vector.W / scale;
		}

		/// <summary>
		///     Divides a vector by the components of a vector (scale).
		/// </summary>
		/// <param name="vector">Left operand.</param>
		/// <param name="scale">Right operand.</param>
		/// <returns>Result of the operation.</returns>
		public static Vector4 Divide(Vector4 vector, Vector4 scale)
		{
			Divide(ref vector, ref scale, out vector);
			return vector;
		}

		/// <summary>
		///     Divide a vector by the components of a vector (scale).
		/// </summary>
		/// <param name="vector">Left operand.</param>
		/// <param name="scale">Right operand.</param>
		/// <param name="result">Result of the operation.</param>
		public static void Divide(ref Vector4 vector, ref Vector4 scale, out Vector4 result)
		{
			result.X = vector.X / scale.X;
			result.Y = vector.Y / scale.Y;
			result.Z = vector.Z / scale.Z;
			result.W = vector.W / scale.W;
		}

		/// <summary>Calculate the component-wise minimum of two vectors</summary>
		/// <param name="a">First operand</param>
		/// <param name="b">Second operand</param>
		/// <returns>The component-wise minimum</returns>
		[Obsolete("Use ComponentMin() instead.")]
		public static Vector4 Min(Vector4 a, Vector4 b)
		{
			a.X = (double)a.X < (double)b.X ? a.X : b.X;
			a.Y = (double)a.Y < (double)b.Y ? a.Y : b.Y;
			a.Z = (double)a.Z < (double)b.Z ? a.Z : b.Z;
			a.W = (double)a.W < (double)b.W ? a.W : b.W;
			return a;
		}

		/// <summary>Calculate the component-wise minimum of two vectors</summary>
		/// <param name="a">First operand</param>
		/// <param name="b">Second operand</param>
		/// <param name="result">The component-wise minimum</param>
		[Obsolete("Use ComponentMin() instead.")]
		public static void Min(ref Vector4 a, ref Vector4 b, out Vector4 result)
		{
			result.X = (double)a.X < (double)b.X ? a.X : b.X;
			result.Y = (double)a.Y < (double)b.Y ? a.Y : b.Y;
			result.Z = (double)a.Z < (double)b.Z ? a.Z : b.Z;
			result.W = (double)a.W < (double)b.W ? a.W : b.W;
		}

		/// <summary>Calculate the component-wise maximum of two vectors</summary>
		/// <param name="a">First operand</param>
		/// <param name="b">Second operand</param>
		/// <returns>The component-wise maximum</returns>
		[Obsolete("Use ComponentMax() instead.")]
		public static Vector4 Max(Vector4 a, Vector4 b)
		{
			a.X = (double)a.X > (double)b.X ? a.X : b.X;
			a.Y = (double)a.Y > (double)b.Y ? a.Y : b.Y;
			a.Z = (double)a.Z > (double)b.Z ? a.Z : b.Z;
			a.W = (double)a.W > (double)b.W ? a.W : b.W;
			return a;
		}

		/// <summary>Calculate the component-wise maximum of two vectors</summary>
		/// <param name="a">First operand</param>
		/// <param name="b">Second operand</param>
		/// <param name="result">The component-wise maximum</param>
		[Obsolete("Use ComponentMax() instead.")]
		public static void Max(ref Vector4 a, ref Vector4 b, out Vector4 result)
		{
			result.X = (double)a.X > (double)b.X ? a.X : b.X;
			result.Y = (double)a.Y > (double)b.Y ? a.Y : b.Y;
			result.Z = (double)a.Z > (double)b.Z ? a.Z : b.Z;
			result.W = (double)a.W > (double)b.W ? a.W : b.W;
		}

		/// <summary>
		///     Returns a vector created from the smallest of the corresponding components of the given vectors.
		/// </summary>
		/// <param name="a">First operand</param>
		/// <param name="b">Second operand</param>
		/// <returns>The component-wise minimum</returns>
		public static Vector4 ComponentMin(Vector4 a, Vector4 b)
		{
			a.X = (double)a.X < (double)b.X ? a.X : b.X;
			a.Y = (double)a.Y < (double)b.Y ? a.Y : b.Y;
			a.Z = (double)a.Z < (double)b.Z ? a.Z : b.Z;
			a.W = (double)a.W < (double)b.W ? a.W : b.W;
			return a;
		}

		/// <summary>
		///     Returns a vector created from the smallest of the corresponding components of the given vectors.
		/// </summary>
		/// <param name="a">First operand</param>
		/// <param name="b">Second operand</param>
		/// <param name="result">The component-wise minimum</param>
		public static void ComponentMin(ref Vector4 a, ref Vector4 b, out Vector4 result)
		{
			result.X = (double)a.X < (double)b.X ? a.X : b.X;
			result.Y = (double)a.Y < (double)b.Y ? a.Y : b.Y;
			result.Z = (double)a.Z < (double)b.Z ? a.Z : b.Z;
			result.W = (double)a.W < (double)b.W ? a.W : b.W;
		}

		/// <summary>
		///     Returns a vector created from the largest of the corresponding components of the given vectors.
		/// </summary>
		/// <param name="a">First operand</param>
		/// <param name="b">Second operand</param>
		/// <returns>The component-wise maximum</returns>
		public static Vector4 ComponentMax(Vector4 a, Vector4 b)
		{
			a.X = (double)a.X > (double)b.X ? a.X : b.X;
			a.Y = (double)a.Y > (double)b.Y ? a.Y : b.Y;
			a.Z = (double)a.Z > (double)b.Z ? a.Z : b.Z;
			a.W = (double)a.W > (double)b.W ? a.W : b.W;
			return a;
		}

		/// <summary>
		///     Returns a vector created from the largest of the corresponding components of the given vectors.
		/// </summary>
		/// <param name="a">First operand</param>
		/// <param name="b">Second operand</param>
		/// <param name="result">The component-wise maximum</param>
		public static void ComponentMax(ref Vector4 a, ref Vector4 b, out Vector4 result)
		{
			result.X = (double)a.X > (double)b.X ? a.X : b.X;
			result.Y = (double)a.Y > (double)b.Y ? a.Y : b.Y;
			result.Z = (double)a.Z > (double)b.Z ? a.Z : b.Z;
			result.W = (double)a.W > (double)b.W ? a.W : b.W;
		}

		/// <summary>
		///     Returns the Vector4 with the minimum magnitude. If the magnitudes are equal, the second vector
		///     is selected.
		/// </summary>
		/// <param name="left">Left operand</param>
		/// <param name="right">Right operand</param>
		/// <returns>The minimum Vector4</returns>
		public static Vector4 MagnitudeMin(Vector4 left, Vector4 right)
		{
			return (double)left.LengthSquared >= (double)right.LengthSquared ? right : left;
		}

		/// <summary>
		///     Returns the Vector4 with the minimum magnitude. If the magnitudes are equal, the second vector
		///     is selected.
		/// </summary>
		/// <param name="left">Left operand</param>
		/// <param name="right">Right operand</param>
		/// <param name="result">The magnitude-wise minimum</param>
		/// <returns>The minimum Vector4</returns>
		public static void MagnitudeMin(ref Vector4 left, ref Vector4 right, out Vector4 result)
		{
			result = (double)left.LengthSquared < (double)right.LengthSquared ? left : right;
		}

		/// <summary>
		///     Returns the Vector4 with the maximum magnitude. If the magnitudes are equal, the first vector
		///     is selected.
		/// </summary>
		/// <param name="left">Left operand</param>
		/// <param name="right">Right operand</param>
		/// <returns>The maximum Vector4</returns>
		public static Vector4 MagnitudeMax(Vector4 left, Vector4 right)
		{
			return (double)left.LengthSquared < (double)right.LengthSquared ? right : left;
		}

		/// <summary>
		///     Returns the Vector4 with the maximum magnitude. If the magnitudes are equal, the first vector
		///     is selected.
		/// </summary>
		/// <param name="left">Left operand</param>
		/// <param name="right">Right operand</param>
		/// <param name="result">The magnitude-wise maximum</param>
		/// <returns>The maximum Vector4</returns>
		public static void MagnitudeMax(ref Vector4 left, ref Vector4 right, out Vector4 result)
		{
			result = (double)left.LengthSquared >= (double)right.LengthSquared ? left : right;
		}

		/// <summary>
		///     Clamp a vector to the given minimum and maximum vectors
		/// </summary>
		/// <param name="vec">Input vector</param>
		/// <param name="min">Minimum vector</param>
		/// <param name="max">Maximum vector</param>
		/// <returns>The clamped vector</returns>
		public static Vector4 Clamp(Vector4 vec, Vector4 min, Vector4 max)
		{
			vec.X = (double)vec.X < (double)min.X ? min.X : (double)vec.X > (double)max.X ? max.X : vec.X;
			vec.Y = (double)vec.Y < (double)min.Y ? min.Y : (double)vec.Y > (double)max.Y ? max.Y : vec.Y;
			vec.Z = (double)vec.Z < (double)min.Z ? min.Z : (double)vec.Z > (double)max.Z ? max.Z : vec.Z;
			vec.W = (double)vec.W < (double)min.W ? min.W : (double)vec.W > (double)max.W ? max.W : vec.W;
			return vec;
		}

		/// <summary>
		///     Clamp a vector to the given minimum and maximum vectors
		/// </summary>
		/// <param name="vec">Input vector</param>
		/// <param name="min">Minimum vector</param>
		/// <param name="max">Maximum vector</param>
		/// <param name="result">The clamped vector</param>
		public static void Clamp(
			ref Vector4 vec,
			ref Vector4 min,
			ref Vector4 max,
			out Vector4 result)
		{
			result.X = (double)vec.X < (double)min.X ? min.X : (double)vec.X > (double)max.X ? max.X : vec.X;
			result.Y = (double)vec.Y < (double)min.Y ? min.Y : (double)vec.Y > (double)max.Y ? max.Y : vec.Y;
			result.Z = (double)vec.Z < (double)min.Z ? min.Z : (double)vec.Z > (double)max.Z ? max.Z : vec.Z;
			result.W = (double)vec.W < (double)min.W ? min.W : (double)vec.W > (double)max.W ? max.W : vec.W;
		}

		/// <summary>Scale a vector to unit length</summary>
		/// <param name="vec">The input vector</param>
		/// <returns>The normalized vector</returns>
		public static Vector4 Normalize(Vector4 vec)
		{
			var num = 1f / vec.Length;
			vec.X *= num;
			vec.Y *= num;
			vec.Z *= num;
			vec.W *= num;
			return vec;
		}

		/// <summary>Scale a vector to unit length</summary>
		/// <param name="vec">The input vector</param>
		/// <param name="result">The normalized vector</param>
		public static void Normalize(ref Vector4 vec, out Vector4 result)
		{
			var num = 1f / vec.Length;
			result.X = vec.X * num;
			result.Y = vec.Y * num;
			result.Z = vec.Z * num;
			result.W = vec.W * num;
		}

		/// <summary>Scale a vector to approximately unit length</summary>
		/// <param name="vec">The input vector</param>
		/// <returns>The normalized vector</returns>
		public static Vector4 NormalizeFast(Vector4 vec)
		{
			var num = MathHelper.InverseSqrtFast((float)(vec.X * (double)vec.X + vec.Y * (double)vec.Y + vec.Z * (double)vec.Z + vec.W * (double)vec.W));
			vec.X *= num;
			vec.Y *= num;
			vec.Z *= num;
			vec.W *= num;
			return vec;
		}

		/// <summary>Scale a vector to approximately unit length</summary>
		/// <param name="vec">The input vector</param>
		/// <param name="result">The normalized vector</param>
		public static void NormalizeFast(ref Vector4 vec, out Vector4 result)
		{
			var num = MathHelper.InverseSqrtFast((float)(vec.X * (double)vec.X + vec.Y * (double)vec.Y + vec.Z * (double)vec.Z + vec.W * (double)vec.W));
			result.X = vec.X * num;
			result.Y = vec.Y * num;
			result.Z = vec.Z * num;
			result.W = vec.W * num;
		}

		/// <summary>Calculate the dot product of two vectors</summary>
		/// <param name="left">First operand</param>
		/// <param name="right">Second operand</param>
		/// <returns>The dot product of the two inputs</returns>
		public static float Dot(Vector4 left, Vector4 right)
		{
			return (float)(left.X * (double)right.X + left.Y * (double)right.Y + left.Z * (double)right.Z + left.W * (double)right.W);
		}

		/// <summary>Calculate the dot product of two vectors</summary>
		/// <param name="left">First operand</param>
		/// <param name="right">Second operand</param>
		/// <param name="result">The dot product of the two inputs</param>
		public static void Dot(ref Vector4 left, ref Vector4 right, out float result)
		{
			result = (float)(left.X * (double)right.X + left.Y * (double)right.Y + left.Z * (double)right.Z + left.W * (double)right.W);
		}

		/// <summary>
		///     Returns a new Vector that is the linear blend of the 2 given Vectors
		/// </summary>
		/// <param name="a">First input vector</param>
		/// <param name="b">Second input vector</param>
		/// <param name="blend">The blend factor. a when blend=0, b when blend=1.</param>
		/// <returns>a when blend=0, b when blend=1, and a linear combination otherwise</returns>
		public static Vector4 Lerp(Vector4 a, Vector4 b, float blend)
		{
			a.X = blend * (b.X - a.X) + a.X;
			a.Y = blend * (b.Y - a.Y) + a.Y;
			a.Z = blend * (b.Z - a.Z) + a.Z;
			a.W = blend * (b.W - a.W) + a.W;
			return a;
		}

		/// <summary>
		///     Returns a new Vector that is the linear blend of the 2 given Vectors
		/// </summary>
		/// <param name="a">First input vector</param>
		/// <param name="b">Second input vector</param>
		/// <param name="blend">The blend factor. a when blend=0, b when blend=1.</param>
		/// <param name="result">a when blend=0, b when blend=1, and a linear combination otherwise</param>
		public static void Lerp(ref Vector4 a, ref Vector4 b, float blend, out Vector4 result)
		{
			result.X = blend * (b.X - a.X) + a.X;
			result.Y = blend * (b.Y - a.Y) + a.Y;
			result.Z = blend * (b.Z - a.Z) + a.Z;
			result.W = blend * (b.W - a.W) + a.W;
		}

		/// <summary>Interpolate 3 Vectors using Barycentric coordinates</summary>
		/// <param name="a">First input Vector</param>
		/// <param name="b">Second input Vector</param>
		/// <param name="c">Third input Vector</param>
		/// <param name="u">First Barycentric Coordinate</param>
		/// <param name="v">Second Barycentric Coordinate</param>
		/// <returns>a when u=v=0, b when u=1,v=0, c when u=0,v=1, and a linear combination of a,b,c otherwise</returns>
		public static Vector4 BaryCentric(Vector4 a, Vector4 b, Vector4 c, float u, float v)
		{
			return a + u * (b - a) + v * (c - a);
		}

		/// <summary>Interpolate 3 Vectors using Barycentric coordinates</summary>
		/// <param name="a">First input Vector.</param>
		/// <param name="b">Second input Vector.</param>
		/// <param name="c">Third input Vector.</param>
		/// <param name="u">First Barycentric Coordinate.</param>
		/// <param name="v">Second Barycentric Coordinate.</param>
		/// <param name="result">
		///     Output Vector. a when u=v=0, b when u=1,v=0, c when u=0,v=1, and a linear combination of a,b,c
		///     otherwise
		/// </param>
		public static void BaryCentric(
			ref Vector4 a,
			ref Vector4 b,
			ref Vector4 c,
			float u,
			float v,
			out Vector4 result)
		{
			result = a;
			var result1 = b;
			Subtract(ref result1, ref a, out result1);
			Multiply(ref result1, u, out result1);
			Add(ref result, ref result1, out result);
			var result2 = c;
			Subtract(ref result2, ref a, out result2);
			Multiply(ref result2, v, out result2);
			Add(ref result, ref result2, out result);
		}

		/// <summary>Transform a Vector by the given Matrix</summary>
		/// <param name="vec">The vector to transform</param>
		/// <param name="mat">The desired transformation</param>
		/// <returns>The transformed vector</returns>
		public static Vector4 Transform(Vector4 vec, Matrix4 mat)
		{
			Transform(ref vec, ref mat, out var result);
			return result;
		}

		/// <summary>Transform a Vector by the given Matrix</summary>
		/// <param name="vec">The vector to transform</param>
		/// <param name="mat">The desired transformation</param>
		/// <param name="result">The transformed vector</param>
		public static void Transform(ref Vector4 vec, ref Matrix4 mat, out Vector4 result)
		{
			result = new Vector4((float)(vec.X * (double)mat.Row0.X + vec.Y * (double)mat.Row1.X + vec.Z * (double)mat.Row2.X + vec.W * (double)mat.Row3.X), (float)(vec.X * (double)mat.Row0.Y + vec.Y * (double)mat.Row1.Y + vec.Z * (double)mat.Row2.Y + vec.W * (double)mat.Row3.Y), (float)(vec.X * (double)mat.Row0.Z + vec.Y * (double)mat.Row1.Z + vec.Z * (double)mat.Row2.Z + vec.W * (double)mat.Row3.Z), (float)(vec.X * (double)mat.Row0.W + vec.Y * (double)mat.Row1.W + vec.Z * (double)mat.Row2.W + vec.W * (double)mat.Row3.W));
		}

		/// <summary>Transforms a vector by a quaternion rotation.</summary>
		/// <param name="vec">The vector to transform.</param>
		/// <param name="quat">The quaternion to rotate the vector by.</param>
		/// <returns>The result of the operation.</returns>
		public static Vector4 Transform(Vector4 vec, Quaternion quat)
		{
			Transform(ref vec, ref quat, out var result);
			return result;
		}

		/// <summary>Transforms a vector by a quaternion rotation.</summary>
		/// <param name="vec">The vector to transform.</param>
		/// <param name="quat">The quaternion to rotate the vector by.</param>
		/// <param name="result">The result of the operation.</param>
		public static void Transform(ref Vector4 vec, ref Quaternion quat, out Vector4 result)
		{
			var result1 = new Quaternion(vec.X, vec.Y, vec.Z, vec.W);
			Quaternion.Invert(ref quat, out var result2);
			Quaternion.Multiply(ref quat, ref result1, out var result3);
			Quaternion.Multiply(ref result3, ref result2, out result1);
			result.X = result1.X;
			result.Y = result1.Y;
			result.Z = result1.Z;
			result.W = result1.W;
		}

		/// <summary>Transform a Vector by the given Matrix using right-handed notation</summary>
		/// <param name="mat">The desired transformation</param>
		/// <param name="vec">The vector to transform</param>
		public static Vector4 Transform(Matrix4 mat, Vector4 vec)
		{
			Transform(ref mat, ref vec, out var result);
			return result;
		}

		/// <summary>Transform a Vector by the given Matrix using right-handed notation</summary>
		/// <param name="mat">The desired transformation</param>
		/// <param name="vec">The vector to transform</param>
		/// <param name="result">The transformed vector</param>
		public static void Transform(ref Matrix4 mat, ref Vector4 vec, out Vector4 result)
		{
			result = new Vector4((float)(mat.Row0.X * (double)vec.X + mat.Row0.Y * (double)vec.Y + mat.Row0.Z * (double)vec.Z + mat.Row0.W * (double)vec.W), (float)(mat.Row1.X * (double)vec.X + mat.Row1.Y * (double)vec.Y + mat.Row1.Z * (double)vec.Z + mat.Row1.W * (double)vec.W), (float)(mat.Row2.X * (double)vec.X + mat.Row2.Y * (double)vec.Y + mat.Row2.Z * (double)vec.Z + mat.Row2.W * (double)vec.W), (float)(mat.Row3.X * (double)vec.X + mat.Row3.Y * (double)vec.Y + mat.Row3.Z * (double)vec.Z + mat.Row3.W * (double)vec.W));
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector2 with the X and Y components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector2 Xy
		{
			get => new Vector2(X, Y);
			set
			{
				X = value.X;
				Y = value.Y;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector2 with the X and Z components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector2 Xz
		{
			get => new Vector2(X, Z);
			set
			{
				X = value.X;
				Z = value.Y;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector2 with the X and W components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector2 Xw
		{
			get => new Vector2(X, W);
			set
			{
				X = value.X;
				W = value.Y;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector2 with the Y and X components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector2 Yx
		{
			get => new Vector2(Y, X);
			set
			{
				Y = value.X;
				X = value.Y;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector2 with the Y and Z components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector2 Yz
		{
			get => new Vector2(Y, Z);
			set
			{
				Y = value.X;
				Z = value.Y;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector2 with the Y and W components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector2 Yw
		{
			get => new Vector2(Y, W);
			set
			{
				Y = value.X;
				W = value.Y;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector2 with the Z and X components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector2 Zx
		{
			get => new Vector2(Z, X);
			set
			{
				Z = value.X;
				X = value.Y;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector2 with the Z and Y components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector2 Zy
		{
			get => new Vector2(Z, Y);
			set
			{
				Z = value.X;
				Y = value.Y;
			}
		}

		/// <summary>
		///     Gets an OpenTK.Vector2 with the Z and W components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector2 Zw
		{
			get => new Vector2(Z, W);
			set
			{
				Z = value.X;
				W = value.Y;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector2 with the W and X components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector2 Wx
		{
			get => new Vector2(W, X);
			set
			{
				W = value.X;
				X = value.Y;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector2 with the W and Y components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector2 Wy
		{
			get => new Vector2(W, Y);
			set
			{
				W = value.X;
				Y = value.Y;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector2 with the W and Z components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector2 Wz
		{
			get => new Vector2(W, Z);
			set
			{
				W = value.X;
				Z = value.Y;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector3 with the X, Y, and Z components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector3 Xyz
		{
			get => new Vector3(X, Y, Z);
			set
			{
				X = value.X;
				Y = value.Y;
				Z = value.Z;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector3 with the X, Y, and Z components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector3 Xyw
		{
			get => new Vector3(X, Y, W);
			set
			{
				X = value.X;
				Y = value.Y;
				W = value.Z;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector3 with the X, Z, and Y components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector3 Xzy
		{
			get => new Vector3(X, Z, Y);
			set
			{
				X = value.X;
				Z = value.Y;
				Y = value.Z;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector3 with the X, Z, and W components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector3 Xzw
		{
			get => new Vector3(X, Z, W);
			set
			{
				X = value.X;
				Z = value.Y;
				W = value.Z;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector3 with the X, W, and Y components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector3 Xwy
		{
			get => new Vector3(X, W, Y);
			set
			{
				X = value.X;
				W = value.Y;
				Y = value.Z;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector3 with the X, W, and Z components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector3 Xwz
		{
			get => new Vector3(X, W, Z);
			set
			{
				X = value.X;
				W = value.Y;
				Z = value.Z;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector3 with the Y, X, and Z components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector3 Yxz
		{
			get => new Vector3(Y, X, Z);
			set
			{
				Y = value.X;
				X = value.Y;
				Z = value.Z;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector3 with the Y, X, and W components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector3 Yxw
		{
			get => new Vector3(Y, X, W);
			set
			{
				Y = value.X;
				X = value.Y;
				W = value.Z;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector3 with the Y, Z, and X components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector3 Yzx
		{
			get => new Vector3(Y, Z, X);
			set
			{
				Y = value.X;
				Z = value.Y;
				X = value.Z;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector3 with the Y, Z, and W components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector3 Yzw
		{
			get => new Vector3(Y, Z, W);
			set
			{
				Y = value.X;
				Z = value.Y;
				W = value.Z;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector3 with the Y, W, and X components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector3 Ywx
		{
			get => new Vector3(Y, W, X);
			set
			{
				Y = value.X;
				W = value.Y;
				X = value.Z;
			}
		}

		/// <summary>
		///     Gets an OpenTK.Vector3 with the Y, W, and Z components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector3 Ywz
		{
			get => new Vector3(Y, W, Z);
			set
			{
				Y = value.X;
				W = value.Y;
				Z = value.Z;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector3 with the Z, X, and Y components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector3 Zxy
		{
			get => new Vector3(Z, X, Y);
			set
			{
				Z = value.X;
				X = value.Y;
				Y = value.Z;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector3 with the Z, X, and W components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector3 Zxw
		{
			get => new Vector3(Z, X, W);
			set
			{
				Z = value.X;
				X = value.Y;
				W = value.Z;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector3 with the Z, Y, and X components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector3 Zyx
		{
			get => new Vector3(Z, Y, X);
			set
			{
				Z = value.X;
				Y = value.Y;
				X = value.Z;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector3 with the Z, Y, and W components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector3 Zyw
		{
			get => new Vector3(Z, Y, W);
			set
			{
				Z = value.X;
				Y = value.Y;
				W = value.Z;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector3 with the Z, W, and X components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector3 Zwx
		{
			get => new Vector3(Z, W, X);
			set
			{
				Z = value.X;
				W = value.Y;
				X = value.Z;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector3 with the Z, W, and Y components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector3 Zwy
		{
			get => new Vector3(Z, W, Y);
			set
			{
				Z = value.X;
				W = value.Y;
				Y = value.Z;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector3 with the W, X, and Y components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector3 Wxy
		{
			get => new Vector3(W, X, Y);
			set
			{
				W = value.X;
				X = value.Y;
				Y = value.Z;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector3 with the W, X, and Z components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector3 Wxz
		{
			get => new Vector3(W, X, Z);
			set
			{
				W = value.X;
				X = value.Y;
				Z = value.Z;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector3 with the W, Y, and X components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector3 Wyx
		{
			get => new Vector3(W, Y, X);
			set
			{
				W = value.X;
				Y = value.Y;
				X = value.Z;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector3 with the W, Y, and Z components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector3 Wyz
		{
			get => new Vector3(W, Y, Z);
			set
			{
				W = value.X;
				Y = value.Y;
				Z = value.Z;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector3 with the W, Z, and X components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector3 Wzx
		{
			get => new Vector3(W, Z, X);
			set
			{
				W = value.X;
				Z = value.Y;
				X = value.Z;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector3 with the W, Z, and Y components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector3 Wzy
		{
			get => new Vector3(W, Z, Y);
			set
			{
				W = value.X;
				Z = value.Y;
				Y = value.Z;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector4 with the X, Y, W, and Z components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector4 Xywz
		{
			get => new Vector4(X, Y, W, Z);
			set
			{
				X = value.X;
				Y = value.Y;
				W = value.Z;
				Z = value.W;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector4 with the X, Z, Y, and W components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector4 Xzyw
		{
			get => new Vector4(X, Z, Y, W);
			set
			{
				X = value.X;
				Z = value.Y;
				Y = value.Z;
				W = value.W;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector4 with the X, Z, W, and Y components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector4 Xzwy
		{
			get => new Vector4(X, Z, W, Y);
			set
			{
				X = value.X;
				Z = value.Y;
				W = value.Z;
				Y = value.W;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector4 with the X, W, Y, and Z components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector4 Xwyz
		{
			get => new Vector4(X, W, Y, Z);
			set
			{
				X = value.X;
				W = value.Y;
				Y = value.Z;
				Z = value.W;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector4 with the X, W, Z, and Y components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector4 Xwzy
		{
			get => new Vector4(X, W, Z, Y);
			set
			{
				X = value.X;
				W = value.Y;
				Z = value.Z;
				Y = value.W;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector4 with the Y, X, Z, and W components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector4 Yxzw
		{
			get => new Vector4(Y, X, Z, W);
			set
			{
				Y = value.X;
				X = value.Y;
				Z = value.Z;
				W = value.W;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector4 with the Y, X, W, and Z components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector4 Yxwz
		{
			get => new Vector4(Y, X, W, Z);
			set
			{
				Y = value.X;
				X = value.Y;
				W = value.Z;
				Z = value.W;
			}
		}

		/// <summary>
		///     Gets an OpenTK.Vector4 with the Y, Y, Z, and W components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector4 Yyzw
		{
			get => new Vector4(Y, Y, Z, W);
			set
			{
				X = value.X;
				Y = value.Y;
				Z = value.Z;
				W = value.W;
			}
		}

		/// <summary>
		///     Gets an OpenTK.Vector4 with the Y, Y, W, and Z components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector4 Yywz
		{
			get => new Vector4(Y, Y, W, Z);
			set
			{
				X = value.X;
				Y = value.Y;
				W = value.Z;
				Z = value.W;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector4 with the Y, Z, X, and W components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector4 Yzxw
		{
			get => new Vector4(Y, Z, X, W);
			set
			{
				Y = value.X;
				Z = value.Y;
				X = value.Z;
				W = value.W;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector4 with the Y, Z, W, and X components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector4 Yzwx
		{
			get => new Vector4(Y, Z, W, X);
			set
			{
				Y = value.X;
				Z = value.Y;
				W = value.Z;
				X = value.W;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector4 with the Y, W, X, and Z components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector4 Ywxz
		{
			get => new Vector4(Y, W, X, Z);
			set
			{
				Y = value.X;
				W = value.Y;
				X = value.Z;
				Z = value.W;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector4 with the Y, W, Z, and X components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector4 Ywzx
		{
			get => new Vector4(Y, W, Z, X);
			set
			{
				Y = value.X;
				W = value.Y;
				Z = value.Z;
				X = value.W;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector4 with the Z, X, Y, and Z components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector4 Zxyw
		{
			get => new Vector4(Z, X, Y, W);
			set
			{
				Z = value.X;
				X = value.Y;
				Y = value.Z;
				W = value.W;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector4 with the Z, X, W, and Y components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector4 Zxwy
		{
			get => new Vector4(Z, X, W, Y);
			set
			{
				Z = value.X;
				X = value.Y;
				W = value.Z;
				Y = value.W;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector4 with the Z, Y, X, and W components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector4 Zyxw
		{
			get => new Vector4(Z, Y, X, W);
			set
			{
				Z = value.X;
				Y = value.Y;
				X = value.Z;
				W = value.W;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector4 with the Z, Y, W, and X components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector4 Zywx
		{
			get => new Vector4(Z, Y, W, X);
			set
			{
				Z = value.X;
				Y = value.Y;
				W = value.Z;
				X = value.W;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector4 with the Z, W, X, and Y components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector4 Zwxy
		{
			get => new Vector4(Z, W, X, Y);
			set
			{
				Z = value.X;
				W = value.Y;
				X = value.Z;
				Y = value.W;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector4 with the Z, W, Y, and X components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector4 Zwyx
		{
			get => new Vector4(Z, W, Y, X);
			set
			{
				Z = value.X;
				W = value.Y;
				Y = value.Z;
				X = value.W;
			}
		}

		/// <summary>
		///     Gets an OpenTK.Vector4 with the Z, W, Z, and Y components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector4 Zwzy
		{
			get => new Vector4(Z, W, Z, Y);
			set
			{
				X = value.X;
				W = value.Y;
				Z = value.Z;
				Y = value.W;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector4 with the W, X, Y, and Z components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector4 Wxyz
		{
			get => new Vector4(W, X, Y, Z);
			set
			{
				W = value.X;
				X = value.Y;
				Y = value.Z;
				Z = value.W;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector4 with the W, X, Z, and Y components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector4 Wxzy
		{
			get => new Vector4(W, X, Z, Y);
			set
			{
				W = value.X;
				X = value.Y;
				Z = value.Z;
				Y = value.W;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector4 with the W, Y, X, and Z components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector4 Wyxz
		{
			get => new Vector4(W, Y, X, Z);
			set
			{
				W = value.X;
				Y = value.Y;
				X = value.Z;
				Z = value.W;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector4 with the W, Y, Z, and X components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector4 Wyzx
		{
			get => new Vector4(W, Y, Z, X);
			set
			{
				W = value.X;
				Y = value.Y;
				Z = value.Z;
				X = value.W;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector4 with the W, Z, X, and Y components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector4 Wzxy
		{
			get => new Vector4(W, Z, X, Y);
			set
			{
				W = value.X;
				Z = value.Y;
				X = value.Z;
				Y = value.W;
			}
		}

		/// <summary>
		///     Gets or sets an OpenTK.Vector4 with the W, Z, Y, and X components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector4 Wzyx
		{
			get => new Vector4(W, Z, Y, X);
			set
			{
				W = value.X;
				Z = value.Y;
				Y = value.Z;
				X = value.W;
			}
		}

		/// <summary>
		///     Gets an OpenTK.Vector4 with the W, Z, Y, and W components of this instance.
		/// </summary>
		[XmlIgnore]
		public Vector4 Wzyw
		{
			get => new Vector4(W, Z, Y, W);
			set
			{
				X = value.X;
				Z = value.Y;
				Y = value.Z;
				W = value.W;
			}
		}

		/// <summary>Adds two instances.</summary>
		/// <param name="left">The first instance.</param>
		/// <param name="right">The second instance.</param>
		/// <returns>The result of the calculation.</returns>
		public static Vector4 operator +(Vector4 left, Vector4 right)
		{
			left.X += right.X;
			left.Y += right.Y;
			left.Z += right.Z;
			left.W += right.W;
			return left;
		}

		/// <summary>Subtracts two instances.</summary>
		/// <param name="left">The first instance.</param>
		/// <param name="right">The second instance.</param>
		/// <returns>The result of the calculation.</returns>
		public static Vector4 operator -(Vector4 left, Vector4 right)
		{
			left.X -= right.X;
			left.Y -= right.Y;
			left.Z -= right.Z;
			left.W -= right.W;
			return left;
		}

		/// <summary>Negates an instance.</summary>
		/// <param name="vec">The instance.</param>
		/// <returns>The result of the calculation.</returns>
		public static Vector4 operator -(Vector4 vec)
		{
			vec.X = -vec.X;
			vec.Y = -vec.Y;
			vec.Z = -vec.Z;
			vec.W = -vec.W;
			return vec;
		}

		/// <summary>Multiplies an instance by a scalar.</summary>
		/// <param name="vec">The instance.</param>
		/// <param name="scale">The scalar.</param>
		/// <returns>The result of the calculation.</returns>
		public static Vector4 operator *(Vector4 vec, float scale)
		{
			vec.X *= scale;
			vec.Y *= scale;
			vec.Z *= scale;
			vec.W *= scale;
			return vec;
		}

		/// <summary>Multiplies an instance by a scalar.</summary>
		/// <param name="scale">The scalar.</param>
		/// <param name="vec">The instance.</param>
		/// <returns>The result of the calculation.</returns>
		public static Vector4 operator *(float scale, Vector4 vec)
		{
			vec.X *= scale;
			vec.Y *= scale;
			vec.Z *= scale;
			vec.W *= scale;
			return vec;
		}

		/// <summary>
		///     Component-wise multiplication between the specified instance by a scale vector.
		/// </summary>
		/// <param name="scale">Left operand.</param>
		/// <param name="vec">Right operand.</param>
		/// <returns>Result of multiplication.</returns>
		public static Vector4 operator *(Vector4 vec, Vector4 scale)
		{
			vec.X *= scale.X;
			vec.Y *= scale.Y;
			vec.Z *= scale.Z;
			vec.W *= scale.W;
			return vec;
		}

		/// <summary>Transform a Vector by the given Matrix.</summary>
		/// <param name="vec">The vector to transform</param>
		/// <param name="mat">The desired transformation</param>
		/// <returns>The transformed vector</returns>
		public static Vector4 operator *(Vector4 vec, Matrix4 mat)
		{
			Transform(ref vec, ref mat, out var result);
			return result;
		}

		/// <summary>
		///     Transform a Vector by the given Matrix using right-handed notation
		/// </summary>
		/// <param name="mat">The desired transformation</param>
		/// <param name="vec">The vector to transform</param>
		/// <returns>The transformed vector</returns>
		public static Vector4 operator *(Matrix4 mat, Vector4 vec)
		{
			Transform(ref mat, ref vec, out var result);
			return result;
		}

		/// <summary>Transforms a vector by a quaternion rotation.</summary>
		/// <param name="quat">The quaternion to rotate the vector by.</param>
		/// <param name="vec">The vector to transform.</param>
		/// <returns>The transformed vector</returns>
		public static Vector4 operator *(Quaternion quat, Vector4 vec)
		{
			Transform(ref vec, ref quat, out var result);
			return result;
		}

		/// <summary>Divides an instance by a scalar.</summary>
		/// <param name="vec">The instance.</param>
		/// <param name="scale">The scalar.</param>
		/// <returns>The result of the calculation.</returns>
		public static Vector4 operator /(Vector4 vec, float scale)
		{
			vec.X /= scale;
			vec.Y /= scale;
			vec.Z /= scale;
			vec.W /= scale;
			return vec;
		}

		/// <summary>Compares two instances for equality.</summary>
		/// <param name="left">The first instance.</param>
		/// <param name="right">The second instance.</param>
		/// <returns>True, if left equals right; false otherwise.</returns>
		public static bool operator ==(Vector4 left, Vector4 right)
		{
			return left.Equals(right);
		}

		/// <summary>Compares two instances for inequality.</summary>
		/// <param name="left">The first instance.</param>
		/// <param name="right">The second instance.</param>
		/// <returns>True, if left does not equa lright; false otherwise.</returns>
		public static bool operator !=(Vector4 left, Vector4 right)
		{
			return !left.Equals(right);
		}

		/// <summary>
		///     Returns a pointer to the first element of the specified instance.
		/// </summary>
		/// <param name="v">The instance.</param>
		/// <returns>A pointer to the first element of v.</returns>
		[CLSCompliant(false)]
		public static unsafe explicit operator float*(Vector4 v)
		{
			return &v.X;
		}

		/// <summary>
		///     Returns a pointer to the first element of the specified instance.
		/// </summary>
		/// <param name="v">The instance.</param>
		/// <returns>A pointer to the first element of v.</returns>
		public static unsafe explicit operator IntPtr(Vector4 v)
		{
			return (IntPtr)(&v.X);
		}

		/// <summary>
		///     Returns a System.String that represents the current Vector4.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("({0}{4} {1}{4} {2}{4} {3})", (object)X, (object)Y, (object)Z, (object)W, (object)listSeparator);
		}

		/// <summary>Returns the hashcode for this instance.</summary>
		/// <returns>A System.Int32 containing the unique hashcode for this instance.</returns>
		public override int GetHashCode()
		{
			return (((((X.GetHashCode() * 397) ^ Y.GetHashCode()) * 397) ^ Z.GetHashCode()) * 397) ^ W.GetHashCode();
		}

		/// <summary>
		///     Indicates whether this instance and a specified object are equal.
		/// </summary>
		/// <param name="obj">The object to compare to.</param>
		/// <returns>True if the instances are equal; false otherwise.</returns>
		public override bool Equals(object obj)
		{
			return obj is Vector4 other && Equals(other);
		}

		/// <summary>Indicates whether the current vector is equal to another vector.</summary>
		/// <param name="other">A vector to compare with this vector.</param>
		/// <returns>true if the current vector is equal to the vector parameter; otherwise, false.</returns>
		public bool Equals(Vector4 other)
		{
			return X == (double)other.X && Y == (double)other.Y && Z == (double)other.Z && W == (double)other.W;
		}
	}
}