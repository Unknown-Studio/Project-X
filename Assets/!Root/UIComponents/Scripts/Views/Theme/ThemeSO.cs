using UnityEngine;

namespace Suhdo
{
    [CreateAssetMenu(menuName = "CustomUI/ThemeSO", fileName = "ThemeSO")]
    public class ThemeSO : ScriptableObject
    {
        [Header("Primary")]
        [SerializeField] private Color Primary_bg;
        [SerializeField] private Color Primary_text;
        
        [Header("Secondary")]
        [SerializeField] private Color Secondary_bg;
        [SerializeField] private Color Secondary_text;
        
        [Header("Tertiary")]
        [SerializeField] private Color Tertiary_bg;
        [SerializeField] private Color Tertiary_text;

        [Header("Other")]
        [SerializeField] private Color Disable;

        public Color GetBackgroundColor(EnumStyle style)
        {
            return style switch
            {
                EnumStyle.Primary => Primary_bg,
                EnumStyle.Secondary => Secondary_bg,
                EnumStyle.Tertiary => Tertiary_bg,
                _ => Disable
            };
        }
        
        public Color GetTextColor(EnumStyle style)
        {
            return style switch
            {
                EnumStyle.Primary => Primary_text,
                EnumStyle.Secondary => Secondary_text,
                EnumStyle.Tertiary => Tertiary_text,
                _ => Disable
            };
        }
    }
}
