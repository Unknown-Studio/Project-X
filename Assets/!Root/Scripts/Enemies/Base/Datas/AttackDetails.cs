using UnityEngine;
using UnityEngine.Serialization;

namespace Suhdo.Enemies
{
    public struct AttackDetails
    {
        public Vector2 position;
        public float damageAmount;
        public float stunDamageAmount;
    }
    
    [System.Serializable]
    public struct WeaponAttackDetails
    {
        public string AttackName;
        public float MovementSpeed;
        public float DamageAmount;

        public float KnockbackStrength;
        public Vector2 KnockbackAngle;
    }
}
