using UnityEngine;

public class Controller_Heath : MonoBehaviour
{
    public int StartingHeath;
    
    [Header("Events")]
    public GameEvent OnHeathChanged;

    private Model_Heath _heath;

    private void Awake()
    {
        _heath = new Model_Heath(100);
    }

    private void Start()
    {
        OnHeathChanged.Raise(this, _heath.GetCurrentHeath());
    }

    public void OnHeathDecrease(Component sender, object data)
    {
        if (data is int amount)
        {
            _heath.Decrease(amount);
            OnHeathChanged.Raise(this, _heath.GetCurrentHeath());
        }
    }
    
    public void OnHeathIncrease(Component sender, object data)
    {
        if (data is int amount)
        {
            _heath.Increase(amount);
            OnHeathChanged.Raise(this, _heath.GetCurrentHeath());
        }
    }
}
