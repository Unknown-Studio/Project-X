using UnityEngine;

namespace Suhdo.Enemies.Skeleton
{
    public class Skeleton : Enemy
    {
        [SerializeField] private D_EnemyIdleState _idleStateData;
        [SerializeField] private D_EnemyMoveState _moveStateData;
        
        public Skeleton_IdleState IdleState { get; private set; }
        public Skeleton_MoveState MoveState { get; private set; }

        protected override void Start()
        {
            base.Start();

            IdleState = new Skeleton_IdleState(StateMachine, this, "idle", _idleStateData);
            MoveState = new Skeleton_MoveState(StateMachine, this, "move", _moveStateData);
            
            StateMachine.Initiallize(IdleState);
        }
    }
}
