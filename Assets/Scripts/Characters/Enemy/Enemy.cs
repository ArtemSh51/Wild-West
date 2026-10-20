using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IKillable
{
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private EnemyAttacker _attacker;
    [SerializeField] private Transform _target;

    public event Action<Enemy> EnemyKilled;

    private void Start()
    {
        if (_target != null)
        {
            StartCoroutine(_attacker.Attack(_target));
        }
    }

    private void Update()
    {
        if (_target != null)
        {
            _mover.Move(_target);
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void Kill()
    {
        EnemyKilled?.Invoke(this);
    }
}
