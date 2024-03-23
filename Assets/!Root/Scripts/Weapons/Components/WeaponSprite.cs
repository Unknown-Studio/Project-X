using System.Linq;
using UnityEngine;

namespace Suhdo.Weapons.Components
{
	public class WeaponSprite : WeaponComponent<WeaponSpriteData, AttackSprites>
	{
		private SpriteRenderer _baseSpriteRenderer;
		private SpriteRenderer _weaponSpriteRenderer;

		private int _currentWeaponSpriteIndex;

		private Sprite[] _currentSPhaseSprites;

		protected override void Start()
		{
			base.Start();
			_baseSpriteRenderer = weapon.BaseGameObject.GetComponent<SpriteRenderer>();
			_weaponSpriteRenderer = weapon.WeaponSpriteGameObject.GetComponent<SpriteRenderer>();
			
			_baseSpriteRenderer.RegisterSpriteChangeCallback(OnBaseSpriteChangeHandler);

			eventHandler.OnEnterAttackPhase += HandleEnterAttackPhase;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();

			_baseSpriteRenderer.UnregisterSpriteChangeCallback(OnBaseSpriteChangeHandler);
			eventHandler.OnEnterAttackPhase -= HandleEnterAttackPhase;
		}

		private void HandleEnterAttackPhase(AttackPhases phase)
		{
			_currentWeaponSpriteIndex = 0;
			_currentSPhaseSprites = currentAttackData.PhaseSprites.FirstOrDefault(data => data.Phase == phase).Sprites;
		}

		private void OnBaseSpriteChangeHandler(SpriteRenderer sprite)
		{
			if (!isAttackActive)
			{
				_weaponSpriteRenderer.sprite = null;
				return;
			}

			if (_currentWeaponSpriteIndex >= _currentSPhaseSprites.Length)
			{
				Debug.LogWarning($"{weapon.name} weapon sprite length mismatch");
				return;
			}
			
			_weaponSpriteRenderer.sprite = _currentSPhaseSprites[_currentWeaponSpriteIndex];
			_currentWeaponSpriteIndex++;
		}

		protected override void EnterHandle()
		{
			base.EnterHandle();
			
			_currentWeaponSpriteIndex = 0;
		}
	}
}