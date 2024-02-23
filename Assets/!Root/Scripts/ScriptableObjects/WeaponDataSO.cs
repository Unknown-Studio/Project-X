using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Suhdo.Weapons.Components;
using UnityEngine;

namespace Suhdo.Weapons
{
	[CreateAssetMenu(fileName = "newWeaponData", menuName = "Data/Weapon Data/Basic Weapon Data", order = 0)]
	public class WeaponDataSO : ScriptableObject
	{
		[field:SerializeField]
		public int NumberOfAttack { get; private set; }
		
		[field:SerializeReference]
		public List<ComponentData> ComponentData { get; private set; }

		public T GetData<T>()
		{
			return ComponentData.OfType<T>().FirstOrDefault();
		}
	
		[Button("Add Weapon Data")]
		private void AddWeaponData() => ComponentData.Add(new WeaponSpriteData());
		[Button("Add Movement Data")]
		private void AddMovementData() => ComponentData.Add(new MovementData());
	}
}