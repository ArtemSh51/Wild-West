using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private State _state;

    public void Initialize(State state)
    {
        _state = state;
        _state.Enter();
    }

    public void ChangeState(State state)
    {
        _state?.Exit();
        _state = state;
        _state?.Enter();
    }

    public void Update()
    {
        _state?.Update();
    }
}
