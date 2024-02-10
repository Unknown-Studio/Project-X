using Suhdo.CharacterCore;
using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Player
{
    public class PlayerController : Entity
    {
        [SerializeField] private PlayerData playerData;
        
        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerJumpState JumpState { get; private set; }
        public PlayerInAirState InAirState { get; private set; }
        public PlayerLandState LandState { get; private set; }
		public PlayerCrouchIdleState CrouchIdleState { get; private set; }
		public PlayerCrouchMoveState CrouchMoveState { get; private set; }
        public PlayerRollState RollState { get; private set; }
        public PlayerWallSlideState WallSlideState { get; private set; }
        public PlayerLedgeClimbState LedgeClimbState { get; private set; }
        public PlayerAttackState PrimaryAttackState { get; private set; }
        public PlayerAttackState SecondaryAttackState { get; private set; }
        
        public PlayerInputHandler InputHandler { get; private set; }
        public PlayerInventory Inventory {get; private set; }

        private Vector2 _workSpaceVector;

        protected override void Awake()
        {
            base.Awake();
            
            InputHandler = GetComponent<PlayerInputHandler>();
            Inventory = GetComponent<PlayerInventory>();
            
            IdleState = new PlayerIdleState(StateMachine, this, "idle", playerData);
            MoveState = new PlayerMoveState(StateMachine, this, "move", playerData);
            JumpState = new PlayerJumpState(StateMachine, this, "inAir", playerData);
            InAirState = new PlayerInAirState(StateMachine, this, "inAir", playerData);
            LandState = new PlayerLandState(StateMachine, this, "land", playerData);
			CrouchIdleState = new PlayerCrouchIdleState(StateMachine, this, "crouchIdle", playerData);
			CrouchMoveState = new PlayerCrouchMoveState(StateMachine, this, "crouchMove", playerData);
			RollState = new PlayerRollState(StateMachine, this, "roll", playerData);
			WallSlideState = new PlayerWallSlideState(StateMachine, this, "wallSlide", playerData);
			LedgeClimbState = new PlayerLedgeClimbState(StateMachine, this, "ledgeClimbState", playerData);
            PrimaryAttackState = new PlayerAttackState(StateMachine, this, "attack", playerData);
            SecondaryAttackState = new PlayerAttackState(StateMachine, this, "attack", playerData);
        }

        protected override void Start()
        {
            base.Start();
            
            
            PrimaryAttackState.SetWeapon(Inventory.weapons[(int)CombatInputs.Primary]);
            StateMachine.Initiallize(IdleState);
        }

        protected override void Update()
        {
            Core.LogicUpdate();
            base.Update();
        }

        public void AnimationFinishedTrigger() => StateMachine.CurrentCoreState.AnimationFinishTrigger();

    }
}
