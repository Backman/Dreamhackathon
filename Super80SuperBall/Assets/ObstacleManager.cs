using UnityEngine;
using System.Collections;

public class ObstacleManager : MonoBehaviour 
{
	public Obstacle ObstaclePrefab;

	void Start()
	{
		ObstaclePrefab.CreatePool(10);
	}

	void SpawnObstacle()
	{
		ObstaclePrefab.Spawn();
	}
}