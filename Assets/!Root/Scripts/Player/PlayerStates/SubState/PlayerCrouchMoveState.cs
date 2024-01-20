using Suhdo.Player;
using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Player
{
	public class PlayerCrouchMoveState : PlayerGroundState
	{
		public PlayerCrouchMoveState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data) : base(stateMachine, entity, animBoolName, data)
		{
		}

		public override void LogicUpdate()
		{
			base.LogicUpdate();

			Core.Movement.CheckIfShouldFlip(xInput);


			if (isExitingState) return;

			if (xInput == 0f && (yInput == -1f || _isCeiling)) stateMachine.ChangeState(player.CrouchIdleState);
			else if (xInput != 0f && yInput == 0f && !_isCeiling) stateMachine.ChangeState(player.MoveState);
			else if (xInput == 0f && yInput == 0f && !_isCeiling) stateMachine.ChangeState(player.IdleState);
		}
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
			Core.Movement.SetVelocityX(playerData.crouchMovementVelocity);
		}

	}
}
