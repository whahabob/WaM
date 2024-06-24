using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour, IScoreManager, IEventHandler<GameStartedEvent>, IEventHandler<GameEndedEvent>, IEventHandler<MoleClearedEvent>
{
    public static ScoreManager Instance { get; private set; }
    public ActivePlayer ActivePlayer { get; private set; }

    public IUserSaver userSaver;
    public static int CurrentScore 
    { 
        get => currentScore; 
        private set 
        { 
            currentScore = value;
            WaMEventSystem.Instance.Notify(new ScoreUpdatedEvent { score = value });
        } 
    }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            userSaver = new PlayerPrefsSaver();
            Instance = this;
            WaMEventSystem.Instance.Subscribe((IEventHandler<GameStartedEvent>)this);
            WaMEventSystem.Instance.Subscribe((IEventHandler<GameEndedEvent>)this);
            WaMEventSystem.Instance.Subscribe((IEventHandler<MoleClearedEvent>)this);
        }
    }

    private static int currentScore;

    public void AddScore(int score)
    {
        CurrentScore += score;
    }

    public void ResetScore()
    {
        CurrentScore = 0;
    }

    public void SaveScore()
    {
        if(ActivePlayer == null)
        {
            return;
        }
         userSaver.SavePlayerScore(ActivePlayer, GetCurrentScore());
    }

    public int GetCurrentScore()
    {
        return CurrentScore;
    }

    public void OnEvent(GameStartedEvent args)
    {
        if(ActivePlayer == null || ActivePlayer.Name != args.PlayerName)
        {
            ActivePlayer = new ActivePlayer(args.PlayerName);
        }
        ResetScore();
    }

    public void OnEvent(GameEndedEvent args)
    {
        
        SaveScore();
    }

    public void OnEvent(MoleClearedEvent args)
    {
        AddScore(100);
    }

    public void SubtractScore(int score)
    {
        AddScore(-score);
    }
}