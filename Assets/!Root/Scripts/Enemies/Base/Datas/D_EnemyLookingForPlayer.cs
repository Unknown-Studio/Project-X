using UnityEngine;

namespace Suhdo.Enemies
{
    [CreateAssetMenu(fileName = "newLookingForPlayerStateData", menuName = "Enemy Data/State Data/Looking for player State")]
    public class D_EnemyLookingForPlayer : ScriptableObject
    {
        public int AmountOfTurns = 2;
        public float TimeBetweenTurns = 0.75f;
    }
}
