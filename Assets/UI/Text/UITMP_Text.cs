using UnityEngine;
using System;
using TMPro;
[RequireComponent(typeof(TMP_Text))]
public abstract class UITMP_Text : UIComponent
{
    private TMP_Text tMP_Text;

    private void Awake()
    {
        tMP_Text = GetComponent<TMP_Text>();
    }
    public void SetText(string text)
    {
        tMP_Text.text = text;
    }
}