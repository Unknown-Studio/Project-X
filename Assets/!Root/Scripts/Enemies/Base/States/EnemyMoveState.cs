using Suhdo.StateMachineCore;
using Unity.VisualScripting;
using UnityEngine;
using StateMachine = Suhdo.StateMachineCore.StateMachine;

namespace Suhdo.Enemies
{
    public class EnemyMoveState : EnemyState
    {
        protected D_EnemyMoveState stateData;
        
        protected bool isTimeOut;

        protected float moveTime;
        
        public EnemyMoveState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyMoveState data)
            : base(stateMachine, entity, animBoolName)
        {
            stateData = data;
        }

        public override void DoChecks()
        {
            base.DoChecks();

            isTimeOut = Time.time >= StartTime + moveTime;
        }

        public override void Enter()
        {
            base.Enter();
            RandomMoveTime();
            enemyCore.EnemyMovement.SetVelocityX(stateData.MovementSpeed);
        }

        private void RandomMoveTime()
        {
            moveTime = Random.Range(stateData.MinMoveTime, stateData.MaxMoveTime);
        }
    }
}
