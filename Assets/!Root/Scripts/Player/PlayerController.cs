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
        
        public PlayerInputHandler InputHandler { get; private set; }

        private Vector2 _workSpaceVector;

        protected override void Awake()
        {
            base.Awake();
            
            Core = GetComponentInChildren<Core>();
            IdleState = new PlayerIdleState(StateMachine, this, "idle", playerData);
            MoveState = new PlayerMoveState(StateMachine, this, "move", playerData);
        }

        protected override void Start()
        {
            base.Start();
            
            InputHandler = GetComponent<PlayerInputHandler>();
            StateMachine.Initiallize(IdleState);
        }
    }
}
