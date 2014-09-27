using UnityEngine;
using System.Collections;

public class PlayerObject : BaseObject
{
	public int MaxLife = 3;
	private int _currentLife;

	public override void Awake ()
	{
		base.Awake ();

		_currentLife = MaxLife;
	}

	void Update()
	{
		if(_currentLife <= 0)
		{
			Messenger.Broadcast("GameOver");
			KillPlayerObject();
		}
	}

	public void DecreaseLife()
	{
		--_currentLife;
	}

	public void IncreaseLife()
	{
		++_currentLife;
	}

	private void KillPlayerObject()
	{

	}
}
