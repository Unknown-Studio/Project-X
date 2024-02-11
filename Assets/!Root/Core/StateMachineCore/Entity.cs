using Suhdo.CharacterCore;
using Suhdo.Ultils;
using UnityEngine;

namespace Suhdo.StateMachineCore
{
    public class Entity : MonoBehaviour
    {
        public Rigidbody2D RB { get; private set; }
        public Animator Anim { get; private set; }
        public BoxCollider2D MovementCollider { get; private set; }
        
        public Core Core { get; private set; }

        public AnimationToStateMachine AnimToStateMachine { get; private set; }
        
        public StateMachine StateMachine {get; private set; }

        protected Vector2 _workSpaceVector;
        
        protected virtual void Awake()
        {
            StateMachine = new StateMachine();
            Anim = GetComponent<Animator>();
            RB = GetComponent<Rigidbody2D>();
            MovementCollider = GetComponent<BoxCollider2D>();
            AnimToStateMachine = GetComponent<AnimationToStateMachine>();
            Core = GetComponentInChildren<Core>();
        }

        protected virtual void Start()
        {
            
        }

        protected virtual void Update()
        {
            StateMachine.CurrentCoreState.LogicUpdate();
            Core.LogicUpdate();
        }

        protected virtual void FixedUpdate()
        {
            StateMachine.CurrentCoreState.PhysicsUpdate();
        }
        
        public void SetColliderHeight(float height)
        {
            Vector2 center = MovementCollider.offset;
            _workSpaceVector.Set(MovementCollider.size.x, height);

            center.y += (height - MovementCollider.size.y) / 2;

            MovementCollider.size = _workSpaceVector;
            MovementCollider.offset = center;
        }
    }
}
