using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Player
{
    public class PlayerInAirState : PlayerState
    {
        private int _xInput;
        private int _yInput;
        private bool _jumpInput;
        private bool _jumpInputStop;

        private bool _isGrounded;
        private bool _isCeiling;
        private bool _isTouchingWall;
        private bool _isTouchingWallBack;
        private bool _oldIsTouchingWall;
        private bool _oldIsTouchingWallBack;

		private bool _coyoteTime;
		private bool _isJumping;
		private bool _primaryAttackInput;
		private bool _secondaryAttackInput;


        public PlayerInAirState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data)
            : base(stateMachine, entity, animBoolName, data)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();

			_oldIsTouchingWall = _isTouchingWall;
			_oldIsTouchingWallBack = _isTouchingWallBack;
			_isCeiling = Core.CollisionSenses.Ceiling;
			_isGrounded = Core.CollisionSenses.Ground;
			_isTouchingWall = Core.CollisionSenses.WallFront;
			_isTouchingWallBack = Core.CollisionSenses.WallBack;
			
			CheckCoyoteTime();

			_xInput = player.InputHandler.NormInputX;
			_yInput = player.InputHandler.NormInputY;
			_jumpInput = player.InputHandler.JumpInput;
			_jumpInputStop = player.InputHandler.JumpInputStop;

			CheckJumpMultiplier();
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

			if (_primaryAttackInput && !_isCeiling)
			{
				stateMachine.ChangeState(player.PrimaryAttackState);
			}else if (_secondaryAttackInput && !_isCeiling)
			{
				stateMachine.ChangeState(player.SecondaryAttackState);
			}
			else if (_jumpInput && player.JumpState.CanJump())
				stateMachine.ChangeState(player.JumpState);
			else if(_isGrounded && Core.Movement.CurrentVelocity.y < 0.01f && _yInput == -1)
				stateMachine.ChangeState(player.CrouchIdleState);
			else if (_isGrounded && Core.Movement.CurrentVelocity.y < 0.01f)
				stateMachine.ChangeState(player.LandState);
			else if ((_isTouchingWall && _xInput > 0) || (_isTouchingWall && _xInput < 0))
			{
				stateMachine.ChangeState(player.WallSlideState);
			}
			else
			{
                Core.Movement.CheckIfShouldFlip(_xInput);
                Core.Movement.SetVelocityX(playerData.movementVelocity, _xInput);

                player.Anim.SetFloat("yVelocity", Core.Movement.CurrentVelocity.y);
                player.Anim.SetFloat("xVelocity", Mathf.Abs(Core.Movement.CurrentVelocity.x));
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
	            Core.Movement.SetVelocityY(Core.Movement.CurrentVelocity.y *
	                                       playerData.variableJumpHeightMultiplier);
                _isJumping = false;
            }
            else if (Core.Movement.CurrentVelocity.y <= 0f)
                _isJumping = false;
        }
    }
}