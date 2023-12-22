using TMPro;
using UnityEngine;

namespace Suhdo
{
    [CreateAssetMenu(menuName = "CustomUI/TextSO", fileName = "TextSO")]
    public class TextSO : ScriptableObject
    {
        public TMP_FontAsset Font;
        public float Size;
    }
}
