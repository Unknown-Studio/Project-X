using Suhdo.CharacterCore;
using UnityEngine;

namespace Suhdo.Enemies.Skeleton
{
    public class Skeleton : Enemy, IDamageable
    {
        [SerializeField] private D_EnemyIdleState _idleStateData;
        [SerializeField] private D_EnemyMoveState _moveStateData;
        [SerializeField] private D_EnemyPlayerDetectedState _playerDetectedData;
        [SerializeField] private D_EnemyChargeState _chargeStateData;
        [SerializeField] private D_EnemyLookingForPlayer _lookingForPlayerData;
        [SerializeField] private D_EnemyMeleeAttack _meleeAttackData;
        
        public Skeleton_IdleState IdleState { get; private set; }
        public Skeleton_MoveState MoveState { get; private set; }
        public Skeleton_FallState FallState { get; private set; }
        public Skeleton_PlayerDetectedState PlayerDetectedState { get; private set; }
        public Skeleton_ChargeState ChargeState { get; private set; }
        public Skeleton_LookingForPlayer LookingForPlayer {get; private set; }
        public Skeleton_MeleeAttackState MeleeAttackState { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            IdleState = new Skeleton_IdleState(StateMachine, this, "idle", _idleStateData);
            MoveState = new Skeleton_MoveState(StateMachine, this, "move", _moveStateData);
            FallState = new Skeleton_FallState(StateMachine, this, "fall");
            PlayerDetectedState =
                new Skeleton_PlayerDetectedState(StateMachine, this, "playerDetected", _playerDetectedData);
            ChargeState = new Skeleton_ChargeState(StateMachine, this, "charge", _chargeStateData);
            LookingForPlayer =
                new Skeleton_LookingForPlayer(StateMachine, this, "lookingForPlayer", _lookingForPlayerData);
            MeleeAttackState = new Skeleton_MeleeAttackState(StateMachine, this, "meleeAttack", _meleeAttackData);
            
        }

        protected override void Start()
        {
            base.Start();
            
            StateMachine.Initiallize(IdleState);
        }

        public void Damage(float amount)
        {
            Debug.Log("Skeleton damage: " + amount);
        }
    }
}
