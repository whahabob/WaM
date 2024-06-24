using UnityEngine;
/// <summary>
/// Mole as Occupant
/// </summary>
public class Mole : Occupant, IMole
{
    private bool isVisible;
    private Tile tile;

    public bool IsVisible => isVisible;

    public void Initialize(Tile assignedTile)
    {
        tile = assignedTile;
    }

    public void Hit()
    {
        Health--;
        tile.OnInteract();
        if (Health <= 0 )
        {
            WaMEventSystem.Instance.Notify(new MoleClearedEvent { Tile = tile });
        }
    }

    public override void OnInteract()
    {
        Hit();
    }
}