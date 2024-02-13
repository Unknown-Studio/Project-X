using Suhdo.FX;
using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Player
{
    public class PlayerAirDashState : PlayerState
    {
        private Vector2 lastAIPos;

        public PlayerAirDashState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data)
            : base(stateMachine, entity, animBoolName, data)
        {
        }

        public override void Enter()
        {
            base.Enter();
            
            player.InputHandler.UserDoubleJumpInput();
            Movement.SetVelocityY(playerData.airDashSpeed);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            CheckIfShouldPlaceAfterImage();
            
            if (CollisionSenses.Ground)
            {
                stateMachine.ChangeState(player.AirDashGroundState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            Movement.SetVelocityY(playerData.airDashSpeed);
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
