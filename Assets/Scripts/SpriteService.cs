using UnityEngine;

public class SpriteService: MonoBehaviour
{
	[SerializeField] private Sprite simpleBulletSprite;
	public Sprite GetSimpleBulletSprite()
	{
		return simpleBulletSprite;
	}
}
