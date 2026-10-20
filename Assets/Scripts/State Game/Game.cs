using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private Health _playerHealth;

    [SerializeField] private int _indexWinScene;
    [SerializeField] private int _indexLoseScene;

    [SerializeField] private int _enimies1 = 5;
    [SerializeField] private float _speedSpawnEnemies1 = 5;

    [SerializeField] private int _enimies2 = 10;
    [SerializeField] private float _speedSpawnEnemies2 = 1;

    [SerializeField] private int _enimies3 = 15;
    [SerializeField] private float _speedSpawnEnemies3 = 0.5f;

    public StateMachine StateMachine { get; private set; }

    public Wave WaveLoader1 { get; private set; }

    public Wave WaveLoader2 { get; private set; }

    public Wave WaveLoader3 { get; private set; }

    public WindowLoader WinWindow { get; private set; }

    public WindowLoader LoseWindow { get; private set; }

    private void Awake()
    {
        StateMachine = new StateMachine();

        WaveLoader1 = new Wave(this, _spawner, _enimies1, _speedSpawnEnemies1);
        WaveLoader2 = new Wave(this, _spawner, _enimies2, _speedSpawnEnemies2);
        WaveLoader3 = new Wave(this, _spawner, _enimies3, _speedSpawnEnemies3);
        WinWindow = new WindowLoader(this, _indexWinScene);
        LoseWindow = new WindowLoader(this, _indexLoseScene);

        _spawner.enabled = false;

        StateMachine.Initialize(WaveLoader1);
    }

    private void OnEnable()
    {
        _playerHealth.PlayerKilled += LoadLoseScene;
    }

    private void Start()
    {
        WaveLoader1.EstablishSubsequentState(WaveLoader2);
        WaveLoader2.EstablishSubsequentState(WaveLoader3);
        WaveLoader3.EstablishSubsequentState(WinWindow);
    }

    private void OnDisable()
    {
        _playerHealth.PlayerKilled -= LoadLoseScene;
    }

    private void Update()
    {
        StateMachine.Update();
    }

    private void LoadLoseScene()
    {
        StateMachine.ChangeState(LoseWindow);
    }
}
