using Suhdo.StateMachineCore;

namespace Suhdo.Enemies
{
    public class EnemyFallState : EnemyState
    {
        public EnemyFallState(StateMachine stateMachine, Entity entity, string animBoolName)
            : base(stateMachine, entity, animBoolName)
        {
        }
    }
}
