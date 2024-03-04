using Suhdo.Ultils;
using UnityEngine;

namespace Suhdo.CharacterCore
{
	public class DamageReceiver : CoreComponent, IDamageable
	{
		[SerializeField] private ObjectPoolSO hitPool;

		private void OnDisable()
		{
			hitPool.ClearPool();
		}

		public void Damage(float amount)
		{
			Debug.Log("Damage!!!!");
			Stats.DecreaseHealth(amount);
			ParticlesManager.StartParticleWithRandomRotation(hitPool.Get());
		}
	}
}