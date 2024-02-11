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
        private bool _isTouchingLedge;

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
			_isCeiling = CollisionSenses.Ceiling;
			_isGrounded = CollisionSenses.Ground;
			_isTouchingWall = CollisionSenses.WallFront;
			_isTouchingWallBack = CollisionSenses.WallBack;
			_isTouchingLedge = CollisionSenses.Ledge;
			
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

            if (_isTouchingWall && !_isTouchingLedge && !_isGrounded)
            {
				stateMachine.ChangeState(player.LedgeClimbState);
            }
			else if (_primaryAttackInput && !_isCeiling)
			{
				stateMachine.ChangeState(player.PrimaryAttackState);
			}else if (_secondaryAttackInput && !_isCeiling)
			{
				stateMachine.ChangeState(player.SecondaryAttackState);
			}
			else if (_jumpInput && player.JumpState.CanJump())
				stateMachine.ChangeState(player.JumpState);
			else if(_isGrounded && Movement.CurrentVelocity.y < 0.01f && _yInput == -1)
				stateMachine.ChangeState(player.CrouchIdleState);
			else if (_isGrounded && Movement.CurrentVelocity.y < 0.01f)
				stateMachine.ChangeState(player.LandState);
			else if ((_isTouchingWall && _xInput > 0) || (_isTouchingWall && _xInput < 0))
			{
				stateMachine.ChangeState(player.WallSlideState);
			}
			else
			{
                Movement.CheckIfShouldFlip(_xInput);
                Movement.SetVelocityX(playerData.movementVelocity, _xInput);

                player.Anim.SetFloat("yVelocity", Movement.CurrentVelocity.y);
                player.Anim.SetFloat("xVelocity", Mathf.Abs(Movement.CurrentVelocity.x));
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
	            Movement.SetVelocityY(Movement.CurrentVelocity.y *
	                                       playerData.variableJumpHeightMultiplier);
                _isJumping = false;
            }
            else if (Movement.CurrentVelocity.y <= 0f)
                _isJumping = false;
        }
    }
}