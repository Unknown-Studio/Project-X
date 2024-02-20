using System;
using Suhdo.Weapons.Components.ComponentData.AttackData;
using UnityEngine;

namespace Suhdo.Weapons.Components.ComponentData
{
	public class WeaponSpriteData : ComponentData
	{
		[field:SerializeField] public AttackSprites[] AttackData { get; private set; }
	}
}