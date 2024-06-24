using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIImage : UIComponent, IImage
{
    private Image image;

    public void SetColor(Color color)
    {
        image.color = color;
    }

    public void SetSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }

    private void Awake()
    {
        image = GetComponent<Image>();
    }

   
}