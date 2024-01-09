using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Enemies.Huntress
{
    public class Huntress_PlayerDetectedState : EnemyPlayerDetectedState
    {
        private Huntress _huntress;
        
        public Huntress_PlayerDetectedState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyPlayerDetectedState data)
            : base(stateMachine, entity, animBoolName, data)
        {
            _huntress = (Huntress)enemy;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if (!isDetectingLedge)
            {
                _huntress.EnemyCore.EnemyMovement.Flip();
                stateMachine.ChangeState(_huntress.MoveState);
                return;
            }
            
            if (performCloseRangeAction &&
                Time.time >= _huntress.DodgeState.StartTime + _huntress.DodgeState.StateData.dogeCooldown)
                stateMachine.ChangeState(_huntress.DodgeState);
            else if(isPlayerInMinAgroRange)
                stateMachine.ChangeState(_huntress.RangeAttackState);
            else if (isPlayerInMaxAgroRange)
                stateMachine.ChangeState(_huntress.MoveState);
            else if (!isPlayerInMaxAgroRange)
                stateMachine.ChangeState(_huntress.LookingForPlayer);
        }
    }
}
