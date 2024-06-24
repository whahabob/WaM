using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
/// <summary>
/// Keeps track of the click's of the user and performs interact if UIComponent is clicked
/// </summary>
public class MyVirtualCursor : MonoBehaviour
{

    [SerializeField] GraphicRaycaster m_Raycaster;
    [SerializeField] WaMEventSystem m_EventSystem;
    [SerializeField] RectTransform canvasRect;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (RaycastUtilities.PointerIsOverUI(Input.mousePosition))
            {
                GameObject gameObject = RaycastUtilities.GetHoveredUIObject(Input.mousePosition);
                UIComponent element = gameObject.GetComponent<UIComponent>();
                if (element != null)
                {
                    element.OnInteract();
                }
            }
        }     
    }

}