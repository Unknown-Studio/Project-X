using Suhdo.StateMachineCore;

namespace Suhdo.Enemies.Huntress
{
    public class Huntress_TeleState : TeleState
    {
        private Huntress _huntress;
        
        public Huntress_TeleState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyTeleState data)
            : base(stateMachine, entity, animBoolName, data)
        {
            _huntress = (Huntress)enemy;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if(teleDone)
                stateMachine.ChangeState(_huntress.PlayerDetectedState);
        }
    }
}
