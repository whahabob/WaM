using TMPro;
using UnityEngine;
using static TMPro.TMP_InputField;
[RequireComponent(typeof(TMP_InputField))]
public abstract class UIInputField : UIComponent
{
    private string finalString;
    private TMP_InputField tmpInputField;
    private void Start()
    {
        tmpInputField = GetComponent<TMP_InputField>();
        tmpInputField.onEndEdit.AddListener((_) => InteractFinished());
    }
    public virtual void InteractFinished()
    {
        finalString = tmpInputField.text;
    }

    public virtual string GetFinalString()
    {
       return finalString;
    }

    public override void OnInteract()
    {
        tmpInputField.Select();
    }
}
