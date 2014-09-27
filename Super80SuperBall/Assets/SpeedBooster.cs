using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpeedBooster : EyeXGameObjectInteractorBase
{
	public float Multiplier;

	private float _timeFocused;

	protected override System.Collections.Generic.IList<IEyeXBehavior> GetEyeXBehaviorsForGameObjectInteractor ()
	{
		return new List<IEyeXBehavior>() { new EyeXGazeAware() };
	}

	public new void Update()
	{
		base.Update();

		if(GameObjectInteractor.HasGaze())
		{
			_timeFocused += Time.deltaTime;
		}
		else
		{
			_timeFocused = 0.0f;
		}

		if(_timeFocused >= 1.0f)
		{
			Messenger.Broadcast<float>("SpeedBoost", Multiplier);
			Debug.Log("SPEEEEDBOOOOST");
		}
	}
}
 