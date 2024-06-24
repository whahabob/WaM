using System.Collections.Generic;
using System.Diagnostics;
/// <summary>
/// UIManager keeps track of the UIComponents in the game
/// Every component which is part of a screen will get automaticly registered
/// </summary>
public class UIManager
{
    private static Dictionary<string, UIComponent> uiComponents = new Dictionary<string, UIComponent>();
    private static Dictionary<string, WaMScreen> wamScreens = new Dictionary<string, WaMScreen>();

    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UIManager();
            }
            return instance;
        }
    }

    // Register a UI component with a key and returns if it was succesfull
    public bool RegisterComponent(UIComponent component)
    {
        if (!uiComponents.ContainsKey(component.GetType().Name))
        {
            uiComponents.Add(component.GetType().Name, component);
            component.SetKey(component.GetType().Name);
            return true;
        }
        return false;
    }

    // Retrieve a UI component by key NOTE: Should be the class as string
    public UIComponent GetComponent(string key)
    {
        if (uiComponents.ContainsKey(key))
        {
            return uiComponents[key];
        }
        throw new KeyNotFoundException($"No UI component found for key: {key}");
    }

    // Show a UI component by key
    public void ShowComponent(string key)
    {
        GetComponent(key).Show();
    }

    // Hide a UI component by key
    public void HideComponent(string key)
    {
        GetComponent(key).Hide();
    }

    public void RegisterWaMScreen(WaMScreen screen)
    {
        if (!wamScreens.ContainsKey(screen.GetType().Name))
        {
            screen.SetKey(screen.GetType().Name);
            foreach (UIComponent component in screen.Children)
            {
                RegisterComponent(component);
            }
            wamScreens.Add(screen.GetType().Name, screen);
        }
    }

    public WaMScreen GetScreen(string key)
    {
        if (wamScreens.ContainsKey(key))
        {
            return wamScreens[key];
        }
        throw new KeyNotFoundException($"No UI component found for key: {key}");
    }

    public void ShowWaMScreen(string key)
    {
        foreach(WaMScreen waMScreen in wamScreens.Values)
        {
            waMScreen.Hide();
        }
        if (wamScreens.ContainsKey(key))
        {
            wamScreens[key].Show();
        }
    }

    public void HideWaMScreen(string key)
    {
        if (wamScreens.ContainsKey(key))
        {
            wamScreens[key].Hide();
        }
    }
}