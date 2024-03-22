using Suhdo.Generics;
using UnityEngine;

namespace Suhdo.CharacterCore
{
    public abstract class CoreComponent : MonoBehaviour, ILogicUpdate
    {
        protected Core Core;

        protected Movement Movement => _movement;
        protected Stats Stats => _stats;
        protected BaseCollisionSenses CollisionSenses => _collisionSenses;
        protected ParticlesManager ParticlesManager => _particlesManager;

        private Movement _movement;
        private BaseCollisionSenses _collisionSenses;
        private Stats _stats;
        private ParticlesManager _particlesManager;

        protected virtual void Awake()
        {
            Core = transform.parent.GetComponent<Core>();
            if(Core == null) Debug.LogError("There are no Core on the parent!");
            Core.AddComponent(this);

            _movement = Core.GetCoreComponent<Movement>();
            _collisionSenses = Core.GetCoreComponent<BaseCollisionSenses>();
            _stats = Core.GetCoreComponent<Stats>();
            _particlesManager = Core.GetCoreComponent<ParticlesManager>();
        }

        protected virtual void OnValidate()
        {
            Core = transform.parent.GetComponent<Core>();
            if (Core == null) Debug.LogError("There are no Core on the parent!");
            Core.AddComponent(this);
            
            _movement = Core.GetCoreComponent<Movement>();
            _collisionSenses = Core.GetCoreComponent<BaseCollisionSenses>();
            _stats = Core.GetCoreComponent<Stats>();
            _particlesManager = Core.GetCoreComponent<ParticlesManager>();
        }

        public virtual void LogicUpdate() { }
    }
}
