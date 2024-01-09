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

			if (xInput == 0f) stateMachine.ChangeState(player.IdleState);
			if (yInput == -1f) stateMachine.ChangeState(player.CrouchIdleState);
		}
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
			PlayerCore.PlayerMovement.SetVelocityX(playerData.movementVelocity * xInput);
		}
	}
}
