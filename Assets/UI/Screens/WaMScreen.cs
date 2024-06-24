using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public abstract class WaMScreen : MonoBehaviour
{
    public string Key { get; private set; }
    public string Name { get { return GetType().Name; } }
    public abstract List<UIComponent> Children { get; set; }
    public virtual void Show()
    {
        foreach (UIComponent child in Children)
        {
            child.Show();
        }
        
    }
    public virtual void Hide()
    {
        foreach (UIComponent child in Children)
        {
            child.Hide();
        }
    }
    public virtual void RegisterScreen()
    {
        UIManager.Instance.RegisterWaMScreen(this);
    }

    public virtual void SetKey(string key)
    {
        Key = key;
    }

}
