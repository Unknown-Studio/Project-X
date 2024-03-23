using Suhdo.StateMachineCore;

namespace Suhdo.Enemies.Skeleton
{
	public class Skeleton_StunState : EnemyStunState
	{
		private Skeleton _skeleton;
		
		public Skeleton_StunState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyStunState data) : base(stateMachine, entity, animBoolName, data)
		{
			_skeleton = entity as Skeleton; 
		}

		public override void LogicUpdate()
		{
			base.LogicUpdate();

			if (!isTimeOver) return;
			
			if (isPlayerInMaxAgroRange)
				stateMachine.ChangeState(_skeleton.PlayerDetectedState);
			else if(!isDetectingGround)
				stateMachine.ChangeState(_skeleton.FallState);
			else 
			{
				stateMachine.ChangeState(_skeleton.IdleState);
			}
		}
	}
}