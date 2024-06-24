using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettingsCollection", menuName = "ScriptableObjects/GameSettingsCollection", order = 1)]
[Serializable]
public class GameSettingsCollection : ScriptableObject
{
    public GameSettings[] GameSettings;
}