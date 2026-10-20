using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerRotator _playerRotator;
    [SerializeField] private InputReader _inputReader;

    private void Awake()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        _playerMover.Move(_inputReader);
        _playerRotator.Rotate(_inputReader);
    }
}
