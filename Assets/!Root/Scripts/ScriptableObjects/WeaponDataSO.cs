using System;
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

		public List<Type> GetAllDependencies()
		{
			return ComponentData.Select(component => component.ComponentDependency).ToList();
		}

		public void AddData(ComponentData data)
		{
			if(ComponentData.FirstOrDefault(t => t.GetType() == data.GetType()) == null)
				ComponentData.Add(data);
		}
	
		[Button("Add Weapon Data")]
		private void AddWeaponData() => ComponentData.Add(new WeaponSpriteData());
		[Button("Add Movement Data")]
		private void AddMovementData() => ComponentData.Add(new MovementData());
	}
}