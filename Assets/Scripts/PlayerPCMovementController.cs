using System;
using UnityEngine;

public class PlayerPCMovementController : MonoBehaviour, IPlayerMovementController
{
	public event Action PlayerTurnedOnLeftShield;
	public event Action PlayerTurnedOnRightShield;
	public event Action PlayerReleasedLeftShield;
	public event Action PlayerReleasedRightShield;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			PlayerTurnedOnRightShield();
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			PlayerTurnedOnLeftShield();
		}
		if (Input.GetKeyUp(KeyCode.R))
		{
			PlayerReleasedRightShield();
		}
		if (Input.GetKeyUp(KeyCode.E))
		{
			PlayerReleasedLeftShield();
		}
	}

}
