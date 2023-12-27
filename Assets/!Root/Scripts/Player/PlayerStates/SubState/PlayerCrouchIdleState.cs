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
			core.Movement.SetVelocityX(0f);
		}

		public override void LogicUpdate()
		{
			base.LogicUpdate();
			if (isExitingState) return;

			if (xInput != 0f && yInput == -1f) { stateMachine.ChangeState(player.CrouchMoveState); Debug.Log("CrouchIdle"); }
			else if (xInput == 0f && yInput == 0f) { stateMachine.ChangeState(player.IdleState); Debug.Log("CrouchIdle"); }
			else if (xInput != 0f && yInput == 0f) { stateMachine.ChangeState(player.MoveState); Debug.Log("CrouchIdle"); }

		}
	}
}
