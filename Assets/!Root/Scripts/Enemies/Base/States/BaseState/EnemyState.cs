using Suhdo.CharacterCore;
using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Enemies
{
    public class EnemyState : CoreState
    {
        protected Enemy enemy;
        protected Core core;

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
            core = enemy.Core;
        }

        public override void DoChecks()
        {
            base.DoChecks();
            isDetectingGround = core.CollisionSenses.Ground;
            isDetectingLedge = core.CollisionSenses.Ledge;
            isDetectingWall = core.CollisionSenses.WallFront;
            isDetectingWallBack = core.CollisionSenses.WallBack;
            isPlayerInMinAgroRange = core.CollisionSenses.PlayerInMinAgroRange;
            isPlayerInMaxAgroRange = core.CollisionSenses.PlayerInMaxAgroRange;
            performCloseRangeAction = core.CollisionSenses.PlayerInCloseRangeAction;
        }
    }
}
