using UnityEngine;

namespace Suhdo.CharacterCore
{
    public class CoreComponent : MonoBehaviour
    {
        protected Core _core;

        protected virtual void Awake()
        {
            _core = transform.parent.GetComponent<Core>();
            if(_core == null) Debug.LogError("There are no Core on the parent!");
        }

        protected virtual void OnValidate()
        {
            _core = transform.parent.GetComponent<Core>();
            if(_core == null) Debug.LogError("There are no Core on the parent!");
        }
    }
}
