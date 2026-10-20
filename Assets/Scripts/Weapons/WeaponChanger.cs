using System.Collections.Generic;
using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    [SerializeField] private List<Transform> _weapons;
    [SerializeField] private InputReader _reader;

    private int _currentIndex;

    private void OnEnable()
    {
        _reader.ChangeWeaponButtonPressed += SwitchToNextWeapon;
    }

    private void OnDisable()
    {
        _reader.ChangeWeaponButtonPressed -= SwitchToNextWeapon;
    }

    private void SwitchToNextWeapon()
    {
        _weapons[_currentIndex].gameObject.SetActive(false);

        _currentIndex = (_currentIndex + 1) % _weapons.Count;

        _weapons[_currentIndex].gameObject.SetActive(true);
    }
}
