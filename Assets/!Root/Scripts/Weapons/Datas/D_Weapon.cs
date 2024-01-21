using UnityEngine;

namespace Suhdo.Weapons
{
    [CreateAssetMenu(fileName = "newWeaponData", menuName = "Data/Weapon Data/Weapon")]
    public class D_Weapon : ScriptableObject
    {
        public int AmountOfAttacks { get; protected set; }
        public float[] MovementSpeed { get; protected set; }
    }
}
