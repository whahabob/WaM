using System.Collections.Generic;
/// <summary>
/// Create class so that we can Convert it from Json to string and visa versa
/// </summary>
[System.Serializable]
public class PlayerDataList
{
    public List<SavedPlayer> players;

    public PlayerDataList(List<SavedPlayer> players)
    {
        this.players = players;
    }
}