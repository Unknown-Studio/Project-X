using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Player
{
    public class PlayerInAirState : PlayerState
    {
        private int _xInput;
        private bool _jumpInput;
        private bool _jumpInputStop;

        private bool _isGrounded;
        private bool _isTouchingWall;
        private bool _isTouchingWallBack;
        private bool _oldIsTouchingWall;
        private bool _oldIsTouchingWallBack;

        private bool _coyoteTime;
        private bool _isJumping;
        
        
        public PlayerInAirState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data) : base(stateMachine, entity, animBoolName, data)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();

            _oldIsTouchingWall = _isTouchingWall;
            _oldIsTouchingWallBack = _isTouchingWallBack;

            _isGrounded = core.CollisionSenses.Ground;
            _isTouchingWall = core.CollisionSenses.WallFront;
            _isTouchingWallBack = core.CollisionSenses.WallBack;
        }

        public override void Exit()
        {
            base.Exit();

            _oldIsTouchingWall = false;
            _oldIsTouchingWallBack = false;
            _isTouchingWall = false;
            _isTouchingWallBack = false;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            CheckCoyoteTime();

            _xInput = player.InputHandler.NormInputX;
            _jumpInput = player.InputHandler.JumpInput;
            _jumpInputStop = player.InputHandler.JumpInputStop;
            
            CheckJumpMultiplier();

            if (_jumpInput && player.JumpState.CanJump())
                stateMachine.ChangeState(player.JumpState);
            else if(_isGrounded && core.Movement.CurrentVelocity.y < 0.01f)
                stateMachine.ChangeState(player.LandState);
            else
            {
                core.Movement.CheckIfShouldFlip(_xInput);
                core.Movement.SetVelocityX(playerData.movementVelocity * _xInput);
                
                player.Anim.SetFloat("yVelocity", core.Movement.CurrentVelocity.y);
                player.Anim.SetFloat("xVelocity", Mathf.Abs(core.Movement.CurrentVelocity.x));
            }
        }

        public void StartCoyoteTime() => _coyoteTime = true;
        public void SetIsJumping() => _isJumping = true;

        private void CheckCoyoteTime()
        {
            if (_coyoteTime && Time.time > StartTime + playerData.coyoteTime)
            {
                _coyoteTime = false;
                player.JumpState.DecreaseAmountOffJumpLeft();
            }
        }

        private void CheckJumpMultiplier()
        {
            if (!_isJumping) return;
            if (_jumpInputStop)
            {
                core.Movement.SetVelocityY(core.Movement.CurrentVelocity.y * playerData.variableJumpHeightMultiplier);
                _isJumping = false;
            }
            else if (core.Movement.CurrentVelocity.y <= 0f)
                _isJumping = false;
        }
    }
}
