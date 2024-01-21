using Suhdo.Enemies;
using UnityEngine;
using UnityEngine.Serialization;

namespace Suhdo.Weapons
{
    [CreateAssetMenu(fileName = "newAggressiveWeaponData", menuName = "Data/Weapon Data/Aggressive Weapon")]
    public class D_AggressiveWeapon : D_Weapon
    {
        [SerializeField] private WeaponAttackDetails[] _attackDetails;
        
        public WeaponAttackDetails[] AttackDetails
        {
            get => _attackDetails;
            private set => _attackDetails = value;
        }

        private void OnEnable()
        {
            AmountOfAttacks = _attackDetails.Length;
            MovementSpeed = new float[AmountOfAttacks];

            for (int i = 0; i < AmountOfAttacks; i++)
            {
                MovementSpeed[i] = _attackDetails[i].MovementSpeed;
            }
        }
    }
}
