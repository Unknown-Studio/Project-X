using UnityEngine;

namespace Suhdo.Enemies
{
    [CreateAssetMenu(fileName = "newDodgeData", menuName = "Enemy Data/State Data/Dodge State")]
    public class D_EnemyDodgeState : ScriptableObject
    {
        public float dodgeSpeed = 10f;
        public float dodgeTime = 0.2f;
        public float dogeCooldown = 2f;
        public Vector2 dodgeAngle ;
    }
}
