public class ScoreText : UITMP_Text, IEventHandler<ScoreUpdatedEvent>
{
    private void Start()
    {
        WaMEventSystem.Instance.Subscribe(this);
        SetText("Score: 0");
    }

    private void OnDestroy()
    {
        WaMEventSystem.Instance.Unsubscribe(this);
    }
    public void OnEvent(ScoreUpdatedEvent args)
    {
        SetText("Score: " + args.score);
    }
}