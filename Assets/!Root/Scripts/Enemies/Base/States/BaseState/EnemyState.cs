using Suhdo.CharacterCore;
using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Enemies
{
    public class EnemyState : CoreState
    {
        protected Enemy enemy;

        protected bool isDetectingGround;
        protected bool isDetectingWall;
        protected bool isDetectingWallBack;
        protected bool isDetectingLedge;
        protected bool isPlayerInMinAgroRange;
        protected bool isPlayerInMaxAgroRange;
        protected bool performCloseRangeAction;
        
        protected CollisionSenses CollisionSenses => _collisionSenses ??= Core.GetCoreComponent<CollisionSenses>();
        protected Movement Movement => _movement ??= Core.GetCoreComponent<Movement>();
        protected Stats Stats => _stats ??= Core.GetCoreComponent<Stats>();

        private CollisionSenses _collisionSenses;
        private Movement _movement;
        private Stats _stats;
        
        public EnemyState(StateMachine stateMachine, Entity entity, string animBoolName)
            : base(stateMachine, entity, animBoolName)
        {
            enemy = (Enemy)entity;
        }

        public override void DoChecks()
        {
            base.DoChecks();
            isDetectingGround = CollisionSenses.Ground;
            isDetectingLedge = CollisionSenses.Ledge;
            isDetectingWall = CollisionSenses.WallFront;
            isDetectingWallBack = CollisionSenses.WallBack;
            isPlayerInMinAgroRange = CollisionSenses.PlayerInMinAgroRange;
            isPlayerInMaxAgroRange = CollisionSenses.PlayerInMaxAgroRange;
            performCloseRangeAction = CollisionSenses.PlayerInCloseRangeAction;
        }
    }
}
