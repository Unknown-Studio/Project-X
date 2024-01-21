using System.Collections.Generic;
using Suhdo.Combat;
using UnityEngine;

namespace Suhdo.Weapons
{
    public class AggressiveWeapon : Weapon
    {
        protected D_AggressiveWeapon aggressiveWeaponData;

        private List<IDamageable> detectedDamageable = new List<IDamageable>();
        private List<IKnockbackable> detectedKnockbackable = new List<IKnockbackable>();

        protected override void Awake()
        {
            base.Awake();
            
            if (weaponData.GetType() == typeof(D_AggressiveWeapon))
            {
                aggressiveWeaponData = (D_AggressiveWeapon)weaponData;
            }
            else
            {
                Debug.LogError("Wrong data for the weapon");
            }
        }

        public override void AnimationActionTrigger()
        {
            base.AnimationActionTrigger();
            CheckMeleeAttack();
        }

        private void CheckMeleeAttack()
        {
            var details = aggressiveWeaponData.AttackDetails[attackCounter];
            foreach (var item in detectedDamageable)
            {
                item.Damage(details.DamageAmount);
            }

            foreach (var item in detectedKnockbackable)
            {
                item.Knockback(details.KnockbackAngle, details.KnockbackStrength, core.Movement.FacingDirection);
            }
        }
        
        public void AddToDetected(Collider2D collision)
        {
            var damageable = collision.GetComponent<IDamageable>();
            var knockbackable = collision.GetComponent<IKnockbackable>();

            if (damageable != null)
            {
                detectedDamageable.Add(damageable);
            }

            if (knockbackable != null)
            {
                detectedKnockbackable.Add(knockbackable);
            }
        }

        public void RemoveFromDetected(Collider2D collision)
        {
            var damageable = collision.GetComponent<IDamageable>();
            var knockbackable = collision.GetComponent<IKnockbackable>();

            if (damageable != null)
            {
                detectedDamageable.Remove(damageable);
            }
            
            if (knockbackable != null)
            {
                detectedKnockbackable.Remove(knockbackable);
            }
        }
    }
}
