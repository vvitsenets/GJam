using UnityEngine;
using Zenject;

public class EnemyLogic: MonoBehaviour
{
	[SerializeField] GameObject bulletPrefab;
	[SerializeField] Transform shootingTransorm;

	[Inject]
	HeroPositionInstaller.HeroOffsetPosition heroOffsetPosition;

	private void Update()
	{
		if (Input.touchCount >= 5 || Input.GetKeyDown(KeyCode.K))
		{
			ShootBullet();
		}
	}

	private void ShootBullet()
	{
		SimpleBullet newBullet = Instantiate(bulletPrefab).GetComponent<SimpleBullet>();
		newBullet.gameObject.transform.position = shootingTransorm.position;
		newBullet.gameObject.transform.rotation = shootingTransorm.rotation;

		Vector3 targetPoint = new Vector3(
			Random.Range(heroOffsetPosition.xRange.x, heroOffsetPosition.xRange.y),
			Random.Range(heroOffsetPosition.yRange.x, heroOffsetPosition.yRange.y),
			heroOffsetPosition.z);

		newBullet.ShootProjectileForward(targetPoint);
	}

	private void HideBehindShelter()
	{

	}

	private void MovePosition()
	{

	}

	private void ShowFromShelter()
	{

	}

}
