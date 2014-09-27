using UnityEngine;
using System.Collections;

public class BaseObject : MonoBehaviour 
{
	public new Transform transform
	{
		get;
		private set;
	}

	public new GameObject gameObject
	{
		get;
		private set;
	}

	public virtual void Awake()
	{
		transform = base.transform;
		gameObject = base.gameObject;
	}
}
