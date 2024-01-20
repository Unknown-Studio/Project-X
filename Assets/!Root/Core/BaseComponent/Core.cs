using Suhdo.Generics;
using Suhdo.Player;
using UnityEngine;

namespace Suhdo.CharacterCore
{
    public class Core : MonoBehaviour
    {
        private Movement _movement;
        private CollisionSenses _collisionSenses;
        private Combat _combat;

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

        public Combat Combat
        {
            get => GenericNotImplementedError<Combat>.TryGet(_combat, transform.parent.name);
            private set => _combat = value;
        }

        private void Awake()
        {
            Movement = GetComponentInChildren<Movement>();
            CollisionSenses = GetComponentInChildren<CollisionSenses>();

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
            Movement.LogicUpdate();
        }
    }
}
