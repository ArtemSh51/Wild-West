using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private KeyCode _useWeaponKeyCode = KeyCode.Mouse0;
    [SerializeField] private KeyCode _changeWeoponKeyCode = KeyCode.Q;

    public event Action UseWeaponButtonPressed;
    public event Action ChangeWeaponButtonPressed;

    private void Update()
    {
        if (Input.GetKeyDown(_useWeaponKeyCode))
        {
            UseWeaponButtonPressed?.Invoke();
        }

        if (Input.GetKeyDown(_changeWeoponKeyCode))
        {
            ChangeWeaponButtonPressed?.Invoke();
        }
    }

    public float GetAxisHorizontal()
    {
        return Input.GetAxis(Horizontal);
    }

    public float GetAxisVertical()
    {
        return Input.GetAxis(Vertical);
    }

    public float GetMouseX()
    {
        return Input.GetAxis("Mouse X");
    }
}
