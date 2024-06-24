using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// abstract Occupant class, will make sure it can be spawned on a tile and be interacted with
/// </summary>
public abstract class Occupant : UIImage
{
    public string Name;

    public int Health = 1;
    public override GameObject UIObject { get => gameObject;}
}