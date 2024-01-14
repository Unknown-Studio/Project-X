using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Player
{
    public class PlayerRollState : PlayerAbilityState
    {
        protected float lastRollTime;
        
        public PlayerRollState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data) : base(stateMachine, entity, animBoolName, data)
        {
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (!isAnimationFinished) return;
            if (!isCeiling)
            {
                lastRollTime = Time.time;
                stateMachine.ChangeState(player.IdleState);
            }
        }
        
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            PlayerCore.PlayerMovement.SetVelocityX(playerData.RollVelocity * PlayerCore.PlayerMovement.FacingDirection);
        }

        public bool CheckCanRoll()
        {
            return Time.time >= lastRollTime + playerData.RollCooldown;
        }
    }
}
