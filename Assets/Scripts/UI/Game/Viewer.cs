using UnityEngine;

public class Viewer : MonoBehaviour, IViewable
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private HealthText _health;

    public void ChangeHealthBar(float number)
    {
        _healthBar.SetValue(number);
    }

    public void ChangeHealthText(string text)
    {
        _health.SetValue(text);
    }
}
