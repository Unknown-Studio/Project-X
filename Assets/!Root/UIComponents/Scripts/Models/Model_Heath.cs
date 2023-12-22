using UnityEngine;

public class Model_Heath
{
    private int _startingHeath;
    private int _currentHeath;

    public Model_Heath(int startingHeath)
    {
        _startingHeath = startingHeath;
        Reset();
    }

    public int GetCurrentHeath()
    {
        return _currentHeath;
    }

    public void Decrease(int amount)
    {
        _currentHeath -= Mathf.Abs(amount);
    }

    public void Increase(int amount)
    {
        _currentHeath += Mathf.Abs(amount);
    }

    public void Reset()
    {
        _currentHeath = _startingHeath;
    }
}
