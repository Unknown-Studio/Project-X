using UnityEngine;

namespace Suhdo.Weapons.Components
{
	public class ActionHitBoxData : ComponentData<AttackActionHitBox>
	{
		[field: SerializeField] public LayerMask DetectableLayer {get; private set; }
	}
}