using Suhdo.DataCore;
using Suhdo.Ultils;
using UnityEngine;

namespace Suhdo.StateMachineCore
{
    public class Entity : MonoBehaviour
    {
        public int FacingDirection { get; private set; }
        public Rigidbody2D RB { get; private set; }
        public Animator Anim { get; private set; }
        public GameObject aliveGO { get; private set; }
        public AnimationToStateMachine AnimToStateMachine { get; private set; }
        public int LastDamageDirection { get; private set; }
        
        public StateMachine StateMachine;
        public D_Entity entityData;
    }
}
