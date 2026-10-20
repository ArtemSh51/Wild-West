using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AxeAnimator : MonoBehaviour
{
    private const string Chop = nameof(Chop);

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void HitAnimation()
    {
        _animator.Play(Chop);
    }
}
