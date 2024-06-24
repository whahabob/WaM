using System;

public class StartButton : UIButton
{
    public static Action callback;
    private void Start()
    {
        Initialize(this);
        SetText("Start game");
    }
    public virtual void Initialize(UIComponent uIComponent)
    {
        callback = () => FireGameStartEvent();
        SetOnClick(callback);
        
    }

    void FireGameStartEvent()
    {
        NameInputField nif = (NameInputField)UIManager.Instance.GetComponent("NameInputField");
        if (nif == null || string.IsNullOrEmpty(nif.GetFinalString()))
        {

            return;
        }

        WaMEventSystem.Instance.Notify(new GameStartedEvent() { PlayerName = nif.GetFinalString(), StartSettings = GameLoader.GetGameSettings(0).StartSettings });
    }
}