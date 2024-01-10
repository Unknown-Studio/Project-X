using Suhdo.CharacterCore;
using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Player
{
    public class PlayerController : Entity, IDamageable
    {
        [SerializeField] private PlayerData playerData;

        public PlayerCore PlayerCore { get; private set; }
        
        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerJumpState JumpState { get; private set; }
        public PlayerInAirState InAirState { get; private set; }
        public PlayerLandState LandState { get; private set; }
		public PlayerCrouchIdleState CrouchIdleState { get; private set; }
		public PlayerCrouchMoveState CrouchMoveState { get; private set; }
        public PlayerRollState RollState { get; private set; }
        
        public PlayerInputHandler InputHandler { get; private set; }

        private Vector2 _workSpaceVector;

        protected override void Awake()
        {
            base.Awake();
            
            PlayerCore = GetComponentInChildren<PlayerCore>();
            IdleState = new PlayerIdleState(StateMachine, this, "idle", playerData);
            MoveState = new PlayerMoveState(StateMachine, this, "move", playerData);
            JumpState = new PlayerJumpState(StateMachine, this, "inAir", playerData);
            InAirState = new PlayerInAirState(StateMachine, this, "inAir", playerData);
            LandState = new PlayerLandState(StateMachine, this, "land", playerData);
			CrouchIdleState = new PlayerCrouchIdleState(StateMachine, this, "crouchidle", playerData);
			CrouchMoveState = new PlayerCrouchMoveState(StateMachine, this, "crouchmove", playerData);
			RollState = new PlayerRollState(StateMachine, this, "roll", playerData);
        }

        protected override void Start()
        {
            base.Start();
            
            InputHandler = GetComponent<PlayerInputHandler>();
            StateMachine.Initiallize(IdleState);
        }

        protected override void Update()
        {
            PlayerCore.LogicUpdate();
            base.Update();
        }

        public void AnimationFinishedTrigger() => StateMachine.CurrentCoreState.AnimationFinishTrigger();

        public void Damage(float amount)
        {
            Debug.Log($"Received {amount} damage");
        }
    }
}
