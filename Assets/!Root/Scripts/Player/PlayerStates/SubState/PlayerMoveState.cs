using Suhdo.StateMachineCore;

namespace Suhdo.Player
{
	public class PlayerMoveState : PlayerGroundState
	{
		public PlayerMoveState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data) : base(stateMachine, entity, animBoolName, data)
		{
		}

		public override void LogicUpdate()
		{
			base.LogicUpdate();

			PlayerCore.PlayerMovement.CheckIfShouldFlip(xInput);

			if (isExitingState) return;

            if (_isCeiling)
            {
				if (xInput != 0f) stateMachine.ChangeState(player.CrouchMoveState);
				if (xInput == 0f) stateMachine.ChangeState(player.CrouchIdleState);
			}
			else
            {
				if (xInput == 0f) stateMachine.ChangeState(player.IdleState);
				if (yInput == -1f) stateMachine.ChangeState(player.CrouchMoveState);
			}
		}
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
			PlayerCore.PlayerMovement.SetVelocityX(playerData.movementVelocity * xInput);
		}
	}
}
