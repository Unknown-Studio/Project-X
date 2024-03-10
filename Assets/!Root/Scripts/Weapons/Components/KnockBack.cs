using Suhdo.CharacterCore;
using UnityEngine;

namespace Suhdo.Weapons.Components
{
	public class KnockBack : WeaponComponent<KnockBackData, AttackKnockBack>
	{
		private ActionHitBox _hitBox;
		private Suhdo.Movement _coreMovement;

		protected override void Start()
		{
			base.Start();

			_hitBox = GetComponent<ActionHitBox>();
			_hitBox.OnDetectedCollider2D += HandleDetectedCollier2D;

			_coreMovement = Core.GetCoreComponent<Suhdo.Movement>();
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
				if (item.TryGetComponent<IKnockbackable>(out var knockBackable))
				{
					knockBackable.Knockback(currentAttackData.Angle, currentAttackData.Strength, _coreMovement.FacingDirection);
				}
			}
		}
	}
}