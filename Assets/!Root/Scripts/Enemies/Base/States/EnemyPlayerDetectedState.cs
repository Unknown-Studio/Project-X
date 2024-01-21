using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Enemies
{
    public class EnemyPlayerDetectedState : EnemyState
    {
        protected D_EnemyPlayerDetectedState stateData;
        
        protected bool performLongRangeAction;
        
        public EnemyPlayerDetectedState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyPlayerDetectedState data)
            : base(stateMachine, entity, animBoolName)
        {
            stateData = data;
        }

        public override void Enter()
        {
            base.Enter();
            
            performLongRangeAction = false;
            enemy.Core.Movement.SetVelocityZero();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (Time.time >= StartTime + stateData.LongRangeActionTime)
                performLongRangeAction = true;
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            enemy.Core.Movement.SetVelocityZero();
        }
    }
}
