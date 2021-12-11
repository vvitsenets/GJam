using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class SimpleBullet : MonoBehaviour, IProjectile
{
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private Color flightScaleColor;
	[SerializeField] private Color damageScaleColor;
	[SerializeField] private float projectileFlySpeed;
	[SerializeField] private Vector2 finalXYScale;
	[SerializeField] private float scaleCoef;

	[SerializeField] private Vector3 holdingRotation;
	[SerializeField] private float holdingRotationSpeed;

	private List<Tween> _bulletTweens = new List<Tween>();

	public void ShootProjectileForward(Vector3 target)
	{
		float distance = Vector3.Distance(transform.position, target);
		float xScaleValue = (finalXYScale.x - distance * scaleCoef) > 0 ? finalXYScale.x - distance * scaleCoef : 0;
		float yScaleValue = (finalXYScale.y - distance * scaleCoef) > 0 ? finalXYScale.y - distance * scaleCoef : 0;
		float scaleDuration = distance/projectileFlySpeed;

		transform.localScale = new Vector2(xScaleValue, yScaleValue);
		Tween moveTween = transform
			.DOMove(target, projectileFlySpeed)
			.SetSpeedBased(true)
			.SetEase(Ease.Linear);

		Tween scaleTween = transform
			.DOScale(finalXYScale, scaleDuration)
			.SetEase(Ease.Linear);

		Tween colorTween = spriteRenderer
			.DOColor(flightScaleColor, scaleDuration);

		_bulletTweens.Add(moveTween);
		_bulletTweens.Add(scaleTween);
		_bulletTweens.Add(colorTween);

		moveTween.onComplete += OnTargetReached;
		moveTween.onKill -= OnTargetReached;
	}

	public void ShootProjectileBackward(Vector3 target)
	{
		Tween moveTween = transform
			.DOBlendableMoveBy(target, projectileFlySpeed)
			.SetLoops(-1, LoopType.Incremental)
			.SetEase(Ease.Linear);
	}

	public void HoldProjectileInPlace()
	{
		if (_bulletTweens.Count > 0)
		{
			foreach (Tween tween in _bulletTweens)
			{
				tween.Kill(complete: false);
			}
		}
		Tween placeRotation = transform
			.DORotate(holdingRotation, holdingRotationSpeed)
			.SetSpeedBased(true)
			.SetEase(Ease.Linear)
			.SetLoops(-1, LoopType.Incremental);
	}

	public void OnTargetReached()
	{
		//TO-DO able to catch
		//TO-DO damage player
		Destroy(this.gameObject);

	}
}
