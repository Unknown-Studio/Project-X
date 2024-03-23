using System;
using UnityEngine;

namespace Suhdo.Weapons.Components
{
	[Serializable]
	public class AttackSprites : AttackData
	{
		[field:SerializeField] public Sprite[] Sprites { get; private set; }
	}
}