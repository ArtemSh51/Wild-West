using UnityEngine;

public class Axe : MonoBehaviour
{
    [SerializeField] private AxeAnimator _animator;
    [SerializeField] private InputReader _inputReader;

    private void OnEnable()
    {
        _inputReader.UseWeaponButtonPressed += Hit;
    }

    private void OnDisable()
    {
        _inputReader.UseWeaponButtonPressed -= Hit;
    }

    public void Hit()
    {
        _animator.HitAnimation();
    }
}
