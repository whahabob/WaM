public class FinalScoreText : UITMP_Text, IEventHandler<GameEndedEvent>
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
    public void OnEvent(GameEndedEvent args)
    {
        string result = ScoreManager.Instance.GetCurrentScore() == args.Player.CurrentHighscore ? $"You reached a new Highscore!!" : $"Your previous best highscore {args.Player.CurrentHighscore}";
        SetText($"Well done {args.Player.Name}! \n" +
            $"Your final score is {ScoreManager.Instance.GetCurrentScore()} \n" +
            $"{result}");
    }

}