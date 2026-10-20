public class Wave : State
{
    private readonly int Enimies;
    private readonly float SpeedSpawnEnemies;

    private Game _game;
    private EnemySpawner _enemySpawner;
    private State _nextState;

    public Wave(Game game, EnemySpawner enemySpawner, int enimies, float speedSpawnEnemies)
    {
        _game = game;
        _enemySpawner = enemySpawner;
        Enimies = enimies;
        SpeedSpawnEnemies = speedSpawnEnemies;
    }

    public override void Enter()
    {
        _enemySpawner.enabled = true;
        _enemySpawner.SetCountOfEnimeis(Enimies);
        _enemySpawner.ResumeCurrentCountOfEnemies();
        _enemySpawner.ResetCountOfCreatedEnemies();
        _enemySpawner.SetSpeedSpawnEnemies(SpeedSpawnEnemies);
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
