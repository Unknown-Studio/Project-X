using System.Collections.Generic;
using Suhdo.Combat;
using Suhdo.Generics;
using UnityEngine;

namespace Suhdo.CharacterCore
{
    public class Core : MonoBehaviour
    {
        private Movement _movement;
        private CollisionSenses _collisionSenses;
        private Combat.Combat _combat;
        private List<ILogicUpdate> _components = new List<ILogicUpdate>();

        public Movement Movement
        {
            get => GenericNotImplementedError<Movement>.TryGet(_movement, transform.parent.name);
            private set => _movement = value;
        }

        public CollisionSenses CollisionSenses
        {
            get => GenericNotImplementedError<CollisionSenses>.TryGet(_collisionSenses, transform.parent.name);
            private set => _collisionSenses = value;
        }

        public Combat.Combat Combat
        {
            get => GenericNotImplementedError<Combat.Combat>.TryGet(_combat, transform.parent.name);
            private set => _combat = value;
        }
        

        private void Awake()
        {
            Movement = GetComponentInChildren<Movement>();
            CollisionSenses = GetComponentInChildren<CollisionSenses>();
            Combat = GetComponentInChildren<Combat.Combat>();

            if (!Movement || !CollisionSenses)
                Debug.LogError("Missing core component!");
        }

        protected virtual void OnValidate()
        {
            Movement = GetComponentInChildren<Movement>();
            CollisionSenses = GetComponentInChildren<CollisionSenses>();

            if (!Movement || !CollisionSenses)
                Debug.LogError("Missing core component!");
        }

        public virtual void LogicUpdate()
        {
            foreach (var component in _components)
            {
                component.LogicUpdate();
            }
        }

        public void AddComponent(ILogicUpdate component)
        {
            if (_components.Contains(component)) return;
                _components.Add(component);
        }
    }
}
