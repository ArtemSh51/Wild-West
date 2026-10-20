public class Presenter
{
    private IViewable _viewable;
    private Health _health;

    public Presenter(IViewable viewer, Health health)
    {
        _viewable = viewer;
        _health = health;
    }

    public void Enable()
    {
        _health.Changed += HealthChanged;
    }

    public void Disable()
    {
        _health.Changed -= HealthChanged;
    }

    private void HealthChanged(float currentHealth)
    {
        _viewable.ChangeHealthBar(currentHealth);
    }
}
