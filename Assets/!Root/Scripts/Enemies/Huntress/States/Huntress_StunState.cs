using Suhdo.StateMachineCore;

namespace Suhdo.Enemies.Huntress
{
	public class Huntress_StunState : EnemyStunState
	{
		private Huntress _huntress;
		
		public Huntress_StunState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyStunState data)
			: base(stateMachine, entity, animBoolName, data)
		{
			_huntress = entity as Huntress;
		}

		public override void LogicUpdate()
		{
			base.LogicUpdate();
			
			if (!isTimeOver) return;
			
			if (isPlayerInMaxAgroRange)
				stateMachine.ChangeState(_huntress.PlayerDetectedState);
			else if(!isDetectingGround)
				stateMachine.ChangeState(_huntress.FallState);
			else 
			{
				stateMachine.ChangeState(_huntress.IdleState);
			}
		}
	}
}