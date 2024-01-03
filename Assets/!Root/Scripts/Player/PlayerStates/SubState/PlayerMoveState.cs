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
			PlayerCore.PlayerMovement.SetVelocityX(playerData.movementVelocity * xInput);

			if (isExitingState) return;

			if (xInput == 0f) stateMachine.ChangeState(player.IdleState);
			if (yInput == -1f) stateMachine.ChangeState(player.CrouchMoveState);
		}
	}
}
