using NUnit.Framework;
using System.Collections.Generic;
/// <summary>
/// Interface that can be implemented to save users
/// </summary>
public interface IUserSaver
{
    void SaveUser();
    List<SavedPlayer> GetAllScores();
    void SavePlayerScore(ActivePlayer player, int score);
}
