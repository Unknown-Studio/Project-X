using System;
using UnityEngine;

namespace Suhdo.Weapons
{
	public class AnimationEventHandler : MonoBehaviour
	{
		public event Action OnFinish;
		public event Action OnStartMovement;
		public event Action OnStopMovement;
		public event Action OnAttackAction;
		public event Action<AttackPhases> OnEnterAttackPhase;
		
		private void AnimationFinishTrigger() => OnFinish?.Invoke();
		private void StartMovementTrigger() => OnStartMovement?.Invoke();
		private void StopMovementTrigger() => OnStopMovement?.Invoke();
		private void AttackActionTrigger() => OnAttackAction?.Invoke();
		private void EnterAttackPhaseTrigger(AttackPhases phase) => OnEnterAttackPhase?.Invoke(phase);
	}
}