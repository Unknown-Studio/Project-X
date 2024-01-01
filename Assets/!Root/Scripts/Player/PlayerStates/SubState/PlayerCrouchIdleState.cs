using Suhdo.Player;
using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Player
{
	public class PlayerCrouchIdleState : PlayerGroundState
	{
		public PlayerCrouchIdleState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data) : base(stateMachine, entity, animBoolName, data)
		{
		}
		public override void Enter()
		{
			base.Enter();
			PlayerCore.PlayerMovement.SetVelocityX(0f);
		}

		public override void LogicUpdate()
		{
			base.LogicUpdate();

			if (isExitingState) return;

			if (xInput != 0f && yInput == -1f) { stateMachine.ChangeState(player.CrouchMoveState); }
			else if (xInput == 0f && yInput == 0f) { stateMachine.ChangeState(player.IdleState); }
			else if (xInput != 0f && yInput == 0f) { stateMachine.ChangeState(player.MoveState); }
			if (yInput != -1f && _isCelling && xInput == 0f) stateMachine.ChangeState(player.CrouchIdleState);
			else if (yInput != -1f && _isCelling && xInput != 0f) stateMachine.ChangeState(player.CrouchMoveState);
		}
	}
}
