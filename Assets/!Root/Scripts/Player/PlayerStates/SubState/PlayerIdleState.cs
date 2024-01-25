using Suhdo.StateMachineCore;

namespace Suhdo.Player
{
	public class PlayerIdleState : PlayerGroundState
	{
		public PlayerIdleState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data)
			: base(stateMachine, entity, animBoolName, data)
		{
		}

		public override void Enter()
		{
			base.Enter();
			Movement.SetVelocityX(0f);
		}

		public override void LogicUpdate()
		{
			base.LogicUpdate();
			if (isExitingState) return;
			if (xInput != 0f) stateMachine.ChangeState(player.MoveState);
			if (yInput == -1f) stateMachine.ChangeState(player.CrouchIdleState);
		}
	}
}
