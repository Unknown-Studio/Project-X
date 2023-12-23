using Suhdo.CharacterCore;
using UnityEngine;

namespace Suhdo.StateMachineCore
{
    public abstract class CoreState
    {
        public float StartTime { get; private set; }
        
        protected StateMachine stateMachine;
        protected Entity entity;
        protected string animBoolName;
        protected Core core;

        protected CoreState(StateMachine stateMachine, Entity entity, string animBoolName)
        {
            this.stateMachine = stateMachine;
            this.entity = entity;
            this.animBoolName = animBoolName;
            core = entity.Core;
        }

        public virtual void Enter()
        {
            StartTime = Time.time;
            entity.Anim.SetBool(animBoolName, true);
            DoChecks();
        }

        public virtual void Exit()
        {
            
        }

        public virtual void LogicUpdate()
        {
            
        }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks()
        {
            
        }
    }
}
