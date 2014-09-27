using UnityEngine;
using System.Collections;

public class FollowTarget : BaseObject
{
	public Transform Target;
	public Vector3 Offset;
	public float FollowSpeed = 1.0f;
	public float RotationSpeed = 1.0f;

	private Vector3 _direction;
	private Quaternion _lookRotation;


	void Update()
	{
		if(Target != null)
		{
			_direction = (Target.position - transform.position).normalized;

			_lookRotation = Quaternion.LookRotation(_direction);

			transform.rotation = _lookRotation;// Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);

			Vector3 newPos = Vector3.Lerp(transform.position, Target.position + Offset, Time.deltaTime * FollowSpeed); // Target.position + Offset; 
			transform.position = newPos;
		}
	}
}

