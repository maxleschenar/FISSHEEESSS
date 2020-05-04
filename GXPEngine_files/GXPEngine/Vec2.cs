using System;
using GXPEngine; // For Mathf

public struct Vec2
{
	public float x;
	public float y;

	public static Vec2 ZERO = new Vec2(0, 0);

	public Vec2(float x, float y)
	{
		this.x = x;
		this.y = y;
	}

	public static Vec2 operator +(Vec2 left, Vec2 right)
	{
		return new Vec2(left.x + right.x, left.y + right.y);
	}

	public static Vec2 operator -(Vec2 left, Vec2 right)
	{
		return new Vec2(left.x - right.x, left.y - right.y);
	}

	public static Vec2 operator *(Vec2 vector, float value)
	{
		return new Vec2(vector.x * value, vector.y * value);
	}

	public static Vec2 operator *(float value, Vec2 vector)
	{
		return new Vec2(vector.x * value, vector.y * value);
	}

	public static Vec2 operator *(Vec2 vec1, Vec2 Vec2)
	{
		return new Vec2(vec1.x * Vec2.x, vec1.y * Vec2.y);
	}

	public static Vec2 operator /(Vec2 vec1, Vec2 vec2)
	{
		return new Vec2(vec1.x / vec2.x, vec1.y / vec2.y);
	}

	public static Vec2 operator /(Vec2 vec, float value)
	{
		return new Vec2(vec.x / value, vec.y / value);
	}

	public float GetLength()
	{
		return (float)Math.Sqrt(x * x + y * y);
	}

	public void Normalize()
	{
		float length = GetLength();
		x /= length;
		y /= length;
	}

	public Vec2 Normalized()
	{
		Vec2 vec = this;
		vec.Normalize();
		return vec;
	}

	public static Vec2 GetNormalizedVector(Vec2 vector)
	{
		vector.Normalize();
		return vector;
	}

	public void SetXY(float x, float y)
	{
		this.x = x;
		this.y = y;
	}

	public static float Deg2Rad(float degrees)
	{
		float radians = degrees * Mathf.PI / 180f;
		return radians;
	}

	public static float Rad2Deg(float radians)
	{
		float degrees = radians * 180f / Mathf.PI;
		return degrees;
	}

	public static Vec2 GetUnitVectorDeg(float degrees, float length)
	{
		float x, y;
		float radians = Deg2Rad(degrees);
		x = length * Mathf.Cos(radians);
		y = length * Mathf.Sin(radians);
		return new Vec2(x, y);
	}

	public static Vec2 GetUnitVectorRad(float radians, float length)
	{
		float x, y;
		x = length * Mathf.Cos(radians);
		y = length * Mathf.Sin(radians);
		return new Vec2(x, y);
	}

	public static Vec2 RandomUnitVector(float length)
	{
		float x, y;
		float degrees = Utils.Random(0, 360);
		float radians = Deg2Rad(degrees);
		x = length * Mathf.Cos(radians);
		y = length * Mathf.Sin(radians);
		return new Vec2(x, y);
	}

	public static Vec2 MoveTowards(Vec2 start, Vec2 target, float speed)
	{
		Vec2 diff = (target - start).Normalized();
		diff *= speed;
		return diff;
	}

	public static Vec2 Lerp(Vec2 start, Vec2 target, float speed)
	{
		Vec2 diff = (target - start).Normalized();
		return start.Normalized() + speed * diff;
	}

	public void SetAngleDegrees(float degrees)
	{
		float length = GetLength();
		float radians = Deg2Rad(degrees);
		x = length * Mathf.Cos(radians);
		y = length * Mathf.Sin(radians);
	}

	public void SetAngleRadians(float radians)
	{
		float length = GetLength();
		x = length * Mathf.Cos(radians);
		y = length * Mathf.Sin(radians);
	}

	public float GetAngleRadians()
	{
		return Mathf.Atan2(y, x);
	}

	public float GetAngleDegrees()
	{
		return Rad2Deg(Mathf.Atan2(y, x));
	}

	public Vec2 RotateDegrees(float degrees)
	{
		float radians = Deg2Rad(degrees);
		return new Vec2(x * Mathf.Cos(radians) - y * Mathf.Sin(radians), x * Mathf.Sin(radians) + y * Mathf.Cos(radians));
	}

	public Vec2 RotateRadians(float radians)
	{
		return new Vec2(x * Mathf.Cos(radians) - y * Mathf.Sin(radians), x * Mathf.Sin(radians) + y * Mathf.Cos(radians));
	}

	public Vec2 RotateAroundPointDeg(float degrees, Vec2 point)
	{
		float radians = Deg2Rad(degrees);
		return new Vec2(x * Mathf.Cos(radians) - y * Mathf.Sin(radians) + point.x, x * Mathf.Sin(radians) + y * Mathf.Cos(radians) + point.y);
	}

	public Vec2 RotateAroundPointRad(float radians, Vec2 point)
	{
		return new Vec2(x * Mathf.Cos(radians) - y * Mathf.Sin(radians) + point.x, x * Mathf.Sin(radians) + y * Mathf.Cos(radians) + point.y);
	}

	public override string ToString()
	{
		return String.Format("({0},{1})", x, y);
	}
}

