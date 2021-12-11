using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ForceShield : MonoBehaviour
{
	[SerializeField] private ForceShieldPart leftPart;
	[SerializeField] private ForceShieldPart rightPart;

	[SerializeField] private float leftShieldMaxLifeTime;
	[SerializeField] private float rightShieldMaxLifeTime;

	[SerializeField] private float shieldLoss;
	[SerializeField] private float shieldGain;

	private float _currentLeftShieldLifeTime;
	private float _currentRightShieldLifeTime;

	private bool _leftShieldIsActive = false;
	private bool _rightShieldIsActive = false;

	private bool _leftShieldIsEnabled = true;
	private bool _rightShieldISEnabled = true;

	[Inject] IPlayerMovementController playerMovementController;

	private void Start()
	{
		_currentLeftShieldLifeTime = leftShieldMaxLifeTime;
		_currentRightShieldLifeTime = rightShieldMaxLifeTime;
		
		playerMovementController.PlayerReleasedLeftShield += TurnOffLeftForceShield;
		playerMovementController.PlayerTurnedOnLeftShield += TurnOnLeftForceShield;
		playerMovementController.PlayerReleasedRightShield += TurnOffRightForceShield;
		playerMovementController.PlayerTurnedOnRightShield += TurnOnRightForceShield;
	}

	private void Update()
	{
		if (_leftShieldIsActive)
		{
			_currentLeftShieldLifeTime =
				_currentLeftShieldLifeTime - shieldLoss * Time.deltaTime <= 0 
				? 0: _currentLeftShieldLifeTime - shieldLoss * Time.deltaTime;
			if (_currentLeftShieldLifeTime == 0)
			{
				TurnOffLeftForceShield();
				_leftShieldIsEnabled = false;
			}
		}
		else
		{
			_currentLeftShieldLifeTime =
				_currentLeftShieldLifeTime + shieldGain * Time.deltaTime >= leftShieldMaxLifeTime
				? leftShieldMaxLifeTime : _currentLeftShieldLifeTime + shieldGain * Time.deltaTime;
			_leftShieldIsEnabled = _currentLeftShieldLifeTime > leftShieldMaxLifeTime / 2
				? true : false;
		}

		if (_rightShieldIsActive)
		{
			_currentRightShieldLifeTime =
				_currentRightShieldLifeTime - shieldLoss * Time.deltaTime <= 0
				? 0 : _currentRightShieldLifeTime - shieldLoss * Time.deltaTime;
			if (_currentRightShieldLifeTime == 0)
			{
				TurnOffRightForceShield();
				_rightShieldISEnabled = false;
			}
		}
		else
		{
			_currentRightShieldLifeTime =
				_currentRightShieldLifeTime + shieldGain * Time.deltaTime >= rightShieldMaxLifeTime
				? rightShieldMaxLifeTime : _currentRightShieldLifeTime + shieldGain * Time.deltaTime;
			_rightShieldISEnabled = _currentRightShieldLifeTime > rightShieldMaxLifeTime / 2
				? true : false;
		}
	}

	public void TurnOnLeftForceShield()
	{
		if (_leftShieldIsEnabled && !_leftShieldIsActive)
		{
			leftPart.gameObject.SetActive(true);
			_leftShieldIsActive = true;
		}
	}

	public void TurnOffLeftForceShield()
	{
		if (_leftShieldIsActive)
		{
			leftPart.gameObject.SetActive(false);
			_leftShieldIsActive = false;
		}
	}	
	public void TurnOnRightForceShield()
	{
		if (_rightShieldISEnabled && !_rightShieldIsActive)
		{
			rightPart.gameObject.SetActive(true);
			_rightShieldIsActive = true;
		}
	}

	public void TurnOffRightForceShield()
	{
		if (_rightShieldIsActive)
		{
			rightPart.gameObject.SetActive(false);
			_rightShieldIsActive = false;
		}
	}	

	private void OnDestroy()
	{
		playerMovementController.PlayerReleasedLeftShield -= TurnOffLeftForceShield;
		playerMovementController.PlayerTurnedOnLeftShield -= TurnOnLeftForceShield;
		playerMovementController.PlayerReleasedRightShield -= TurnOffRightForceShield;
		playerMovementController.PlayerTurnedOnRightShield -= TurnOnRightForceShield;
	}
}
