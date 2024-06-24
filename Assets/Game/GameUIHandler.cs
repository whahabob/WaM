using System;
using UnityEngine.EventSystems;
/// <summary>
/// Will show screens based on fired events
/// </summary>
public class GameUIHandler : IEventHandler<GameStartedEvent>, IEventHandler<GameEndedEvent>
{
    private UIManager uiManager;

    public GameUIHandler(UIManager uiManager)
    {
        this.uiManager = uiManager;

        // Subscribe to game events
        WaMEventSystem.Instance.Subscribe((IEventHandler<GameStartedEvent>)this);
        WaMEventSystem.Instance.Subscribe((IEventHandler<GameEndedEvent>)this);
        Initialize();
    }

    public void OnEvent(GameStartedEvent args)
    {
        UIManager.Instance.ShowWaMScreen("GameScreen");
    }

    public void OnEvent(GameEndedEvent args)
    {
        UIManager.Instance.ShowWaMScreen("FinishedScreen");
    }

    private void Initialize()
    {
    }

}