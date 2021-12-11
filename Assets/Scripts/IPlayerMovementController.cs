using System;

interface IPlayerMovementController
{
	event Action PlayerTurnedOnLeftShield;
	event Action PlayerTurnedOnRightShield;
	event Action PlayerReleasedLeftShield;
	event Action PlayerReleasedRightShield;
}
