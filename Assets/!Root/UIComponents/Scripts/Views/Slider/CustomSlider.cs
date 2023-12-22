using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Suhdo
{
    public class CustomSlider : CustomUIComponent
    {
        public SliderSO Data;
        public Slider Slider;
        public Image FillImage;
        public Image BackgroundImage;
        
        public override void Setup()
        {
        }

        public override void Configure()
        {
            Slider.interactable = Data.Interactable;
            Slider.minValue = Data.MinValue;
            Slider.maxValue = Data.MaxValue;
            FillImage.color = Data.FillColor;
            BackgroundImage.color = Data.BackgroundColor;
        }

        protected override void SetTheme()
        {
        }

        public void SetValue(float value)
        {
            this.Slider.value = value;
        }
    }
}
