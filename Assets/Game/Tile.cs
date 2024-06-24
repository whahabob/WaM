using System.Collections;
using UnityEngine;
/// <summary>
/// UI Object assosiated with the Tile
/// </summary>
public class Tile : UIImage
{
    public Vector2Int Position;
    public RectTransform OccupantTransform;
    public Occupant Occupant;
    private Color baseColor = new Color(1f, 1f, 1f);
    private Color badInteractColor = new Color(1f, 0, 0);
    private Color goodInteractColor = new Color(0, 1f, 0);


    public override void OnInteract()
    {
        StartCoroutine(Co_ShowInteraction());
    }

    private IEnumerator Co_ShowInteraction()
    {
        SetColor(Occupant == null ? badInteractColor : goodInteractColor);
        yield return new WaitForSeconds(0.1f);
        SetColor(baseColor);
    }

    public void Reset()
    {
        SetColor(baseColor);
        for (int i = 0; i < OccupantTransform.childCount; i++)
        {
            Destroy(OccupantTransform.GetChild(i).gameObject);
        }
        Occupant = null;
    }
}