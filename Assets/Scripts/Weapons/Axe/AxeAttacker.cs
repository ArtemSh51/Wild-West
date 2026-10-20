using UnityEngine;

public class AxeAttacker : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out IKillable killable))
        {
            killable.Kill();
        }
    }
}
