using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifetime;

    private Rigidbody _rigidbody;

    public event Action<Bullet> LifetimeExpired;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        StartCoroutine(KillBullet());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out IKillable killable))
        {
            killable.Kill();
        }
    }

    public void Fly(Vector3 direction)
    {
        _rigidbody.AddForce(direction, ForceMode.Impulse);
    }

    private IEnumerator KillBullet()
    {
        yield return new WaitForSeconds(_lifetime);

        LifetimeExpired?.Invoke(this);
    }
}
