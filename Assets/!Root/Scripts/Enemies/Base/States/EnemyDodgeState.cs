using Suhdo.Enemies;
using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Enemies
{
    public class EnemyDodgeState : EnemyState
    {
        protected D_EnemyDodgeState stateData;
        protected bool isDodgeOver;
        
        public EnemyDodgeState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyDodgeState data)
            : base(stateMachine, entity, animBoolName)
        {
            stateData = data;
        }

        public override void Enter()
        {
            base.Enter();

            isDodgeOver = false;
            enemy.EnemyCore.EnemyMovement.Flip();
            enemy.EnemyCore.EnemyMovement.SetVelocity(stateData.dodgeSpeed, stateData.dodgeAngle,
                enemy.EnemyCore.EnemyMovement.FacingDirection);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (Time.time >= StartTime + stateData.dodgeTime && isDetectingGround)
            {
                isDodgeOver = true;
            }
        }

        public override void Exit()
        {
            base.Exit();
            enemy.EnemyCore.EnemyMovement.Flip();
        }
    }
}
