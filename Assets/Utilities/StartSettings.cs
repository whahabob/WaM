using NUnit.Framework;
using System;
using System.Collections.Generic;
[Serializable]
public struct StartSettings
{
    public string Name;
    public int Duration;
    public int BoardSize;
    public Occupant[] OccupantTypes;
}