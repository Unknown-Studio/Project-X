using System;
using UnityEngine;

namespace Suhdo.Weapons.Components
{
	[Serializable]
	public class AttackPoiseDamage : AttackData
	{
		[field: SerializeField] public float Amount { get; private set; }
	}
}