using Suhdo.Player;
using Suhdo.StateMachineCore;
using UnityEngine.Playables;

namespace Suhdo
{
    public class PlayerGroundState : CoreState
    {
        protected int xInput;
        protected int yInput;

        protected PlayerData data;

        private bool _jumpInput;
        private bool _isGrounded;
        private bool _isTouchingWall;
        
        public PlayerGroundState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data)
            : base(stateMachine, entity, animBoolName)
        {
            this.data = data;
        }

        public override void DoChecks()
        {
            base.DoChecks();

            _isGrounded = core.CollisionSenses.Ground;
            _isTouchingWall = core.CollisionSenses.WallFront;
        }

        public override void Enter()
        {
            base.Enter();

        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (entity is not PlayerController player) return;
            
            xInput = player.InputHandler.NormInputX;
            yInput = player.InputHandler.NormInputY;
            _jumpInput = player.InputHandler.JumpInput;
        }
    }
}