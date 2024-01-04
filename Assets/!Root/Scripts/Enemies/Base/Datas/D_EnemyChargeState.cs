using UnityEngine;

namespace Suhdo.Enemies
{
    [CreateAssetMenu(fileName = "newChargeStateData", menuName = "Enemy Data/State Data/Charge State")]
    public class D_EnemyChargeState : ScriptableObject
    {
        public float ChargeSpeed = 6f;

        public float ChargeTime = 0.5f;
    }
}
