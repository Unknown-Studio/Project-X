using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Suhdo
{
    public class CustomButton : CustomUIComponent
    {
        public EnumStyle Style;
        public UnityEvent OnClick;
        
        private Button _button;
        private TMP_Text _buttonText;
        public override void Setup()
        {
            _button = GetComponentInChildren<Button>();
            _buttonText = GetComponentInChildren<TMP_Text>();
        }

        public override void Configure()
        {
            
        }

        protected override void SetTheme()
        {
            ThemeSO theme = GetMainTheme();
            if (theme == null) return;
            
            ColorBlock cb = _button.colors;
            cb.normalColor = theme.GetBackgroundColor(Style);
            _button.colors = cb;

            _buttonText.color = theme.GetTextColor(Style);
        }

        public void OnButtonClick()
        {
            OnClick.Invoke();
        }
    }
}
