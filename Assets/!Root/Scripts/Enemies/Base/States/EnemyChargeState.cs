using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Enemies
{
    public class EnemyChargeState : EnemyState
    {
        protected D_EnemyChargeState stateData;

        protected bool isChargeTimeOver;
        
        public EnemyChargeState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyChargeState data)
            : base(stateMachine, entity, animBoolName)
        {
            stateData = data;
        }

        public override void Enter()
        {
            base.Enter();

            isChargeTimeOver = false;
            enemy.EnemyCore.EnemyMovement.SetVelocityX(stateData.ChargeSpeed);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (Time.time >= StartTime + stateData.ChargeTime)
                isChargeTimeOver = true;
        }
    }
}
