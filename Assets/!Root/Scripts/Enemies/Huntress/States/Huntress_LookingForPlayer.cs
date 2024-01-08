using Suhdo.StateMachineCore;

namespace Suhdo.Enemies.Huntress
{
    public class Huntress_LookingForPlayer : EnemyLookingForPlayer
    {
        private Huntress _huntress;
        
        public Huntress_LookingForPlayer(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyLookingForPlayer data) 
            : base(stateMachine, entity, animBoolName, data)
        {
            _huntress = (Huntress)enemy;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if (isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(_huntress.PlayerDetectedState);
            }
            else if (isAllTurnsTimeDone)
            {
                stateMachine.ChangeState(_huntress.MoveState);
            }
        }
    }
}
