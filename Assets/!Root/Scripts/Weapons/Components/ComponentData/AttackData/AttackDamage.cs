using System;
using UnityEngine;

namespace Suhdo.Weapons.Components
{
	[Serializable]
	public class AttackDamage : AttackData
	{
		[field: SerializeField] public float Amount { get; private set; }
	}
}