using System;
using UnityEngine;

namespace Suhdo.Weapons
{
	public class AnimationEventHandler : MonoBehaviour
	{
		public event Action OnFinish;
		public event Action OnStartMovement;
		public event Action OnStopMovement;
		
		private void AnimationFinishTrigger() => OnFinish?.Invoke();
		
		private void StartMovementTrigger() => OnStartMovement?.Invoke();

		private void StopMovementTrigger() => OnStopMovement?.Invoke();
	}
}