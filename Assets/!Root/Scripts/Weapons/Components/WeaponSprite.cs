using System;
using Suhdo.Weapons.Components.ComponentData;
using UnityEngine;

namespace Suhdo.Weapons.Components
{
	public class WeaponSprite : WeaponComponent
	{
		private WeaponSpriteData data;
		
		private SpriteRenderer _baseSpriteRenderer;
		private SpriteRenderer _weaponSpriteRenderer;

		private int _currentWeaponSpriteIndex;

		protected override void Awake()
		{
			base.Awake();

			_baseSpriteRenderer = transform.Find("Base").GetComponent<SpriteRenderer>();
			_weaponSpriteRenderer = transform.Find("WeaponSprite").GetComponent<SpriteRenderer>();
			data = weapon.Data.GetData<WeaponSpriteData>();

			// TODO: fix this when create weapon data
			// _baseSpriteRenderer = weapon.BaseGameObject.GetComponent<SpriteRenderer>();
			// _weaponSpriteRenderer = weapon.WeaponSpriteGameObject.GetComponent<SpriteRenderer>();
		}

		protected override void OnEnable()
		{
			base.OnEnable();

			_baseSpriteRenderer.RegisterSpriteChangeCallback(OnBaseSpriteChangeHandler);
		}

		protected override void OnDisable()
		{
			base.OnDisable();

			_baseSpriteRenderer.UnregisterSpriteChangeCallback(OnBaseSpriteChangeHandler);
		}

		private void OnBaseSpriteChangeHandler(SpriteRenderer sprite)
		{
			if (!isAttackActive)
			{
				_weaponSpriteRenderer.sprite = null;
				return;
			}

			var currentAttackSprite = data.AttackData[weapon.CurrentAttackCounter].Sprites;

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