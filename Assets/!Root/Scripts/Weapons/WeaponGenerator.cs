using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Suhdo.Weapons.Components;
using UnityEngine;

namespace Suhdo.Weapons
{
	public class WeaponGenerator : MonoBehaviour
	{
		[SerializeField] private Weapon weapon;
		[SerializeField] private WeaponDataSO data;

		private List<WeaponComponent> _componentsAlreadyOnWeapon = new();
		private List<WeaponComponent> _componentsAddedToWeapon = new();
		private List<Type> _componentsDependencies = new();

		private void Start()
		{
			GenerateWeapon(data);
		}

		[Button]
		private void TestGenerateWeapon()
		{
			GenerateWeapon(data);
		}

		public void GenerateWeapon(WeaponDataSO data)
		{
			weapon.SetData(data);
			
			_componentsAlreadyOnWeapon.Clear();
			_componentsAddedToWeapon.Clear();
			_componentsDependencies.Clear();

			_componentsAlreadyOnWeapon = GetComponents<WeaponComponent>().ToList();
			_componentsDependencies = data.GetAllDependencies();

			foreach (var dependency in _componentsDependencies)
			{
				if(_componentsAddedToWeapon.FirstOrDefault(item => item.GetType() == dependency))
					continue;

				var weaponComponent =
					_componentsAlreadyOnWeapon.FirstOrDefault(item => item.GetType() == dependency);

				if (weaponComponent == null)
				{
					weaponComponent = gameObject.AddComponent(dependency) as WeaponComponent;
				}
				
				weaponComponent.Init();
				
				_componentsAddedToWeapon.Add(weaponComponent);
			}

			var componentsToRemove = _componentsAlreadyOnWeapon.Except(_componentsAddedToWeapon);
			foreach (var weaponComponent in componentsToRemove)
			{
				Destroy(weaponComponent);
			}
		}
	}
}