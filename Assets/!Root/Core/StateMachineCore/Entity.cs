using Suhdo.CharacterCore;
using Suhdo.Ultils;
using UnityEngine;

namespace Suhdo.StateMachineCore
{
    public class Entity : MonoBehaviour
    {
        public PlayerCore PlayerCore { get; protected set; }
        public Rigidbody2D RB { get; private set; }
        public Animator Anim { get; private set; }
        public BoxCollider2D MovementCollider { get; private set; }

        public AnimationToStateMachine AnimToStateMachine { get; private set; }
        
        public StateMachine StateMachine {get; private set; }
        
        protected virtual void Awake()
        {
            StateMachine = new StateMachine();
            PlayerCore = GetComponentInChildren<PlayerCore>();
        }

        protected virtual void Start()
        {
            Anim = GetComponent<Animator>();
            RB = GetComponent<Rigidbody2D>();
            MovementCollider = GetComponent<BoxCollider2D>();
            AnimToStateMachine = GetComponent<AnimationToStateMachine>();
        }

        protected virtual void Update()
        {
            PlayerCore.LogicUpdate();
            StateMachine.CurrentCoreState.LogicUpdate();
        }

        protected virtual void FixedUpdate()
        {
            StateMachine.CurrentCoreState.PhysicsUpdate();
        }
    }
}
