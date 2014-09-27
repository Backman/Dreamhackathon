using UnityEngine;
using System.Collections;

public class Obstacle : BaseObject
{
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Player")
		{
			Messenger.Broadcast("DoScreenShake");
			Messenger.Broadcast("DecreaseLife");
		}
	}
}
