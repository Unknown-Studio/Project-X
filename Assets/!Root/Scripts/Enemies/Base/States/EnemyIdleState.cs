using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Enemies
{
    public class EnemyIdleState : EnemyState
    {
        protected D_EnemyIdleState stateData;

        protected bool flipAfterIdle;
        protected bool isIdleTimeOver;
        protected bool isPlayerInMinAgroRange;
        
        protected float idleTime;
        
        public EnemyIdleState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyIdleState data)
            : base(stateMachine, entity, animBoolName)
        {
            stateData = data;
        }

        public override void DoChecks()
        {
            base.DoChecks();
            isPlayerInMinAgroRange = enemy.Core.CollisionSenses.PlayerInMinAgroRange;
        }

        public override void Enter()
        {
            base.Enter();
            
            core.Movement.SetVelocityZero();
            isIdleTimeOver = false;
            RandomIdleTime();
        }

        public override void Exit()
        {
            base.Exit();

            if (flipAfterIdle)
            {
                core.Movement.Flip();
            }
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (Time.time >= StartTime + idleTime)
            {
                isIdleTimeOver = true;
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            
            core.Movement.SetVelocityZero();
        }

        public void SetFlipAfterIdle(bool isFlip)
        {
            flipAfterIdle = isFlip;
        }

        private void RandomIdleTime()
        {
            idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
        }
    }
}
