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
			Stats.Health.Decrease(amount);
			ParticlesManager.StartParticleWithRandomRotation(hitPool.Get());
		}
	}
}