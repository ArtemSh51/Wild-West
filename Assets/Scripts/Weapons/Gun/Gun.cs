using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _gunBarrel;
    [SerializeField] private float _forceShoot;

    [SerializeField] private GunSounder _gunSound;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private BulletSpawner _bulletSpawner;

    private void OnEnable()
    {
        _inputReader.UseWeaponButtonPressed += Shoot;
    }

    private void OnDisable()
    {
        _inputReader.UseWeaponButtonPressed -= Shoot;
    }

    private void Shoot()
    {
        Bullet newBullet = _bulletSpawner.GetBullet();
        newBullet.transform.position = _gunBarrel.position;
        newBullet.Fly(_gunBarrel.forward * _forceShoot, ForceMode.Impulse);

        _gunSound.Shoot();
    }
}
