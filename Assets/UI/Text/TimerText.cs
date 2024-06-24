public class TimerText : UITMP_Text, IEventHandler<TimerUpdatedEvent>
{
    private Timer timer;
    public int CurrentTime;
    public void OnEvent(TimerUpdatedEvent args)
    {
        SetText("Timer: " + args.newTimeLeft);
    }

    private void Start()
    {
        WaMEventSystem.Instance.Subscribe(this);

        if (UIManager.Instance.RegisterComponent(this))
        {
            SetText("Timer: ");
        }
    }

    private void Update()
    {
        if (timer == null)
        {
            return;
        }
        CurrentTime = timer.Duration - timer.ElapsedTime;
        SetText("Timer: " + CurrentTime);
    }


    private void OnDestroy()
    {
        WaMEventSystem.Instance.Unsubscribe(this);
    }

    public void SetTimer(Timer timer)
    {
        this.timer = timer;
    }
}