using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Rotate(InputReader inputReader)
    {
        float mouseX = inputReader.GetMouseX();

        transform.Rotate(0, mouseX * _speed * Time.deltaTime, 0);
    }
}
