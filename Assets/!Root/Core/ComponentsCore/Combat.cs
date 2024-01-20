using Suhdo.CharacterCore;

namespace Suhdo.Player
{
    public class Combat : CoreComponent, IDamageable
    {
        public void Damage(float amount)
        {
            UnityEngine.Debug.Log("Damage!!!!");
        }
    }
}
