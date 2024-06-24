using System;

public interface IButton : IUIComponent
{
    void SetText(string text);
    void SetOnClick(Action onClick);
}