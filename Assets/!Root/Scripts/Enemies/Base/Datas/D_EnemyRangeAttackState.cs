using Suhdo.Ultils;
using UnityEngine;

namespace Suhdo.Enemies
{
    [CreateAssetMenu(fileName = "newRangeAttackData", menuName = "Enemy Data/State Data/RangeAttack State")]
    public class D_EnemyRangeAttackState : ScriptableObject
    {
        public ObjectPoolSO pool;
        public GameObject projectile;
        public float projectileDamage = 10f;
        public float projectileSpeed = 12f;
        public float projectileTravelDistance = 8f;
    }
}
