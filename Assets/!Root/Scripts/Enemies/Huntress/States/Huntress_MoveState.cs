using Suhdo.StateMachineCore;

namespace Suhdo.Enemies.Huntress
{
    public class Huntress_MoveState : EnemyMoveState
    {
        private Huntress _huntress;
        public Huntress_MoveState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyMoveState data) 
            : base(stateMachine, entity, animBoolName, data)
        {
            _huntress = (Huntress)enemy;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            /*if (isPlayerInMinAgroRange)
                //TODO: change to player detected state
             if(!isDetectingGround)
                //TODO: change to fall state*/
             if (isDetectingWall || !isDetectingLedge || isTimeOut)
            {
                _huntress.IdleState.SetFlipAfterIdle(!isTimeOut);
                stateMachine.ChangeState(_huntress.IdleState);
            }
        }
    }
}
