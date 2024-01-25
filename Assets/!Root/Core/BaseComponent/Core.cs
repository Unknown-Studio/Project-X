using System.Collections.Generic;
using System.Linq;
using Suhdo.Combat;
using Suhdo.Generics;
using UnityEngine;

namespace Suhdo.CharacterCore
{
    public class Core : MonoBehaviour
    {
        private readonly List<CoreComponent> _components = new List<CoreComponent>();

        private void Awake()
        {
            
        }

        protected virtual void OnValidate()
        {
            
        }

        public virtual void LogicUpdate()
        {
            foreach (var component in _components)
            {
                component.LogicUpdate();
            }
        }

        public void AddComponent(CoreComponent component)
        {
            if (_components.Contains(component)) return;
                _components.Add(component);
        }

        public T GetCoreComponent<T>() where T : CoreComponent
        {
            var comp = _components.OfType<T>().FirstOrDefault();
            if(comp == null) Debug.LogWarning($"{typeof(T)} not found on {transform.parent.name}");
            return comp;
        }
    }
}
