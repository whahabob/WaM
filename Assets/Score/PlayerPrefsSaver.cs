using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
public class PlayerPrefsSaver : IUserSaver
{
    private const string PlayersKey = "Players";
    public List<SavedPlayer> GetAllScores()
    {
       return GetPlayersList();
    }

    public void SaveUser()
    {
        throw new System.NotImplementedException();
    }

    public void SavePlayerScore(ActivePlayer player, int score)
    {

        //string playerJson = JsonUtilityHelper.ToJson(player);
       // PlayerPrefs.SetString(GetPlayerKey(player.Name), playerJson);

        // Create a key for the player
        // string playerKey = GetPlayerKey(player.Name);

        // Save the score to PlayerPrefs
        // PlayerPrefs.SetInt(playerKey, player.CurrentHighscore);

        // Add the player to the list of players if not already present
        List<SavedPlayer> players = GetPlayersList();
        bool playerExists = false;
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].Name == player.Name)
            {
                if (players[i].Highscore < score)
                {
                    players[i] = new SavedPlayer(player);
                    players[i].Highscore = score;
                }
                playerExists = true;
                break;
            }
        }
        if (!playerExists)
        {
            SavedPlayer sp = new SavedPlayer(player);
            sp.Highscore = score;
            players.Add(sp);
        }
        SavePlayersList(players);

        // Save the changes to PlayerPrefs
        PlayerPrefs.Save();
    }

    // Get the list of players saved in PlayerPrefs
    public List<SavedPlayer> GetPlayersList()
    {

        string playersJson = PlayerPrefs.GetString(PlayersKey, string.Empty);

        if (string.IsNullOrEmpty(playersJson))
        {
            return new List<SavedPlayer>();
        }

        // Deserialize the JSON string to a list of PlayerData
        List<SavedPlayer> playerDataList = JsonUtilityHelper.FromJson<PlayerDataList>(playersJson).players;
        

        return playerDataList == null? new List<SavedPlayer>() : playerDataList;
    }

    private void SavePlayersList(List<SavedPlayer> players)
    {

        PlayerDataList playerDataList = new PlayerDataList(players);
        playerDataList.players.Sort((p1, p2) => { return p2.Highscore - p1.Highscore; });
        for (int i = 0; i < players.Count; i++)
        {
            playerDataList.players[i].Rank = i + 1;
        }

        string json = JsonUtilityHelper.ToJson(playerDataList);
        PlayerPrefs.SetString(PlayersKey, json);
    }

}

