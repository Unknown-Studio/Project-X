using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suhdo
{
    [CreateAssetMenu(menuName = "CustomUI/SliderSO", fileName = "SliderSO")]
    public class SliderSO : ScriptableObject
    {
        public float MinValue;
        public float MaxValue;
        public bool Interactable;
        public Color FillColor;
        public Color BackgroundColor;
    }
}
