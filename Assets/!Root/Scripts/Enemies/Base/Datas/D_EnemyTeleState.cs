using UnityEngine;

namespace Suhdo.Enemies
{
    [CreateAssetMenu(fileName = "newTeleData", menuName = "Enemy Data/State Data/Tele State")]
    public class D_EnemyTeleState : ScriptableObject
    {
        public float Speed = .5f;
        public float DistanceTele = 1f;
        public float chargeTime = 1f;
    }
}
