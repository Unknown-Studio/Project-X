using System.Collections.Generic;
using Suhdo.CharacterCore;
using UnityEngine;

namespace Suhdo.Weapons
{
    public class AggressiveWeapon : Weapon
    {
        protected D_AggressiveWeapon aggressiveWeaponData;

        private List<IDamageable> detectedDamageable = new List<IDamageable>();

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
        }
        
        public void AddToDetected(Collider2D collision)
        {
            IDamageable damageable = collision.GetComponent<IDamageable>();

            if (damageable != null)
            {
                detectedDamageable.Add(damageable);
            }
        }

        public void RemoveFromDetected(Collider2D collision)
        {
            IDamageable damageable = collision.GetComponent<IDamageable>();

            if (damageable != null)
            {
                detectedDamageable.Remove(damageable);
            }
        }
    }
}
