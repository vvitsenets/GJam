using UnityEngine;
using Zenject;

public class HeroPositionInstaller : MonoInstaller
{
	[SerializeField] private Transform heroObject;
	[SerializeField] private float xOffset;
	[SerializeField] private float yOffset;
	[SerializeField] private float zOffset;
	public class HeroOffsetPosition
	{
		public Vector2 xRange;
		public Vector2 yRange;
		public float z;

		public HeroOffsetPosition(Vector3 heroPosition, float xOffset, float yOffset, float zOffset)
		{
			xRange = new Vector2(heroPosition.x - xOffset, heroPosition.x + xOffset);
			yRange = new Vector2(heroPosition.y - yOffset, heroPosition.y + yOffset);
			z = heroPosition.z - zOffset;
		}
	}
	public override void InstallBindings()
	{
		HeroOffsetPosition heroOffsetPosition = 
			new HeroOffsetPosition(heroObject.position, xOffset, yOffset, zOffset);
		Container
			.Bind<HeroOffsetPosition>()
			.FromInstance(heroOffsetPosition)
			.AsSingle();
	}
}