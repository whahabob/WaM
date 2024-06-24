using System;

public abstract class SpawnOccupantEvent<T> where T : Occupant
{
    public Tile Tile { get; set; }
    public virtual Occupant NewOccupant { get; set; }
}
