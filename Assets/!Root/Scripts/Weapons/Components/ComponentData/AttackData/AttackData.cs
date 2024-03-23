using System;
using UnityEngine;

namespace Suhdo.Weapons.Components
{
	[Serializable]
	public class AttackData
	{
		[SerializeField, HideInInspector] private string name;

		public void SetAttackDataName(int index) => name = $"Attack {index}";
	}
}