using Suhdo.CharacterCore;
using UnityEngine;

namespace Suhdo.Weapons.Components
{
	public class Damage : WeaponComponent<DamageData, AttackDamage>
	{
		private ActionHitBox _hitBox;

		protected override void Start()
		{
			base.Start();

			_hitBox = GetComponent<ActionHitBox>();
			_hitBox.OnDetectedCollider2D += HandleDetectedCollier2D;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			
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