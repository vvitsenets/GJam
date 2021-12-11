using UnityEngine;

interface IProjectile
{
	void ShootProjectileForward(Vector3 target);
	void ShootProjectileBackward(Vector3 target);

	void HoldProjectileInPlace();
}
