using Suhdo.StateMachineCore;

namespace Suhdo.Enemies
{
    public class EnemyMoveState : EnemyState
    {
        protected D_EnemyMoveState stateData;

        protected bool isDetectingWall;
        protected bool isDetectingLedge;
        protected bool isPlayerInMinAgroRange;
        
        public EnemyMoveState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyMoveState data)
            : base(stateMachine, entity, animBoolName)
        {
            stateData = data;
        }

        public override void DoChecks()
        {
            base.DoChecks();

            isDetectingLedge = enemyCore.EnemyCollisionSenses.Ledge;
            isDetectingWall = enemyCore.EnemyCollisionSenses.WallFront;
            isPlayerInMinAgroRange = enemyCore.EnemyCollisionSenses.PlayerInMinAgroRange;
        }

        public override void Enter()
        {
            base.Enter();
            
            enemyCore.EnemyMovement.SetVelocityX(stateData.MovementSpeed * enemyCore.EnemyMovement.FacingDirection);
        }
    }
}
