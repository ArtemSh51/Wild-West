using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Player _player;
    [SerializeField] private float _minAngle = 0;
    [SerializeField] private float _maxAngle = 360;
    [SerializeField] private float _yPosition;
    [SerializeField] private float _radius;

    [SerializeField] private int _defaultCountsOfEnemies;
    [SerializeField] private int _maxSize;
    
    private float _timeBeforeEnemySpawn;
    private int _countOfEnimies;
    private int _countOfEnemiesCreated;

    private ObjectPool<Enemy> _enemyPool;
    private WaitForSeconds _wait;
    private bool _canSpawn = true;

    public int CurrentCountOfEnemies { get; private set; }

    private void Start()
    {
        _enemyPool = new ObjectPool<Enemy>
        (
            createFunc: () => Instantiate(_enemyPrefab),
            actionOnGet: (enemy) => PrepareBulletBeforeUseBullet(enemy),
            actionOnRelease: (enemy) => PrepareBulletAfterUse(enemy),
            actionOnDestroy: (enemy) => Destroy(enemy.gameObject),
            collectionCheck: true,
            defaultCapacity: _defaultCountsOfEnemies,
            maxSize: _maxSize
        );

        StartCoroutine(CreateEnemy());
    }

    public void SetCountOfEnimeis(int countOfEnimies)
    {
        _countOfEnimies = countOfEnimies;
    }

    public void ResumeCurrentCountOfEnemies()
    {
        CurrentCountOfEnemies = _countOfEnimies;
    }

    public void ResetCountOfCreatedEnemies()
    {
        _countOfEnemiesCreated = 0;
    }

    public void SetSpeedSpawnEnemies(float timeBeforeEnemySpawn)
    {
        _timeBeforeEnemySpawn = timeBeforeEnemySpawn;

        _wait = new WaitForSeconds(_timeBeforeEnemySpawn);
    }

    private void PrepareBulletBeforeUseBullet(Enemy enemy)
    {
        enemy.EnemyKilled += ReturnEnemy;
        enemy.gameObject.SetActive(true);
    }

    private void PrepareBulletAfterUse(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        enemy.EnemyKilled -= ReturnEnemy;
        enemy.transform.position = Vector3.zero;
        enemy.transform.rotation = Quaternion.identity;
    }

    private void ReturnEnemy(Enemy enemy)
    {
        _enemyPool.Release(enemy);
        CurrentCountOfEnemies--;
    }

    private IEnumerator CreateEnemy()
    {
        while (_canSpawn)
        {
            if (_countOfEnemiesCreated < _countOfEnimies)
            {
                _countOfEnemiesCreated++;

                Enemy newEnemy = _enemyPool.Get();

                newEnemy.SetTarget(_player.transform);

                float randomX = Mathf.Sin(Random.Range(_minAngle, _maxSize)) * _radius;
                float randomZ = Mathf.Cos(Random.Range(_minAngle, _maxSize)) * _radius;

                newEnemy.transform.position = new Vector3(randomX, _yPosition, randomZ);

                yield return _wait;
            }
            else
            {
                yield return null;
            }
        }
    }
}
