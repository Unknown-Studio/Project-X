using Suhdo.Player;
using Suhdo.StateMachineCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suhdo
{
	public class PlayerCrouchMoveState : PlayerGroundState
	{
		public PlayerCrouchMoveState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data) : base(stateMachine, entity, animBoolName, data)
		{
		}

		public override void LogicUpdate()
		{
			base.LogicUpdate();

			core.Movement.CheckIfShouldFlip(xInput);
			core.Movement.SetVelocityX(playerData.crouchMovementVelocity * xInput);


			if (isExitingState) return;

			if (xInput == 0f && yInput == -1f) { stateMachine.ChangeState(player.CrouchIdleState); Debug.Log("CrouchMove"); }
			else if (xInput != 0f && yInput == 0f) stateMachine.ChangeState(player.MoveState);
			else if (xInput == 0f && yInput == 0f) stateMachine.ChangeState(player.MoveState);
		}

	}
}
