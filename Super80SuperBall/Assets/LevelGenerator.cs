using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
	public Transform Prefab = null;
	public float RecycleOffset;

	private Queue<Transform> _objectQueue = new Queue<Transform>();
	private Vector3 _nextPosition;
	public Vector3 StartPosition;

	void Awake()
	{
		if(Prefab == null)
		{
			enabled = false;
		}
	}

	void Start()
	{
		for(int i = 0; i < 10; ++i) 
		{
			_objectQueue.Enqueue((Transform)Instantiate(Prefab));
		}
		_nextPosition = StartPosition;

		for(int i = 0; i < _objectQueue.Count; ++i) 
		{
			Recycle();
		}
	}

	void Update()
	{
		if (_objectQueue.Peek().localPosition.z + RecycleOffset < Movement.DistanceTraveled) {
			Recycle();
		}
	}

	private void Recycle()
	{
		Vector3 position = _nextPosition;

		Transform o = _objectQueue.Dequeue();
		Vector3 scale = o.localScale;
		o.localPosition = position;
		_objectQueue.Enqueue(o);
		
		_nextPosition += new Vector3(0.0f, 0.0f, scale.z);
	}
}
