using Suhdo.CharacterCore;
using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Player
{
    public class PlayerController : Entity
    {
        public StateMachine StateMachine { get; private set; }
        
        public CoreState CoreState { get; private set; }
        
        public Core Core { get; private set; }
        public Rigidbody2D RB { get; private set; }
        public Animator Anim { get; private set; }
        public PlayerInputHandler InputHandler { get; private set; }
        public BoxCollider2D MovementCollider { get; private set; }

        private Vector2 _workSpaceVector;

        private void Awake()
        {
            StateMachine = new StateMachine();
            Core = GetComponentInChildren<Core>();
        }

        private void Start()
        {
            Anim = GetComponent<Animator>();
            InputHandler = GetComponent<PlayerInputHandler>();
            RB = GetComponent<Rigidbody2D>();
            MovementCollider = GetComponent<BoxCollider2D>();
        }
    }
}
