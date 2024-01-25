using Suhdo.CharacterCore;
using UnityEngine;

namespace Suhdo.StateMachineCore
{
    public abstract class CoreState
    {
        public float StartTime { get; private set; }
        
        protected StateMachine stateMachine;
        protected Entity entity;
        protected Core Core;
        
        protected string animBoolName;
        protected bool isAnimationFinished;
        protected bool isExitingState;

        protected CollisionSenses CollisionSenses => _collisionSenses ??= Core.GetCoreComponent<CollisionSenses>();
        protected Movement Movement => _movement ??= Core.GetCoreComponent<Movement>();
        protected Stats Stats => _stats ??= Core.GetCoreComponent<Stats>();

        private CollisionSenses _collisionSenses;
        private Movement _movement;
        private Stats _stats;

        protected CoreState(StateMachine stateMachine, Entity entity, string animBoolName)
        {
            this.stateMachine = stateMachine;
            this.entity = entity;
            this.animBoolName = animBoolName;
            Core = entity.Core;
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
