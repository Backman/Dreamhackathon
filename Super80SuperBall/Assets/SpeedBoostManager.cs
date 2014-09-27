using UnityEngine;
using System.Collections;

public class SpeedBoostManager : MonoBehaviour 
{
	public float MaxMultiplier = 3.0f;
	public float MinMultiplier = 1.5f;

	public SpeedBooster SpeedBoosterPrefab;

	void Start()
	{
		SpeedBoosterPrefab.CreatePool(5);
	}

	void SpawnBooster()
	{
		SpeedBooster obj = SpeedBoosterPrefab.Spawn();
		obj.Multiplier = Random.Range(MinMultiplier, MaxMultiplier);
	}
}
