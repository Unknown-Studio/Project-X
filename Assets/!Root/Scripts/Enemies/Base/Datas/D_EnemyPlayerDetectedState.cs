using UnityEngine;

namespace Suhdo.Enemies
{
    [CreateAssetMenu(fileName = "newPlayerDetectedStateData", menuName = "Enemy Data/State Data/Player Detected State")]
    public class D_EnemyPlayerDetectedState : ScriptableObject
    {
        public float LongRangeActionTime = 1.5f;
    }
}
