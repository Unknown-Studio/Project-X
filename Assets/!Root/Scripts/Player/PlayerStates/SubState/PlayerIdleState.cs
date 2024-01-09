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
		}

		public override void LogicUpdate()
		{
			base.LogicUpdate();
			if (isExitingState) return;
            if (_isCeiling)
            {
				if (xInput == 0f) stateMachine.ChangeState(player.CrouchIdleState);
				if (xInput != 0f) stateMachine.ChangeState(player.CrouchMoveState);
			}
            else
            {
				if (xInput != 0f) stateMachine.ChangeState(player.MoveState);
				if (yInput == -1f) stateMachine.ChangeState(player.CrouchIdleState);
			}
		}
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
			PlayerCore.PlayerMovement.SetVelocityX(0f);
		}
	}
}
