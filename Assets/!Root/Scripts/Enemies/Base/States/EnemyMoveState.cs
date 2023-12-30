using Suhdo.StateMachineCore;

namespace Suhdo.Enemies
{
    public class EnemyMoveState : EnemyState
    {
        protected D_EnemyMoveState StateData;

        protected bool isDetectingWall;
        protected bool isDetectingLedge;
        protected bool isPlayerInMinAgroRange;
        
        public EnemyMoveState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyMoveState data)
            : base(stateMachine, entity, animBoolName)
        {
            StateData = data;
        }
    }
}
