using Suhdo;
using UnityEngine;

public class VM_Text : MonoBehaviour
{
    public Text TextView;

    public void OnHeathChanged(Component sender, object data)
    {
        if (data is not int heath) return;
        var heathString = heath.ToString();
        TextView.SetText(heathString);
    }
}
