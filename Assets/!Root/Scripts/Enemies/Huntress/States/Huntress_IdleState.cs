using Suhdo.Enemies;
using Suhdo.Enemies.Huntress;
using Suhdo.StateMachineCore;

namespace Suhdo
{
    public class Huntress_IdleState : EnemyIdleState
    {
        private Huntress _huntress;
        
        public Huntress_IdleState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyIdleState data)
            : base(stateMachine, entity, animBoolName, data)
        {
            _huntress = (Huntress)enemy;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            /*if (isPlayerInMinAgroRange)
                //TODO: change to player detected state
            if(!isDetectingGround)*/
                //TODO: change to fall state
            if(isIdleTimeOver)
                stateMachine.ChangeState(_huntress.MoveState);
        }

        
    }
}
