using Suhdo.Combat;
using UnityEngine;

namespace Suhdo.CharacterCore
{
    public class CoreComponent : MonoBehaviour, ILogicUpdate
    {
        protected Core Core;

        protected virtual void Awake()
        {
            Core = transform.parent.GetComponent<Core>();
            if(Core == null) Debug.LogError("There are no Core on the parent!");
            Core.AddComponent(this);
        }

        protected virtual void OnValidate()
        {
            Core = transform.parent.GetComponent<Core>();
            if (Core == null) Debug.LogError("There are no Core on the parent!");
            Core.AddComponent(this);
        }

        public virtual void LogicUpdate() { }
    }
}
