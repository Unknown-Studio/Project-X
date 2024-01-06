using UnityEngine;

namespace Suhdo.Enemies
{
    [CreateAssetMenu(fileName = "newMeleeAttackData", menuName = "Enemy Data/State Data/MeleeAttack State")]
    public class D_EnemyMeleeAttack : ScriptableObject
    {
        public float attackDamage = 10f;
    }
}
