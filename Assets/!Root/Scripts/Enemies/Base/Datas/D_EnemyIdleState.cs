using UnityEngine;

namespace Suhdo.Enemies
{
    [CreateAssetMenu(fileName = "newIdleStateData", menuName = "Enemy Data/State Data/Idle State")]
    public class D_EnemyIdleState : ScriptableObject
    {
        public float minIdleTime = 1f;
        public float maxIdleTime = 2f;
    }
}
