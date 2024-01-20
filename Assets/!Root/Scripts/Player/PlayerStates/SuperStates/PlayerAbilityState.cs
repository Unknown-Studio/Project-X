using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Player
{
    public class PlayerAbilityState : PlayerState
    {
        protected bool isAbilityDone;

        protected bool isGrounded;
        protected bool isCeiling;
        
        public PlayerAbilityState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data) : base(stateMachine, entity, animBoolName, data)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();

            isGrounded = Core.CollisionSenses.Ground;
            isCeiling = Core.CollisionSenses.Ceiling;
        }

        public override void Enter()
        {
            base.Enter();
            isAbilityDone = false;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!isAbilityDone) return;
            if(isGrounded && Core.Movement.CurrentVelocity.y <= 0.01f)
                stateMachine.ChangeState(player.IdleState);
            else 
                stateMachine.ChangeState(player.InAirState);
        }
    }
}
