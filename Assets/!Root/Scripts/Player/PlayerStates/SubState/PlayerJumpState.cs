using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Player
{
    public class PlayerJumpState : PlayerAbilityState
    {
        private int amountOffJumpLeft;
        
        public PlayerJumpState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data) : base(stateMachine, entity, animBoolName, data)
        {
        }
        
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Jump");
            
            player.InputHandler.UserJumpInput();
            core.Movement.SetVelocityY(playerData.jumpVelocity);
            isAbilityDone = true;
            amountOffJumpLeft--;
            player.InAirState.SetIsJumping();
        }

        public bool CanJump()
        {
            return amountOffJumpLeft > 0;
        }

        public void ResetAmountOffJumpLeft() => amountOffJumpLeft = playerData.amountOfJumps;
        public void DecreaseAmountOffJumpLeft() => amountOffJumpLeft--;

    }
}
