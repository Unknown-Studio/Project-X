using System;
using UnityEngine;

namespace Suhdo.Weapons.Components
{
	[Serializable]
	public class AttackSprites : AttackData
	{
		[field: SerializeField] public PhaseSprite[] PhaseSprites { get; private set; }
	}

	[Serializable]
	public struct PhaseSprite
	{
		[field: SerializeField] public AttackPhases Phase { get; private set; }
		[field:SerializeField] public Sprite[] Sprites { get; private set; }
	}
}