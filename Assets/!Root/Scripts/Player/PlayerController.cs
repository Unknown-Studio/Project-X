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
		public PlayerCrouchIdleState CrouchIdleState { get; private set; }
		public PlayerCrouchMoveState CrouchMoveState { get; private set; }
		public PlayerInputHandler InputHandler { get; private set; }

        private Vector2 _workSpaceVector;

        protected override void Awake()
        {
            base.Awake();
            
            Core = GetComponentInChildren<Core>();
            IdleState = new PlayerIdleState(StateMachine, this, "idle", playerData);
            MoveState = new PlayerMoveState(StateMachine, this, "move", playerData);
            JumpState = new PlayerJumpState(StateMachine, this, "inAir", playerData);
            InAirState = new PlayerInAirState(StateMachine, this, "inAir", playerData);
			CrouchIdleState = new PlayerCrouchIdleState(StateMachine, this, "crouchidle", playerData);
			CrouchMoveState = new PlayerCrouchMoveState(StateMachine, this, "crouchmove", playerData);
        }

        protected override void Start()
        {
            base.Start();
            
            InputHandler = GetComponent<PlayerInputHandler>();
            StateMachine.Initiallize(IdleState);
        }
    }
}
