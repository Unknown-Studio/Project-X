using TMPro;
using Unity.VisualScripting;

namespace Suhdo
{
    public class Text : CustomUIComponent
    {
        public TextSO Data;
        public EnumStyle Style;

        private TMP_Text _text;
        
        public override void Setup()
        {
            _text = GetComponentInChildren<TMP_Text>();
        }

        public override void Configure()
        {
            _text.font = Data.Font;
            _text.fontSize = Data.Size;
        }

        protected override void SetTheme()
        {
            ThemeSO theme = GetMainTheme();
            if(theme == null) return;
            
            _text.color = theme.GetTextColor(Style);
            _text.color = theme.GetTextColor(Style);
        }

        public void SetText(string value)
        {
            _text.text = value;
        }
    }
}
