using Suhdo.CharacterCore;
using UnityEngine;

namespace Suhdo.Combat
{
    public class Combat : CoreComponent, IDamageable, IKnockbackable
    {
        [SerializeField] private float maxKnockbackTime = 0.2f;
        
        private bool _isKnockbackActive;
        private float _knockbackStartTime;

        public override void LogicUpdate()
        {
            CheckKnockback();
        }
        
        public void Damage(float amount)
        {
            UnityEngine.Debug.Log("Damage!!!!");
            Core.Stats.DecreaseHealth(amount);
        }

        public void Knockback(Vector2 angle, float strength, int direction)
        {
            Core.Movement.SetVelocity(strength, angle, direction);
            Core.Movement.CanSetVelocity = false;
            _isKnockbackActive = true;
            _knockbackStartTime = Time.time;
        }

        private void CheckKnockback()
        {
            if (_isKnockbackActive && ((Core.Movement.CurrentVelocity.y <= 0.01f && Core.CollisionSenses.Ground) || Time.time >= _knockbackStartTime + maxKnockbackTime))
            {
                _isKnockbackActive = false;
                Core.Movement.CanSetVelocity = true;
            }
        }
    }
}
