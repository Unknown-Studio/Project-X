using UnityEngine;
using UnityEngine.UI;

namespace Suhdo
{
    public class View : CustomUIComponent
    {
        public  ViewSO Data;
        public EnumStyle Style;

        public GameObject ContainerTop;
        public GameObject ContainerCenter;
        public GameObject ContainerBottom;

        private VerticalLayoutGroup VerticalLayoutGroup;

        private Image imageTop;
        private Image imageCenter;
        private Image imageBottom;

        public override void Setup()
        {
            VerticalLayoutGroup = GetComponent<VerticalLayoutGroup>();
            imageTop = ContainerTop.GetComponent<Image>();
            imageCenter = ContainerCenter.GetComponent<Image>();
            imageBottom = ContainerBottom.GetComponent<Image>();
        }

        public override void Configure()
        {
            VerticalLayoutGroup.padding = Data.padding;
            VerticalLayoutGroup.spacing = Data.spacing;
        }

        protected override void SetTheme()
        {
            ThemeSO theme = GetMainTheme();
            if(theme == null) return;
            
            imageTop.color = theme.GetBackgroundColor(EnumStyle.Primary);
            imageCenter.color = theme.GetBackgroundColor(EnumStyle.Secondary);
            imageBottom.color = theme.GetBackgroundColor(EnumStyle.Tertiary);
        }
    }
}
