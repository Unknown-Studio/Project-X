using Suhdo.Generics;
using UnityEngine;

namespace Suhdo.CharacterCore
{
    public abstract class CoreComponent : MonoBehaviour, ILogicUpdate
    {
        protected Core Core;

        protected Movement Movement => _movement.Comp;
        protected Stats Stats => _stats.Comp;
        protected BaseCollisionSenses CollisionSenses => _collisionSenses.Comp;
        protected ParticlesManager ParticlesManager => _particlesManager.Comp;

        private CoreComp<Movement> _movement;
        private CoreComp<BaseCollisionSenses> _collisionSenses;
        private CoreComp<Stats> _stats;
        private CoreComp<ParticlesManager> _particlesManager;

        protected virtual void Awake()
        {
            Core = transform.parent.GetComponent<Core>();
            if(Core == null) Debug.LogError("There are no Core on the parent!");
            Core.AddComponent(this);

            _movement = new CoreComp<Movement>(Core);
            _collisionSenses = new CoreComp<BaseCollisionSenses>(Core);
            _stats = new CoreComp<Stats>(Core);
            _particlesManager = new CoreComp<ParticlesManager>(Core);
        }

        protected virtual void OnValidate()
        {
            Core = transform.parent.GetComponent<Core>();
            if (Core == null) Debug.LogError("There are no Core on the parent!");
            Core.AddComponent(this);
            
            _movement = new CoreComp<Movement>(Core);
            _collisionSenses = new CoreComp<BaseCollisionSenses>(Core);
            _stats = new CoreComp<Stats>(Core);
            _particlesManager = new CoreComp<ParticlesManager>(Core);
        }

        public virtual void LogicUpdate() { }
    }
}
