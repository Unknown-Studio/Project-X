using Suhdo.Weapons.Components.ComponentData.AttackData;
using UnityEngine;

namespace Suhdo.Weapons.Components.ComponentData
{
	public class MovementData : ComponentData
	{
		[field: SerializeField] public AttackMovement[] AttackData { get; private set; }
	}
}