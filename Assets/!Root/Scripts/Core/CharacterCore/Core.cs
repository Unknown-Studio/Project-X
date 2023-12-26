using System;
using UnityEngine;

namespace Suhdo.CharacterCore
{
    public class Core : MonoBehaviour
    {
        public MovementCore Movement { get; private set; }
        public CollisionSenses CollisionSenses { get; private set; }

        private void Awake()
        {
            Movement = GetComponentInChildren<MovementCore>();
            CollisionSenses = GetComponentInChildren<CollisionSenses>();

            if (!Movement || !CollisionSenses)
                Debug.LogError("Missing core component!");
        }

        protected virtual void OnValidate()
        {
            Movement = GetComponentInChildren<MovementCore>();
            CollisionSenses = GetComponentInChildren<CollisionSenses>();

            if (!Movement || !CollisionSenses)
                Debug.LogError("Missing core component!");
        }

        public void LogicUpdate()
        {
            Movement.LogicUpdate();
        }
    }
}
