namespace Suhdo.Weapons.Components
{
	public class WeaponSpriteData : ComponentData<AttackSprites>
	{
		public WeaponSpriteData()
		{
			ComponentDependency = typeof(WeaponSprite);
		}
	}
}