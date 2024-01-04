using UnityEngine;

namespace Suhdo.Enemies.Skeleton
{
    public class Skeleton : Enemy
    {
        [SerializeField] private D_EnemyIdleState _idleStateData;
        [SerializeField] private D_EnemyMoveState _moveStateData;
        [SerializeField] private D_EnemyPlayerDetectedState _playerDetectedData;
        
        public Skeleton_IdleState IdleState { get; private set; }
        public Skeleton_MoveState MoveState { get; private set; }
        public Skeleton_FallState FallState { get; private set; }
        public Skeleton_PlayerDetectedState PlayerDetectedState { get; private set; }

        protected override void Start()
        {
            base.Start();

            IdleState = new Skeleton_IdleState(StateMachine, this, "idle", _idleStateData);
            MoveState = new Skeleton_MoveState(StateMachine, this, "move", _moveStateData);
            FallState = new Skeleton_FallState(StateMachine, this, "fall");
            PlayerDetectedState =
                new Skeleton_PlayerDetectedState(StateMachine, this, "playerDetected", _playerDetectedData);
            
            StateMachine.Initiallize(IdleState);
        }
    }
}
