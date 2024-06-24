using System;
/// <summary>
/// 
/// </summary>
[System.Serializable]
public class SavedPlayer : ActivePlayer, IComparable<SavedPlayer>
{
    public int Rank;
    public string Name;
    public int Highscore;
    public SavedPlayer(ActivePlayer player) : base(player.Name)
    {
        Name = player.Name;
        Highscore = player.CurrentHighscore;
    }

    public int CompareTo(SavedPlayer playerToCompare)
    {
        SavedPlayer thisPlayer = this;
        if (thisPlayer.CurrentHighscore < playerToCompare.CurrentHighscore)
        {
            return -1;
        }

        if (thisPlayer.CurrentHighscore > playerToCompare.CurrentHighscore)
        {
            return 1;
        }

        return 0;
    }
}