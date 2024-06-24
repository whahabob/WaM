using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIButton : UIComponent, IButton
{
    [SerializeField]private Button button;
    [SerializeField]private TMP_Text buttonText;

    public void SetText(string text)
    {
        buttonText.text = text;
    }

    public void SetOnClick(Action onClick)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => onClick());
    }
}