using Unity.VisualScripting;
using UnityEngine;

namespace Suhdo.Enemies.Huntress
{
    public class Huntress : Enemy
    {
        [SerializeField] private D_EnemyIdleState _idleStateData;
        [SerializeField] private D_EnemyMoveState _moveStateData;
        [SerializeField] private D_EnemyPlayerDetectedState _playerDetectedStateData;
        [SerializeField] private D_EnemyLookingForPlayer _lookingForPlayerData;
        
        public Huntress_IdleState IdleState { get; private set; }
        public Huntress_MoveState MoveState { get; private set; }
        public Huntress_PlayerDetectedState PlayerDetectedState { get; private set; }
        public Huntress_LookingForPlayer LookingForPlayer { get; private set; }
        public Huntress_FallState FallState { get; private set; }

        protected override void Start()
        {
            base.Start();

            IdleState = new Huntress_IdleState(StateMachine, this, "idle", _idleStateData);
            MoveState = new Huntress_MoveState(StateMachine, this, "move", _moveStateData);
            PlayerDetectedState =
                new Huntress_PlayerDetectedState(StateMachine, this, "playerDetected", _playerDetectedStateData);
            LookingForPlayer =
                new Huntress_LookingForPlayer(StateMachine, this, "lookingForPlayer", _lookingForPlayerData);
            FallState = new Huntress_FallState(StateMachine, this, "fall");
            
            StateMachine.Initiallize(IdleState);
        }
    }
}
