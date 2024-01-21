using Suhdo.CharacterCore;
using Suhdo.DataCore;
using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Enemies
{
    public class Enemy : Entity
    {
        public D_Entity entityData;
        public GameObject aliveGO { get; private set; }
        public Core Core { get; private set; }

        protected float currentHealth;
        protected float currentStunResistance;
        protected float lastDamageTime;

        private Vector2 _velocityWorkspace;

        protected bool isStunned;
        protected bool isDead;

        protected override void Awake()
        {
            base.Awake();
            Core = GetComponentInChildren<Core>();
        }

        protected override void Start()
        {
            base.Start();

            currentHealth = entityData.maxHealth;
            currentStunResistance = entityData.stunResistance;
        }

        protected override void Update()
        {
            Core.LogicUpdate();
            base.Update();
        }
    }
}
