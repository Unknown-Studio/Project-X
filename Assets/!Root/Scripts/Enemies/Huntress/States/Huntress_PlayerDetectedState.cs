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
                Movement.Flip();
                stateMachine.ChangeState(_huntress.MoveState);
                return;
            }

            if (performCloseRangeAction)
            {
                if(!isDetectingWallBack && Time.time >= _huntress.DodgeState.StartTime + _huntress.DodgeState.StateData.dogeCooldown)
                    stateMachine.ChangeState(_huntress.DodgeState);
                else if(isDetectingWallBack)
                    stateMachine.ChangeState(_huntress.TeleState);
            }
            else if(isPlayerInMinAgroRange)
                stateMachine.ChangeState(_huntress.RangeAttackState);
            else if (isPlayerInMaxAgroRange)
                stateMachine.ChangeState(_huntress.MoveState);
            else if (!isPlayerInMaxAgroRange)
                stateMachine.ChangeState(_huntress.LookingForPlayer);
        }
    }
}
