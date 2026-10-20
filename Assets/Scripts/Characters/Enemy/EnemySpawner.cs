using System.Collections;
using UnityEngine;

public class EnemySpawner : Pool<Enemy>
{
    [SerializeField] private Player _player;
    [SerializeField] private float _minAngle = 0;
    [SerializeField] private float _maxAngle = 360;
    [SerializeField] private float _yPosition;
    [SerializeField] private float _radius;

    [SerializeField] private int _defaultCountsOfEnemies;

    private float _timeBeforeEnemySpawn;
    private int _countOfEnimies;
    private int _countOfEnemiesCreated;

    private WaitForSeconds _wait;
    private bool _canSpawn = true;

    public int CurrentCountOfEnemies { get; private set; }

    private void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    protected override void Subscribe(Enemy enemy)
    {
        enemy.EnemyKilled += ReturnEnemy;
    }

    protected override void Unsubscribe(Enemy enemy)
    {
        enemy.EnemyKilled -= ReturnEnemy;
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

    private void ReturnEnemy(Enemy enemy)
    {
        Release(enemy);
        CurrentCountOfEnemies--;
    }

    private IEnumerator CreateEnemy()
    {
        while (_canSpawn)
        {
            if (_countOfEnemiesCreated < _countOfEnimies)
            {
                _countOfEnemiesCreated++;

                Enemy newEnemy = Get();

                newEnemy.SetTarget(_player.transform);

                float randomX = Mathf.Sin(Random.Range(_minAngle, _maxAngle)) * _radius;
                float randomZ = Mathf.Cos(Random.Range(_minAngle, _maxAngle)) * _radius;

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