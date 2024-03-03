using System;
using System.Collections.Generic;
using System.Linq;
using Suhdo.Weapons.Components;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace Suhdo.Weapons
{
	[CustomEditor(typeof(WeaponDataSO))]
	public class WeaponDataSOEditor : Editor
	{
		private static List<Type> _dataCompTypes = new List<Type>();
		private WeaponDataSO _dataSO;

		private bool addComponentButton;
		private bool forceUpdateButton;

		private void OnEnable()
		{
			_dataSO = target as WeaponDataSO;
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			
			if (GUILayout.Button("Set number of attack"))
			{
				foreach (var item in _dataSO.ComponentData)
				{
					item.InitializeAttackData(_dataSO.NumberOfAttack);
				}
			}

			addComponentButton = EditorGUILayout.Foldout(addComponentButton, "Add component buttons");
			if (addComponentButton)
			{
				foreach (var data in _dataCompTypes)
				{
					if (GUILayout.Button(data.Name))
					{
						var comp = Activator.CreateInstance(data) as ComponentData;
						if (comp == null) return;
						comp.InitializeAttackData(_dataSO.NumberOfAttack);
						_dataSO.AddData(comp);
					}
				}
			}

			forceUpdateButton = EditorGUILayout.Foldout(forceUpdateButton, "Force update buttons");
			if(forceUpdateButton)
			{
				if (GUILayout.Button("Force update component name"))
				{
					foreach (var item in _dataSO.ComponentData)
					{
						item.SetComponentName();
					}
				}
			
				if (GUILayout.Button("Force update attack name"))
				{
					foreach (var item in _dataSO.ComponentData)
					{
						item.SetAttackDataNames();
					}
				}
			}
		}

		[DidReloadScripts]
		private static void ReCompile()
		{
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
			var type = assemblies.SelectMany(assembly => assembly.GetTypes());
			var filterType = type.Where(
				type => type.IsSubclassOf(typeof(ComponentData)) && type.IsClass && !type.ContainsGenericParameters
				);
			_dataCompTypes = filterType.ToList();
		}
	}
}