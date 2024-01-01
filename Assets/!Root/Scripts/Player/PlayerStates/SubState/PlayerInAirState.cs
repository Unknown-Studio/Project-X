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
        private bool _isCelling;
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
            _isCelling = PlayerCore.PlayerCollisionSenses.Celling;
            _isGrounded = PlayerCore.PlayerCollisionSenses.Ground;
            _isTouchingWall = PlayerCore.PlayerCollisionSenses.WallFront;
            _isTouchingWallBack = PlayerCore.PlayerCollisionSenses.WallBack;
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

			if (!_isCelling)
			{
                CheckCoyoteTime();

                _xInput = player.InputHandler.NormInputX;
                _jumpInput = player.InputHandler.JumpInput;
                _jumpInputStop = player.InputHandler.JumpInputStop;

                CheckJumpMultiplier();

                if (_jumpInput && player.JumpState.CanJump())
                    stateMachine.ChangeState(player.JumpState);
                else if (_isGrounded && PlayerCore.PlayerMovement.CurrentVelocity.y < 0.01f)
                    stateMachine.ChangeState(player.LandState);
                else
                {
                    PlayerCore.PlayerMovement.CheckIfShouldFlip(_xInput);
                    PlayerCore.PlayerMovement.SetVelocityX(playerData.movementVelocity * _xInput);

                    player.Anim.SetFloat("yVelocity", PlayerCore.PlayerMovement.CurrentVelocity.y);
                    player.Anim.SetFloat("xVelocity", Mathf.Abs(PlayerCore.PlayerMovement.CurrentVelocity.x));
                }
            }
			else
			{
                stateMachine.ChangeState(player.CrouchIdleState);
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
                PlayerCore.PlayerMovement.SetVelocityY(PlayerCore.PlayerMovement.CurrentVelocity.y * playerData.variableJumpHeightMultiplier);
                _isJumping = false;
            }
            else if (PlayerCore.PlayerMovement.CurrentVelocity.y <= 0f)
                _isJumping = false;
        }
    }
}
