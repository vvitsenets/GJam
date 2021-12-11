using System.Collections.Generic;
using UnityEngine;

public class ForceShieldPart: MonoBehaviour
{
	private List<IProjectile> _projectilesList = new List<IProjectile>();

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag.Equals("Projectile"))
		{
			IProjectile projectile = collision.gameObject.GetComponent<IProjectile>();
			projectile.HoldProjectileInPlace();
			_projectilesList.Add(projectile);
		}
	}

	private void OnEnable()
	{
		_projectilesList = new List<IProjectile>();
	}

	private void OnDisable()
	{
		ReleaseProjectiles();
	}

	private void ReleaseProjectiles()
	{
		if (_projectilesList.Count != 0)
		{
			foreach (IProjectile projectile in _projectilesList)
			{
				projectile.ShootProjectileBackward(new Vector3(0, 0, 40));
			}
		}
	}
}