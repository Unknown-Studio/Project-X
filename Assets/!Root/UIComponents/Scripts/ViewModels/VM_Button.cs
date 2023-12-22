using Suhdo;
using UnityEngine;

public class ButtonVM : MonoBehaviour
{
    public CustomButton Button;

    [Header("Event")] public GameEvent OnClick;
    [Header("Event Data")] public int value;

    private void OnEnable()
    {
        Button.OnClick.AddListener(OnClickButton);
    }

    private void OnDisable()
    {
        Button.OnClick.RemoveListener(OnClickButton);
    }

    public void OnClickButton()
    {
        OnClick.Raise(this, value);
    }
}
