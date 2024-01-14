using Suhdo.StateMachineCore;

namespace Suhdo.Player
{
    public class PlayerGroundState : PlayerState
    {
        protected int xInput;
        protected int yInput;
        protected bool _isCeiling;

        private bool _jumpInput;
        protected bool primaryAttackInput;
        protected bool secondaryAttackInput;
        protected bool _rollInput;
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
            _isCeiling = PlayerCore.PlayerCollisionSenses.Ceiling;
            
            
        }

        public override void Enter()
        {
            base.Enter();
            
            player.JumpState.ResetAmountOffJumpLeft();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            xInput = player.InputHandler.NormInputX;
            yInput = player.InputHandler.NormInputY;
            _jumpInput = player.InputHandler.JumpInput;
            _rollInput = player.InputHandler.RollInput;
            primaryAttackInput = player.InputHandler.AttackInputs[(int)CombatInputs.Primary];
            secondaryAttackInput = player.InputHandler.AttackInputs[(int)CombatInputs.Secondary];

            if (primaryAttackInput && !_isCeiling)
            {
                stateMachine.ChangeState(player.PrimaryAttackState);
            }else if (secondaryAttackInput && !_isCeiling)
            {
                stateMachine.ChangeState(player.SecondaryAttackState);
            }
            else if (_jumpInput && player.JumpState.CanJump()&& !_isCeiling)
            {
                stateMachine.ChangeState(player.JumpState);
            }
            else if (!_isGrounded)
            {
                player.InAirState.StartCoyoteTime();
                stateMachine.ChangeState(player.InAirState);
            }
            else if (_rollInput)
            {
                stateMachine.ChangeState(player.RollState);
            }
        }
    }
}