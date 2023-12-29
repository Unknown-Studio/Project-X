using Suhdo.DataCore;
using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Enemies
{
    public class Enemy : Entity
    {
        public D_Entity entityData;
        public GameObject aliveGO { get; private set; }

        private float _currentHealth;
        private float _currentStunResistance;
        private float _lastDamageTime;

        private Vector2 _velocityWorkspace;

        protected bool isStunned;
        protected bool isDead;

        protected override void Start()
        {
            base.Start();

            _currentHealth = entityData.maxHealth;
            _currentStunResistance = entityData.stunResistance;
        }
    }
}
