using UnityEngine;

namespace Suhdo.StateMachineCore
{
	public class AnimationToStateMachine : MonoBehaviour
	{
		public IAttackState AttackState;

		private void TriggerAttack()
		{
			AttackState.TriggerAttack();
		}

		private void FinishAttack()
		{
			AttackState.FinishAttack();
		}
	}
}