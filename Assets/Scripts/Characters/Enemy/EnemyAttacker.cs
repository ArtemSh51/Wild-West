using System.Collections;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private float _attackRange;
    [SerializeField] private int _damage;
    [SerializeField] private float _timeBetweenAttacks;

    public bool _canAttack = true;

    public IEnumerator Attack(Transform target)
    {
        WaitForSeconds wait = new WaitForSeconds(_timeBetweenAttacks);

        while (_canAttack)
        {
            if (Vector3.Distance(transform.position, target.position) <= _attackRange && target.TryGetComponent(out Health health))
            {
                health.TakeDamage(_damage);
            }

            yield return wait;
        }
    }
}
