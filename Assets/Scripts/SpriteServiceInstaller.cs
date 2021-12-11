using UnityEngine;
using Zenject;

public class SpriteServiceInstaller : MonoInstaller
{
	[SerializeField] private SpriteService spriteService;
	public override void InstallBindings()
	{
		BindSpriteService();
	}
	private void BindSpriteService()
	{
		Container.Bind<SpriteService>().FromInstance(spriteService).AsSingle();	
	}
}

