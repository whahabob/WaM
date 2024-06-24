using System;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : WaMScreen
{
    [SerializeField] private List<UIComponent> children;
    public override List<UIComponent> Children { get => children; set => children = value; }

    private void Start()
    {
        RegisterScreen();
        Hide();
    }

}