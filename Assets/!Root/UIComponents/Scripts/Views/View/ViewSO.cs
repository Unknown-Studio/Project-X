using UnityEngine;

namespace Suhdo
{
    [CreateAssetMenu(menuName = "CustomUI/ViewSO", fileName = "ViewSO")]
    public class ViewSO : ScriptableObject
    {
        public RectOffset padding;
        public float spacing;
    }
}
