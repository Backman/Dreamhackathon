using UnityEngine;
using System.Collections;

public static class ExtensionMethods
{
	private const float _scale = 1.0f / 1000.0f;
	public static Vector3 Subtract(this EyeXSingleEyePosition eyePos, EyeXSingleEyePosition otherEyePos)
	{
		float x = eyePos.X - otherEyePos.X;
		float y = eyePos.Y - otherEyePos.Y;
		float z = eyePos.Z - otherEyePos.Z;

		return new Vector3(x, y, z);
	}

	public static Vector3 ToVector(this EyeXSingleEyePosition eyePos)
	{
		return new Vector3(eyePos.X * _scale, eyePos.Y * _scale, eyePos.Z * _scale);
	}
}
