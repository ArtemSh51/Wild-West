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
        _health.ChangedHealthBar += ChangeHealthBar;
        _health.ChangedHealthText += ChangeHealthText;
    }

    public void Disable()
    {
        _health.ChangedHealthBar -= ChangeHealthBar;
        _health.ChangedHealthText -= ChangeHealthText;
    }

    private void ChangeHealthBar(float currentHealth)
    {
        _viewable.ChangeHealthBar(currentHealth);
    }

    private void ChangeHealthText(string text)
    {
        _viewable.ChangeHealthText(text);
    }
}
