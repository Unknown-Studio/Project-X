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
        public EnemyCore EnemyCore { get; private set; }

        private float _currentHealth;
        private float _currentStunResistance;
        private float _lastDamageTime;

        private Vector2 _velocityWorkspace;

        protected bool isStunned;
        protected bool isDead;

        protected override void Awake()
        {
            base.Awake();
            EnemyCore = GetComponentInChildren<EnemyCore>();
        }

        protected override void Start()
        {
            base.Start();

            _currentHealth = entityData.maxHealth;
            _currentStunResistance = entityData.stunResistance;
        }

        protected override void Update()
        {
            EnemyCore.LogicUpdate();
            base.Update();
        }
    }
}
