using Sirenix.OdinInspector;
using UnityEngine;

namespace Suhdo
{
    public abstract class CustomUIComponent : MonoBehaviour, IUIComponent
    {
        public ThemeSO OverwriteTheme;
        
        protected virtual void OnValidate()
        {
            Init();
        }

        protected virtual void Awake()
        {
            Init();
        }

        [Button(Name = "Config now")]
        public virtual void Init()
        {
            Setup();
            Configure();
            SetTheme();
        }

        public abstract void Setup();

        public abstract void Configure();

        protected abstract void SetTheme();

        protected ThemeSO GetMainTheme()
        {
            if (OverwriteTheme != null)
            {
                return OverwriteTheme;
            }
            
            if (ThemeManager.I != null)
            {
                return ThemeManager.I.GetMainTheme();
            }

            return null;
        }
    }
}
