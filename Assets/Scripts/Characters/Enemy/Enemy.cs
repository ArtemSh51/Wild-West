using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IKillable
{
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private EnemyAttacker _attacker;
    [SerializeField] private Transform _target;
    [SerializeField] private float _attackRange;

    private Coroutine _coroutine;
    private Health _targetHealth;

    public event Action<Enemy> EnemyKilled;

    private void Update()
    {
        if (_target == null)
        {
            StopAttack();

            return;
        }

        _mover.Move(_target);

        float distance = Vector3.Distance(transform.position, _target.position);

        if (distance <= _attackRange)
        {
            StartAttack();
        }
        else
        {
            StopAttack();
        }
    }

    public void SetTarget(Transform target)
    {
        if (_target == target)
        {
            return;
        }

        StopAttack();
        _target = target;
        _targetHealth = null;
    }

    public void Kill()
    {
        StopAttack();
        EnemyKilled?.Invoke(this);
    }

    private void StartAttack()
    {
        if (_coroutine != null)
        {
            return;
        }

        if (_targetHealth == null && !_target.TryGetComponent(out _targetHealth))
        {
            return;
        }

        _coroutine = StartCoroutine(_attacker.Attack(_targetHealth));
    }

    private void StopAttack()
    {
        if (_coroutine == null)
        {
            return;
        }

        StopCoroutine(_coroutine);
        _coroutine = null;
    }
}