using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private CharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    public void Move(InputReader inputReader)
    {
        float horizontal = inputReader.GetAxisHorizontal();
        float vertical = inputReader.GetAxisVertical();

        Vector3 movement = (transform.forward * vertical + transform.right * horizontal).normalized;

        _controller.Move(movement * _speed * Time.deltaTime);
    }
}
