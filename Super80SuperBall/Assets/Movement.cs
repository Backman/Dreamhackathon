using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : BaseObject
{
	public static float DistanceTraveled;
	
	public float MovementSpeed = 1.0f;
	public float TurnSpeed = 5.0f;

	private float _currentSpeed;
	
	[HideInInspector]
	public float SpeedModifier = 1.0f;

	public float BoostTime = 2.0f;
	private float _currentBoostTime;

	public float EyeAngleThreshold = 100;
	public float EyeSampleRate = 3;
	
	private EyeXHost _host;
	private IEyeXDataProvider<EyeXEyePosition> _eyePositionProvider;
	
	private PlayerObject _playerObject;
	 
	private Vector3 _lastCenter = Vector3.zero;
	private float _lastAngle = 0f;

	private float _prevX;

	private bool _initialized = false;
	private Vector3 _originPosition = Vector3 .zero;

	private Vector3 _targetPosition;

	private bool _moveRight = false;
	private bool _moveLeft = false;



	public override void Awake ()
	{
		base.Awake();
		_host = EyeXHost.GetInstance();
		_eyePositionProvider = _host.GetEyePositionDataProvider();

		_prevX = transform.position.x;

		_targetPosition = transform.position;
	}


	void OnEnable()
	{
		_eyePositionProvider.Start();
	}
	
	void OnDisable()
	{
		_eyePositionProvider.Stop();
	}
	
	
	void Update()
	{
		DistanceTraveled = transform.position.z;
		//if(Time.frameCount % EyeSampleRate == 0)
		{
			EyeCalculations();
		}

		
		_currentSpeed = MovementSpeed * SpeedModifier;
		Vector3 newPos = transform.position;
		newPos.z += _currentSpeed * Time.deltaTime;

		if(_moveRight)
		{
			newPos.x += TurnSpeed * Time.deltaTime;
		}
		else if(_moveLeft)
		{
			newPos.x -= TurnSpeed * Time.deltaTime;
		}


		transform.position = newPos;
	}

	private Vector3 GetCenterPosition()
	{
		var eyePosition = _eyePositionProvider.Last;
		
		var leftEye = eyePosition.LeftEye;
		var rightEye = eyePosition.RightEye;
		
		if(leftEye.IsValid && rightEye.IsValid)
		{
			Vector3 left = leftEye.ToVector();
			Vector3 right = rightEye.ToVector();

			Vector3 center = (left - right) * 0.5f;

			return center;
		}

		return Vector3.zero;
	}

	private void EyeCalculations()
	{
		var eyePosition = _eyePositionProvider.Last;
		
		var leftEye = eyePosition.LeftEye;
		var rightEye = eyePosition.RightEye;

		Debug.Log("Left Valid: " + leftEye.IsValid + ", Right Valid: " + rightEye.IsValid);
		if(leftEye.IsValid)
		{
			CheckEyePos(leftEye);
		}
		else if(rightEye.IsValid)
		{
			CheckEyePos(rightEye);
		}
	}

	private void CheckEyePos(EyeXSingleEyePosition eyePos)
	{
		Vector3 v = eyePos.ToVector();

		if(v.x * 100 > EyeAngleThreshold)
		{
			_moveRight = true;
			_moveLeft = false;
			Debug.Log("RIGHT");
		}
		else if(v.x * 100 < -EyeAngleThreshold)
		{
			_moveLeft = true;
			_moveRight = false;
			Debug.Log("RIGHT");
		}
		else
		{
			_moveLeft = false;
			_moveRight = false;
			Debug.Log("NOTHING");
		}
	}

	public void AddSpeedMultiplier(float multiplier)
	{
		_currentBoostTime = BoostTime;
		SpeedModifier = multiplier;
	}
}
