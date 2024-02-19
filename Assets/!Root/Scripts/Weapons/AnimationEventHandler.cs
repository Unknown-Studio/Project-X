using System;
using UnityEngine;

namespace Suhdo.Weapons
{
	public class AnimationEventHandler : MonoBehaviour
	{
		public event Action Exit;
		public void AnimationFinishTrigger()
		{
			Exit?.Invoke();
		}
	}
}