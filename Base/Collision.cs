using System.Collections.Generic;
using System.Linq;

namespace Base
{
	public struct Line
	{
		public Vector2 start;
		public Vector2 end;

		public Line(Vector2 start, Vector2 end)
		{
			this.start = start;
			this.end = end;
		}

		public void Deconstruct(out float startX, out float startY, out float endX, out float endY)
		{
			startX = start.X;
			startY = start.Y;
			endX = end.X;
			endY = end.Y;
		}
	}

	public struct Polygon
	{
		public readonly Line[] lines;
		public readonly Vector2[] vertices;

		public Polygon(Vector2[] vertices)
		{
			this.vertices = vertices;

			List<Line> l = new List<Line>();
			for (int i = 0; i < vertices.Length; i++)
			{
				Vector2 cV = vertices[i];
				Vector2 cN = i + 1 >= vertices.Length ? vertices[0] : vertices[i + 1];

				l.Add(new Line(cV, cN));
			}

			lines = l.ToArray();
		}

		public Polygon(Vector2 position, Vector2 size)
		{
			(float width, float height) = size;

			vertices = new[]
			{
				position, new Vector2(position.X + width, position.Y), new Vector2(position.X + width, position.Y + height), new Vector2(position.X, position.Y + height)
			};

			List<Line> l = new List<Line>();
			for (int i = 0; i < vertices.Length; i++)
			{
				Vector2 cV = vertices[i];
				Vector2 cN = i + 1 >= vertices.Length ? vertices[0] : vertices[i + 1];

				l.Add(new Line(cV, cN));
			}

			lines = l.ToArray();
		}

		public Line this[int index] => lines[index];

		public static Polygon Transform(Polygon polygon, Matrix4 matrix)
		{
			return new Polygon(polygon.vertices.Select(vertex => Vector4.Transform(new Vector4(vertex.X, vertex.Y, 0f, 1f), matrix).Xy).Select(vertex => vertex).ToArray());
		}
	}

	public static class Collision
	{
		public static bool LineLine(Line line1, Line line2, out Vector2 intersection)
		{
			(float x1, float y1, float x2, float y2) = line1;
			(float x3, float y3, float x4, float y4) = line2;

			float uA = ((x4 - x3) * (y1 - y3) - (y4 - y3) * (x1 - x3)) / ((y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1));
			float uB = ((x2 - x1) * (y1 - y3) - (y2 - y1) * (x1 - x3)) / ((y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1));

			if (uA >= 0 && uA <= 1 && uB >= 0 && uB <= 1)
			{
				float intersectionX = x1 + uA * (x2 - x1);
				float intersectionY = y1 + uA * (y2 - y1);

				intersection = new Vector2(intersectionX, intersectionY);

				return true;
			}

			intersection = Vector2.Zero;

			return false;
		}

		public static bool LineLine(Line line1, Line line2)
		{
			(float x1, float y1, float x2, float y2) = line1;
			(float x3, float y3, float x4, float y4) = line2;

			float uA = ((x4 - x3) * (y1 - y3) - (y4 - y3) * (x1 - x3)) / ((y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1));
			float uB = ((x2 - x1) * (y1 - y3) - (y2 - y1) * (x1 - x3)) / ((y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1));

			return uA >= 0 && uA <= 1 && uB >= 0 && uB <= 1;
		}

		public static bool LinePolygon(Line line, Polygon rectangle)
		{
			return rectangle.lines.Any(l => LineLine(line, l));
		}

		public static bool LinePolygon(Line line, Polygon rectangle, out (Line line, Vector2 intersection) point)
		{
			bool result = LinePolygon(line, rectangle, out IEnumerable<(Line line, Vector2 intersection)> intersections);

			point = intersections.OrderBy(x => Vector2.DistanceSquared(line.start, x.intersection)).FirstOrDefault();
			return result;
		}

		public static bool LinePolygon(Line line, Polygon rectangle, out IEnumerable<Vector2> intersections)
		{
			List<Vector2> list = new List<Vector2>();

			foreach (Line rectangleLine in rectangle.lines)
			{
				if (LineLine(line, rectangleLine, out Vector2 intersection)) list.Add(intersection);
			}

			intersections = list;
			return list.Count > 0;
		}

		public static bool LinePolygon(Line line, Polygon rectangle, out IEnumerable<(Line, Vector2)> intersections)
		{
			List<(Line, Vector2)> list = new List<(Line, Vector2)>();

			foreach (Line rectangleLine in rectangle.lines)
			{
				if (LineLine(line, rectangleLine, out Vector2 intersection)) list.Add((rectangleLine, intersection));
			}

			intersections = list;
			return list.Count > 0;
		}

		public static bool PointPolygon(Polygon polygon, Vector2 point)
		{
			bool collision = false;
			(float x, float y) = point;

			for (int current = 0; current < polygon.vertices.Length; current++)
			{
				var next = current + 1;
				if (next == polygon.vertices.Length) next = 0;

				(float cX, float cY) = polygon.vertices[current];
				(float nX, float nY) = polygon.vertices[next];

				if ((cY >= y && nY < y || cY < y && nY >= y) && x < (nX - cX) * (y - cY) / (nY - cY) + cX)
				{
					collision = !collision;
				}
			}

			return collision;
		}
	}
}