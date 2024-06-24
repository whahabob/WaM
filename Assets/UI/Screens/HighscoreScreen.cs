using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreScreen : WaMScreen
{
   [SerializeField] private List<UIComponent> components = new List<UIComponent>();
    public override List<UIComponent> Children { get => components; set => components = value; }

    private PlayerPrefsSaver prefsSaver;

    public GameObject textPrefab; // Assign the Text prefab in the Inspector
    public Transform contentPanel; // Assign the Content panel of the ScrollView in the Inspector


    void Start()
    {
        prefsSaver = new PlayerPrefsSaver();
        RegisterScreen();
        PopulatePlayerList();
        Hide();
        
    }

    private void PopulatePlayerList()
    {
        // Get the list of players
        List<SavedPlayer> players = prefsSaver.GetPlayersList();

        // Clear existing entries
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }

        // Create a Text element for each player and add it to the Content panel
        foreach (SavedPlayer player in players)
        {
            GameObject newText = Instantiate(textPrefab, contentPanel);
            UITMP_Text textComponent = newText.GetComponent<UITMP_Text>();
            textComponent.SetText($"{player.Rank}  |{player.Name}:{player.Highscore}");
        }
    }

    public override void Show()
    {
        base.Show();
        PopulatePlayerList();
    }
}