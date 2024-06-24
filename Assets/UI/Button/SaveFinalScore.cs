public class SaveFinalScore : UIButton, IEventHandler<GameEndedEvent>
{
    private ActivePlayer activePlayer;
    private void Start()
    {
        WaMEventSystem.Instance.Subscribe(this); 
        Initialize(this);
        SetText("Save score");
    }
    public virtual void Initialize(UIComponent uIComponent)
    {

        SetOnClick(() => SaveScore());

    }

    void SaveScore()
    {
        ScoreManager.Instance.SaveScore();
        UIManager.Instance.ShowWaMScreen("HighscoreScreen");
    }

    public void OnEvent(GameEndedEvent args)
    {
        activePlayer = args.Player;
    }
}