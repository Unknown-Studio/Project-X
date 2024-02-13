using Suhdo.FX;
using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Player
{
    public class PlayerRollState : PlayerAbilityState
    {
        protected float lastRollTime;
        
        private Vector2 lastAIPos;
        
        public PlayerRollState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data) : base(stateMachine, entity, animBoolName, data)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.SetColliderHeight(playerData.crouchColliderHeight);
        }

        public override void Exit()
        {
            base.Exit();
            player.SetColliderHeight(playerData.standColliderHeight);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            CheckIfShouldPlaceAfterImage();
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
            Movement.SetVelocityX(playerData.RollVelocity);
        }

        public bool CheckCanRoll()
        {
            return Time.time >= lastRollTime + playerData.RollCooldown;
        }
        
        private void CheckIfShouldPlaceAfterImage()
        {
            if (Vector2.Distance(player.transform.position, lastAIPos) >= playerData.DistBetweenAfterImages)
            {
                PlaceAfterImage();
            }
        }

        private void PlaceAfterImage()
        {
            // get from pool
            var _object = (AfterImageSprite) playerData.AfterImagesPool.Get();
            _object?.StartAfterImage(player.transform);
            lastAIPos = player.transform.position;
        }
    }
}
