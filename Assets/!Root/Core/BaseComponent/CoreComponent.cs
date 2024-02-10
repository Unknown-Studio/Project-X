using Suhdo.Combat;
using UnityEngine;

namespace Suhdo.CharacterCore
{
    public abstract class CoreComponent : MonoBehaviour, ILogicUpdate
    {
        protected Core Core;

        protected Movement Movement => _movement ??= Core.GetCoreComponent<Movement>();
        protected Stats Stats => _stats ??= Core.GetCoreComponent<Stats>();
        protected BaseCollisionSenses CollisionSenses => _collisionSenses ??= Core.GetCoreComponent<BaseCollisionSenses>();
        protected ParticlesManager ParticlesManager => _particlesManager ??= Core.GetCoreComponent<ParticlesManager>();

        private Movement _movement;
        private BaseCollisionSenses _collisionSenses;
        private Stats _stats;
        private ParticlesManager _particlesManager;

        protected virtual void Awake()
        {
            Core = transform.parent.GetComponent<Core>();
            if(Core == null) Debug.LogError("There are no Core on the parent!");
            Core.AddComponent(this);
        }

        protected virtual void OnValidate()
        {
            Core = transform.parent.GetComponent<Core>();
            if (Core == null) Debug.LogError("There are no Core on the parent!");
            Core.AddComponent(this);
        }

        public virtual void LogicUpdate() { }
    }
}
