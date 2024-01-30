using System;
using Suhdo.CharacterCore;
using Suhdo.Ultils;
using UnityEngine;

namespace Suhdo.Combat
{
    public class Combat : CoreComponent, IDamageable, IKnockbackable
    {
        [SerializeField] private float maxKnockbackTime = 0.2f;
        [SerializeField] private GameObject hit_Particle;
        [SerializeField] private ObjectPoolSO hitPool;
        
        private bool _isKnockbackActive;
        private float _knockbackStartTime;

        private void OnDisable()
        {
            hitPool.ClearPool();
        }

        public override void LogicUpdate()
        {
            CheckKnockback();
        }
        
        public void Damage(float amount)
        {
            UnityEngine.Debug.Log("Damage!!!!");
            Stats.DecreaseHealth(amount);
            ParticlesManager.StartParticleWithRandomRotation(hitPool.Get());
        }

        public void Knockback(Vector2 angle, float strength, int direction)
        {
            Movement.SetVelocity(strength, angle, direction);
            Movement.CanSetVelocity = false;
            _isKnockbackActive = true;
            _knockbackStartTime = Time.time;
        }

        private void CheckKnockback()
        {
            if (_isKnockbackActive && ((Movement.CurrentVelocity.y <= 0.01f && CollisionSenses.Ground) || Time.time >= _knockbackStartTime + maxKnockbackTime))
            {
                _isKnockbackActive = false;
                Movement.CanSetVelocity = true;
            }
        }
    }
}
