using System;
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
        [SerializeField] private D_EnemyRangeAttackState _rangeAttackData;
        [SerializeField] private D_EnemyDodgeState _dodgeData;
        [SerializeField] private D_EnemyTeleState _teleStateData;
        
        public Huntress_IdleState IdleState { get; private set; }
        public Huntress_MoveState MoveState { get; private set; }
        public Huntress_PlayerDetectedState PlayerDetectedState { get; private set; }
        public Huntress_LookingForPlayer LookingForPlayer { get; private set; }
        public Huntress_FallState FallState { get; private set; }
        public Huntress_RangeAttackState RangeAttackState { get; private set; }
        public Huntress_DodgeState DodgeState { get; private set; }
        public Huntress_TeleState TeleState { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            IdleState = new Huntress_IdleState(StateMachine, this, "idle", _idleStateData);
            MoveState = new Huntress_MoveState(StateMachine, this, "move", _moveStateData);
            PlayerDetectedState =
                new Huntress_PlayerDetectedState(StateMachine, this, "playerDetected", _playerDetectedStateData);
            LookingForPlayer =
                new Huntress_LookingForPlayer(StateMachine, this, "lookingForPlayer", _lookingForPlayerData);
            FallState = new Huntress_FallState(StateMachine, this, "fall");
            RangeAttackState = new Huntress_RangeAttackState(StateMachine, this, "rangeAttack", _rangeAttackData);
            DodgeState = new Huntress_DodgeState(StateMachine, this, "jump", _dodgeData);
            TeleState = new Huntress_TeleState(StateMachine, this, "tele", _teleStateData);
        }

        protected override void Start()
        {
            base.Start();
            
            StateMachine.Initiallize(IdleState);
        }

        private void OnDisable()
        {
            _rangeAttackData.pool.ClearPool();
        }
    }
}
