using UnityEngine;

namespace Suhdo.CharacterCore
{
    public class KnockBackReceiver : CoreComponent, IKnockbackable
    {
        [SerializeField] private float maxKnockBackTime = 0.2f;
        
        private bool _isKnockBackActive;
        private float _knockBackStartTime;

        public override void LogicUpdate()
        {
            CheckKnockback();
        }

        public void Knockback(Vector2 angle, float strength, int direction)
        {
            Movement.SetVelocity(strength, angle, direction);
            Movement.CanSetVelocity = false;
            _isKnockBackActive = true;
            _knockBackStartTime = Time.time;
        }

        private void CheckKnockback()
        {
            if (_isKnockBackActive && ((Movement.CurrentVelocity.y <= 0.01f && CollisionSenses.Ground) || Time.time >= _knockBackStartTime + maxKnockBackTime))
            {
                _isKnockBackActive = false;
                Movement.CanSetVelocity = true;
            }
        }
    }
}
