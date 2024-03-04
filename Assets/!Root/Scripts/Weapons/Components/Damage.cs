using Suhdo.CharacterCore;
using UnityEngine;

namespace Suhdo.Weapons.Components
{
	public class Damage : WeaponComponent<DamageData, AttackDamage>
	{
		private ActionHitBox _hitBox;

		protected override void Awake()
		{
			base.Awake();

			_hitBox = GetComponent<ActionHitBox>();
		}

		protected override void OnEnable()
		{
			base.OnEnable();

			_hitBox.OnDetectedCollider2D += HandleDetectedCollier2D;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			
			_hitBox.OnDetectedCollider2D -= HandleDetectedCollier2D;
		}

		private void HandleDetectedCollier2D(Collider2D[] colliders)
		{
			foreach (var item in colliders)
			{
				if (item.TryGetComponent<IDamageable>(out var damageable))
				{
					damageable.Damage(currentAttackData.Amount);
				}
			}
		}
	}
}