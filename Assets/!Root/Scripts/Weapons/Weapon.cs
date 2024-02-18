using UnityEngine;

namespace Suhdo.Weapons
{
	public class Weapon : MonoBehaviour
	{
		public void Enter()
		{
			print($"{transform.name} enter");
		}
	}
}