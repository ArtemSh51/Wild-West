using System.Collections.Generic;
using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    [SerializeField] private List<Transform> _weapons;
    [SerializeField] private InputReader _reader;

    private int currentIndex;

    private void OnEnable()
    {
        _reader.ChangeWeaponButtonPressed += ChangeWeapon;
    }

    private void OnDisable()
    {
        _reader.ChangeWeaponButtonPressed -= ChangeWeapon;
    }

    private void ChangeWeapon()
    {
        _weapons[currentIndex % _weapons.Count].gameObject.SetActive(true);
        _weapons[++currentIndex % _weapons.Count].gameObject.SetActive(false);
    }
}
