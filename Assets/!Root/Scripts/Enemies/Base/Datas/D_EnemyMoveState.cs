using UnityEngine;

namespace Suhdo.Enemies
{
    [CreateAssetMenu(fileName = "newMoveStateData", menuName = "Enemy Data/State Data/Move State")]
    public class D_EnemyMoveState : ScriptableObject
    {
        public float MovementSpeed = 3f;
    }
}
