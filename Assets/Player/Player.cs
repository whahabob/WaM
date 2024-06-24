using System;
/// <summary>
/// Abstract player class that holds information about the player
/// </summary>
[System.Serializable]
public abstract class Player
{
    public virtual string Name { get; set; }
    public virtual int CurrentHighscore { get; set; }

    public Player(string name)
    {
        this.Name = name;
        this.CurrentHighscore = 0;
    }

    public virtual int GetCurrentScore()
    {
        return CurrentHighscore;
    }
}
