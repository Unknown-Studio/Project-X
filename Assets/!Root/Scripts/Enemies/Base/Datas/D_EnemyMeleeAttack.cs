using UnityEngine;
using UnityEngine.Serialization;

namespace Suhdo.Enemies
{
    [CreateAssetMenu(fileName = "newMeleeAttackData", menuName = "Enemy Data/State Data/MeleeAttack State")]
    public class D_EnemyMeleeAttack : ScriptableObject
    {
        public float AttackDamage = 10f;
        public Vector2 KnockbackAngle = Vector2.one;
        public float KnockbackStrength = 10f;
    }
}
