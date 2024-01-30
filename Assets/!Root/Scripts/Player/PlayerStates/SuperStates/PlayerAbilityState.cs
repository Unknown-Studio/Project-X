using Suhdo.CharacterCore;
using Suhdo.StateMachineCore;

namespace Suhdo.Player
{
    public class PlayerAbilityState : PlayerState
    {
        protected bool isAbilityDone;

        protected bool isGrounded;
        protected bool isCeiling;
        
        private CollisionSenses collisionSenses;
        private Movement movement;
        
        private CollisionSenses CollisionSenses => collisionSenses ??= Core.GetCoreComponent<CollisionSenses>();
        private Movement Movement => movement ??= Core.GetCoreComponent<Movement>();
        
        public PlayerAbilityState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data) : base(stateMachine, entity, animBoolName, data)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();

            isGrounded = CollisionSenses.Ground;
            isCeiling = CollisionSenses.Ceiling;
        }

        public override void Enter()
        {
            base.Enter();
            isAbilityDone = false;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!isAbilityDone) return;
            switch (isGrounded)
            {
                case true when Movement.CurrentVelocity.y <= 0.01f:
                    stateMachine.ChangeState(player.IdleState);
                    break;
                case false:
                    stateMachine.ChangeState(player.InAirState);
                    break;
            }
        }
    }
}
