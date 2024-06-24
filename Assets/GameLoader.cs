using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    public static GameSettingsCollection GameSettingsCollection { get; set; }
    public static GameLoader Instance { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
#if !UNITY_EDITOR
 GameSettingsCollection = Resources.Load<GameSettingsCollection>("GameSettingsCollection");
#endif
#if UNITY_EDITOR
            GameSettingsCollection = AssetDatabase.LoadAssetAtPath<GameSettingsCollection>("Assets/Utilities/ScriptableObject/GameSettingsCollection.asset");
           
#endif
            DontDestroyOnLoad(gameObject);


        }
    }

    public static GameSettings GetGameSettings(int position)
    {
        return GameSettingsCollection.GameSettings[position];
    }

}
