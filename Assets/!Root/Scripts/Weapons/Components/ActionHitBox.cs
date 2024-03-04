using System;
using Suhdo.Generics;
using Unity.VisualScripting;
using UnityEngine;

namespace Suhdo.Weapons.Components
{
	public class ActionHitBox : WeaponComponent<ActionHitBoxData, AttackActionHitBox>
	{
		public event Action<Collider2D[]> OnDetectedCollider2D;
		private CoreComp<Suhdo.Movement> _movement;
		private Vector2 _offset;
		private Collider2D[] _detected;

		protected override void Start()
		{
			base.Start();

			_movement = new CoreComp<Suhdo.Movement>(Core);
		}

		protected override void OnEnable()
		{
			base.OnEnable();

			eventHandler.OnAttackAction += HandleAttackAction;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			
			eventHandler.OnAttackAction -= HandleAttackAction;
		}

		private void HandleAttackAction()
		{
			_offset.Set(
				transform.position.x + (currentAttackData.HitBox.center.x * _movement.Comp.FacingDirection),
				transform.position.y + currentAttackData.HitBox.center.y
				);

			_detected = Physics2D.OverlapBoxAll(_offset, currentAttackData.HitBox.size, 0f, data.DetectableLayer);

			if (_detected.Length <= 0) return;
			
			OnDetectedCollider2D?.Invoke(_detected);
		}

		private void OnDrawGizmosSelected()
		{
			if (data == null) return;

			foreach (var item in data.AttackData)
			{
				if(!item.Debug) continue;
				Gizmos.DrawWireCube(transform.position + (Vector3)item.HitBox.center, item.HitBox.size);
			}
		}
	}
}