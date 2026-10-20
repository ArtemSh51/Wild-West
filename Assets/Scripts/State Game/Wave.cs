public class Wave : State
{
    private readonly int _enimies;
    private readonly float _speedSpawnEnemies;

    private Game _game;
    private EnemySpawner _enemySpawner;
    private State _nextState;

    public Wave(Game game, EnemySpawner enemySpawner, int enimies, float speedSpawnEnemies)
    {
        _game = game;
        _enemySpawner = enemySpawner;
        _enimies = enimies;
        _speedSpawnEnemies = speedSpawnEnemies;
    }

    public override void Enter()
    {
        _enemySpawner.enabled = true;
        _enemySpawner.SetCountOfEnimeis(_enimies);
        _enemySpawner.ResumeCurrentCountOfEnemies();
        _enemySpawner.ResetCountOfCreatedEnemies();
        _enemySpawner.SetSpeedSpawnEnemies(_speedSpawnEnemies);
    }

    public override void Update()
    {
        if (_enemySpawner.CurrentCountOfEnemies == 0 && _nextState != null)
        {
            _enemySpawner.enabled = false;
            _game.StateMachine.ChangeState(_nextState);
        }
    }

    public void EstablishSubsequentState(State nextState)
    {
        _nextState = nextState;
    }
}
