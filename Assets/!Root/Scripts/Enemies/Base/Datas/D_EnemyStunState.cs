using UnityEngine;

namespace Suhdo.Enemies
{
	[CreateAssetMenu(fileName = "newStunData", menuName = "Enemy Data/State Data/Stun State")]
	public class D_EnemyStunState : ScriptableObject
	{
		public float StunTime = 3f;
	}
}