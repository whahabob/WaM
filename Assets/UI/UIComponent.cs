using UnityEngine;

public abstract class UIComponent : MonoBehaviour, IUIComponent
{
    public virtual GameObject UIObject { get; private set; }

    public string Key { get; private set; }

    public string GetKey()
    {
        return Key;
    }

    public void SetKey(string key)
    {
        if (UIManager.Instance.GetComponent(key) != null)
        {
            Debug.LogWarning($"This key already exists {key}");
            return;
        }
        Key = key;
    }
    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    public virtual void OnInteract()
    {
        Debug.Log("UI Component clicked");
    }
}