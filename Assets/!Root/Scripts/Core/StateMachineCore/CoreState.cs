using UnityEngine;

namespace Suhdo.StateMachineCore
{
    public abstract class CoreState
    {
        public float StartTime { get; private set; }
        
        protected StateMachine _stateMachine;
        protected Entity _entity;
        protected string _animBoolName;

        protected CoreState(StateMachine stateMachine, Entity entity, string animBoolName)
        {
            _stateMachine = stateMachine;
            _entity = entity;
            _animBoolName = animBoolName;
        }

        public virtual void Enter()
        {
            StartTime = Time.time;
            _entity.Anim.SetBool(_animBoolName, true);
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
