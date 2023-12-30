using UnityEngine;

namespace Suhdo.CharacterCore
{
    public class PlayerCoreComponent : MonoBehaviour
    {
        protected PlayerCore PlayerCore;

        protected virtual void Awake()
        {
            PlayerCore = transform.parent.GetComponent<PlayerCore>();
            if(PlayerCore == null) Debug.LogError("There are no Core on the parent!");
        }

        protected virtual void OnValidate()
        {
            PlayerCore = transform.parent.GetComponent<PlayerCore>();
            if(PlayerCore == null) Debug.LogError("There are no Core on the parent!");
        }
    }
}
