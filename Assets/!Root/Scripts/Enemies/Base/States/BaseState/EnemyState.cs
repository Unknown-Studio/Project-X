using Suhdo.CharacterCore;
using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Enemies
{
    public class EnemyState : CoreState
    {
        protected Enemy enemy;
        protected EnemyCore enemyCore;

        protected bool isDetectingGround;
        protected bool isDetectingWall;
        protected bool isDetectingWallBack;
        protected bool isDetectingLedge;
        protected bool isPlayerInMinAgroRange;
        protected bool isPlayerInMaxAgroRange;
        protected bool performCloseRangeAction;
        
        public EnemyState(StateMachine stateMachine, Entity entity, string animBoolName)
            : base(stateMachine, entity, animBoolName)
        {
            enemy = (Enemy)entity;
            enemyCore = enemy.EnemyCore;
        }

        public override void DoChecks()
        {
            base.DoChecks();
            isDetectingGround = enemyCore.EnemyCollisionSenses.Ground;
            isDetectingLedge = enemyCore.EnemyCollisionSenses.Ledge;
            isDetectingWall = enemyCore.EnemyCollisionSenses.WallFront;
            isDetectingWallBack = enemyCore.EnemyCollisionSenses.WallBack;
            isPlayerInMinAgroRange = enemyCore.EnemyCollisionSenses.PlayerInMinAgroRange;
            isPlayerInMaxAgroRange = enemyCore.EnemyCollisionSenses.PlayerInMaxAgroRange;
            performCloseRangeAction = enemyCore.EnemyCollisionSenses.PlayerInCloseRangeAction;
        }
    }
}
