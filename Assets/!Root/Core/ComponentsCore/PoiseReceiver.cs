namespace Suhdo.CharacterCore
{
	public class PoiseReceiver : CoreComponent, IPoiseDamageable
	{
		public void PoiseDamage(float amount)
		{
			Stats.Poise.Decrease(amount);
		}
	}
}