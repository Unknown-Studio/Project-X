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
        protected bool isAnimationFinished;
        protected bool isExitingState;

        protected CoreState(StateMachine stateMachine, Entity entity, string animBoolName)
        {
            this.stateMachine = stateMachine;
            this.entity = entity;
            this.animBoolName = animBoolName;
        }

        public virtual void Enter()
        {
            DoChecks();
            entity.Anim.SetBool(animBoolName, true);
            StartTime = Time.time;
            isAnimationFinished = false;
            isExitingState = false;
        }

        public virtual void Exit()
        {
            entity.Anim.SetBool(animBoolName, false);
            isExitingState = true;
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
        
        public virtual void AnimationTrigger()
        {

        }
        
        public virtual void AnimationFinishTrigger()=> isAnimationFinished = true;
    }
}
