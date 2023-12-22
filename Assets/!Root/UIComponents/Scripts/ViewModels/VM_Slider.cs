using Suhdo;
using UnityEngine;

public class VM_Slider : MonoBehaviour
{
    public CustomSlider Slider;

    public void OnHeathChanged(Component sender, object data)
    {
        if (data is int heathInt)
        {
            Slider.SetValue(heathInt);
        }
        else if(data is float heathFloat)
        {
            Slider.SetValue(heathFloat);
        }
    }
}
