
using System.Collections.Generic;
using UnityEngine;

public class MenuScreen : WaMScreen
{
    [SerializeField] private List<UIComponent> children = new List<UIComponent>();
    public override List<UIComponent> Children { get => children; set { children = value; } }


    void Start()
    {
        RegisterScreen();
    }
}