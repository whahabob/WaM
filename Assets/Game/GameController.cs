using System;
using UnityEngine;
/// <summary>
/// Keeps control over the life cycle of the WaM game and performs associated functions
/// </summary>
public class GameController : MonoBehaviour, IEventHandler<GameStartedEvent>, IEventHandler<GameEndedEvent>
{
    private bool isGameActive;

    public GameBoard board;
    private GameUIHandler gameUIHandler;

    private ActivePlayer activePlayer;
    private int currentLevel = 0;


    public StartSettings StartSettings { get; private set; }

    void Start()
    {
        gameUIHandler = new GameUIHandler(UIManager.Instance);
        WaMEventSystem.Instance.Subscribe((IEventHandler<GameStartedEvent>)this);
        WaMEventSystem.Instance.Subscribe((IEventHandler<GameEndedEvent>)this);
        board.CreateBoard(GameLoader.GetGameSettings(0).StartSettings.BoardSize);
    }

    public void OnEvent(GameStartedEvent args)
    {
        StartGame(args.StartSettings);
    }

    private void StartGame(StartSettings startSettings)
    {
        NameInputField nif = (NameInputField)UIManager.Instance.GetComponent(typeof(NameInputField).ToString());
        if (nif == null || string.IsNullOrEmpty(nif.GetFinalString()))
        {
            
            return;
        }
        activePlayer = new ActivePlayer(nif.GetFinalString());
        board.CreateBoard(StartSettings.BoardSize);
        foreach (Occupant occupant in startSettings.OccupantTypes)
        {
            StartSpawningNotify(occupant);
        }
        SetTimer(startSettings);
    }

    public void OnEvent(GameEndedEvent args)
    {
        if(activePlayer.CurrentHighscore >= ScoreManager.Instance.GetCurrentScore())
        {
            return;
        }

        activePlayer.CurrentHighscore = ScoreManager.Instance.GetCurrentScore();
    }

    private void SetTimer(StartSettings startSettings)
    {
        TimerText TT = (TimerText)UIManager.Instance.GetComponent("TimerText");
        TT.SetTimer(WaMTimerManager.Instance.AddTimer(startSettings.Duration, () => { WaMEventSystem.Instance.Notify(new GameEndedEvent() { Player = activePlayer }); }));
    }

    private void StartSpawningNotify(Occupant type)
    {
        switch (type)
        {
            case Mole:
                WaMEventSystem.Instance.Notify(new StartOccupantSpawning<Mole>() { });
                break;
        }
    }
}