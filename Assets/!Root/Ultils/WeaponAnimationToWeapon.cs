using Suhdo.Weapons;
using UnityEngine;

namespace Suhdo.Ultils
{
	public class WeaponAnimationToWeapon : MonoBehaviour
	{
		private Weapon weapon;

		private void Start()
		{
			weapon = GetComponentInParent<Weapon>();
		}

		private void AnimationFinishTrigger()
		{
			weapon.AnimationFinishTrigger();
		}

		private void AnimationStartMovementTrigger()
		{
			weapon.AnimationStartMovementTrigger();
		}

		private void AnimationStopMovementTrigger()
		{
			weapon.AnimationStopMovementTrigger();
		}

		private void AnimationTurnOffFlip()
		{
			weapon.AnimationTurnOffFlip();
		}

		private void AnimationTurnOnFlip()
		{
			weapon.AnimationTurnOnFlip();
		}

		private void AnimationActionTrigger()
		{
			weapon.AnimationActionTrigger();
		}
	}
}


