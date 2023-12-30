using Suhdo.StateMachineCore;

namespace Suhdo.Player
{
    public class PlayerGroundState : PlayerState
    {
        protected int xInput;
        protected int yInput;

        private bool _jumpInput;
        private bool _isGrounded;
        private bool _isTouchingWall;
        
        public PlayerGroundState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data) 
            : base(stateMachine, entity, animBoolName, data)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();

            _isGrounded = PlayerCore.PlayerCollisionSenses.Ground;
            _isTouchingWall = PlayerCore.PlayerCollisionSenses.WallFront;
        }

        public override void Enter()
        {
            base.Enter();
            
            player.JumpState.ResetAmountOffJumpLeft();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (entity is not PlayerController player) return;
            
            xInput = player.InputHandler.NormInputX;
            yInput = player.InputHandler.NormInputY;
            _jumpInput = player.InputHandler.JumpInput;

			if (_jumpInput && player.JumpState.CanJump())
            {
                stateMachine.ChangeState(player.JumpState);
            }
            else if (!_isGrounded)
            {
                player.InAirState.StartCoyoteTime();
                stateMachine.ChangeState(player.InAirState);
            }
        }
    }
}