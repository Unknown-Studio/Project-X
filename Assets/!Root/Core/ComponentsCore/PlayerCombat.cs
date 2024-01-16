using Suhdo.CharacterCore;

namespace Suhdo.Player
{
    public class PlayerCombat : PlayerCoreComponent, IDamageable
    {
        public void Damage(float amount)
        {
            UnityEngine.Debug.Log("Damage!!!!");
        }
    }
}
