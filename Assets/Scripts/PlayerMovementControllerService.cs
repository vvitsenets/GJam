using Zenject;
using UnityEngine;
public class PlayerMovementControllerService: MonoInstaller
{
	[SerializeField] private PlayerPCMovementController playerPCMovementController;
	public override void InstallBindings()
	{
		Container
			.Bind<IPlayerMovementController>()
			.FromInstance(playerPCMovementController)
			.AsSingle();
	}
}