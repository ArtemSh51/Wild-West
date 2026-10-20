using UnityEngine;

public class MVPCreator : MonoBehaviour
{
    [SerializeField] private Viewer _viewer;
    [SerializeField] private Health _healthPlayer;

    private Presenter _presenter;
    private IViewable _viewable;

    private void Awake()
    {
        _viewable = _viewer;

        _presenter = new Presenter(_viewable, _healthPlayer);
    }

    private void OnEnable()
    {
        _presenter.Enable();
    }

    private void OnDisable()
    {
        _presenter.Disable();
    }
}
