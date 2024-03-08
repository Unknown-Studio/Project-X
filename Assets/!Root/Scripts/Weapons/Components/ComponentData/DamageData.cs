namespace Suhdo.Weapons.Components
{
	public class DamageData : ComponentData<AttackDamage>
	{
		public DamageData()
		{
			ComponentDependency = typeof(Damage);
		}
	}
}