using Suhdo.CharacterCore;
using UnityEngine;

namespace Suhdo.Weapons.Components
{
	public class PoiseDamage : WeaponComponent<PoiseDamageData, AttackPoiseDamage>
	{
		private ActionHitBox _hitBox;

		protected override void Start()
		{
			base.Start();

			_hitBox = GetComponent<ActionHitBox>();
			_hitBox.OnDetectedCollider2D += HandleDtectedCollider2D;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			
			_hitBox.OnDetectedCollider2D -= HandleDtectedCollider2D;
		}

		private void HandleDtectedCollider2D(Collider2D[] colliders)
		{
			foreach (var item in colliders)
			{
				if (item.TryGetComponent<IPoiseDamageable>(out var poiseDamageable))
				{
					poiseDamageable.PoiseDamage(currentAttackData.Amount);
				}
			}
		}
	}
}