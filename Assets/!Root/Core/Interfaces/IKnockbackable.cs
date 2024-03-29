using UnityEngine;

namespace Suhdo.CharacterCore
{
    public interface IKnockbackable
    {
        void Knockback(Vector2 angle, float strength, int direction);
    }
}
