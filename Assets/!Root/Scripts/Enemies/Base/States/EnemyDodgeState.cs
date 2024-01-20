using Suhdo.Enemies;
using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Enemies
{
    public class EnemyDodgeState : EnemyState
    {
        public D_EnemyDodgeState StateData { get; private set; }
        protected bool isDodgeOver;
        
        public EnemyDodgeState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyDodgeState data)
            : base(stateMachine, entity, animBoolName)
        {
            StateData = data;
        }

        public override void Enter()
        {
            base.Enter();

            isDodgeOver = false;
            enemy.Core.Movement.Flip();
            enemy.Core.Movement.SetVelocity(StateData.dodgeSpeed, StateData.dodgeAngle,
                enemy.Core.Movement.FacingDirection);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (Time.time >= StartTime + StateData.dodgeTime && isDetectingGround)
            {
                isDodgeOver = true;
            }
        }

        public override void Exit()
        {
            base.Exit();
            enemy.Core.Movement.Flip();
        }
    }
}
