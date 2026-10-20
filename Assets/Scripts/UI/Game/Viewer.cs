using UnityEngine;

public class Viewer : MonoBehaviour, IViewable
{
    [SerializeField] private HealthBar _healthBar;

    public void ChangeHealthBar(float number)
    {
        _healthBar.SetValue(number);
    }
}
