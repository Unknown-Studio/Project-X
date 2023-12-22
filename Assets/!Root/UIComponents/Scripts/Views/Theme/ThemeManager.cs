using UnityEngine;

namespace Suhdo
{
    [DefaultExecutionOrder(-1)]
    public class ThemeManager : MonoBehaviour
    {
        [SerializeField] private ThemeSO mainTheme;

        public static ThemeManager I;

        private void Awake()
        {
            I = this;
        }

        public ThemeSO GetMainTheme()
        {
            return mainTheme;
        }
    }
}
