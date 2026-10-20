using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable, IKillable
{
    [SerializeField] private int _value;

    public event Action<float> Changed;
    public event Action PlayerKilled;

    private int _maxValue;

    private void Awake()
    {
        _maxValue = _value;
    }

    public void TakeDamage(int damage)
    {
        _value -= damage;

        _value = Mathf.Clamp(_value, 0, _maxValue);

        Changed?.Invoke((float)_value / _maxValue);

        if (_value == 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        PlayerKilled?.Invoke();
    }
}
