using System.Collections;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _timeBetweenAttacks;

    public IEnumerator Attack(Health health)
    {
        WaitForSeconds wait = new WaitForSeconds(_timeBetweenAttacks);

        while (true)
        {
            health.TakeDamage(_damage);

            yield return wait;
        }
    }
}