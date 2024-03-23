using UnityEngine;

namespace Suhdo.Weapons.Components
{
	public class WeaponSprite : WeaponComponent<WeaponSpriteData, AttackSprites>
	{
		private SpriteRenderer _baseSpriteRenderer;
		private SpriteRenderer _weaponSpriteRenderer;

		private int _currentWeaponSpriteIndex;

		protected override void Start()
		{
			base.Start();
			_baseSpriteRenderer = weapon.BaseGameObject.GetComponent<SpriteRenderer>();
			_weaponSpriteRenderer = weapon.WeaponSpriteGameObject.GetComponent<SpriteRenderer>();
			
			_baseSpriteRenderer.RegisterSpriteChangeCallback(OnBaseSpriteChangeHandler);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();

			_baseSpriteRenderer.UnregisterSpriteChangeCallback(OnBaseSpriteChangeHandler);
		}

		private void OnBaseSpriteChangeHandler(SpriteRenderer sprite)
		{
			if (!isAttackActive)
			{
				_weaponSpriteRenderer.sprite = null;
				return;
			}

			var currentAttackSprite = currentAttackData.Sprites;

			if (_currentWeaponSpriteIndex >= currentAttackSprite.Length)
			{
				Debug.LogWarning($"{weapon.name} weapon sprite length mismatch");
				return;
			}
			
			_weaponSpriteRenderer.sprite = currentAttackSprite[_currentWeaponSpriteIndex];
			_currentWeaponSpriteIndex++;
		}

		protected override void EnterHandle()
		{
			base.EnterHandle();
			
			_currentWeaponSpriteIndex = 0;
		}
	}
}