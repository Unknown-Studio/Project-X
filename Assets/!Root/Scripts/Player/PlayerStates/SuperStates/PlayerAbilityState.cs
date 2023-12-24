using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Player
{
    public class PlayerAbilityState : PlayerState
    {
        protected bool isAbilityDone;

        private bool isGrounded;
        
        public PlayerAbilityState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data) : base(stateMachine, entity, animBoolName, data)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();

            isGrounded = core.CollisionSenses.Ground;
        }

        public override void Enter()
        {
            base.Enter();
            isAbilityDone = false;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            // Change state here
        }
    }
}
