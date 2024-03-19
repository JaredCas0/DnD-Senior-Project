using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyPreview : MonoBehaviour
{
    public GameObject[] villageEnemies; // Assign village enemy token GameObjects in the Unity Editor
    public GameObject[] dungeonEnemies; // Assign dungeon enemy token GameObjects in the Unity Editor
    public GameObject[] forestEnemies; // Assign forest enemy token GameObjects in the Unity Editor
    
    public TMP_Dropdown difficultyDropdown;
    public GameObject villageButton; // Reference to the village map button
    public GameObject dungeonButton; // Reference to the dungeon map button
    public GameObject forestButton; // Reference to the forest map button

    private void Start()
    {
        // Hide all enemy tokens initially
        HideAllEnemies();

        // Set up listeners for the difficulty dropdown value changed event
        difficultyDropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged();
        });

        // Set up listeners for the map buttons
        villageButton.GetComponent<Button>().onClick.AddListener(() => SelectMap(MapSelection.Village));
        dungeonButton.GetComponent<Button>().onClick.AddListener(() => SelectMap(MapSelection.Dungeon));
        forestButton.GetComponent<Button>().onClick.AddListener(() => SelectMap(MapSelection.Forest));


        // Call initial methods to set up default map and difficulty
        SelectMap(MapSelection.Village);
        DropdownValueChanged();
    }

    private enum MapSelection
    {
        Village,
        Dungeon,
        Forest
    }

    private MapSelection currentMapSelection = MapSelection.Village; // Default map selection

    void SelectMap(MapSelection map)
    {
        currentMapSelection = map;
        DropdownValueChanged();
    }

    void DropdownValueChanged()
    {
        Debug.Log("Dropdown value changed: " + difficultyDropdown.value);

        // Hide all enemy tokens initially
        HideAllEnemies();

        // Show enemies based on map selection
        // switch (currentMapSelection)
        // {
        //     case MapSelection.Village:
        //         ShowEnemies(villageEnemies);
        //         break;
        //     case MapSelection.Dungeon:
        //         ShowEnemies(dungeonEnemies);
        //         break;
        // }

        // Update enemies based on difficulty
        UpdateEnemiesBasedOnDifficulty(difficultyDropdown.value);
    }



    void UpdateEnemiesBasedOnDifficulty(int difficultyValue)
    {
        switch (difficultyValue)
        {
            case 0: // Normal
                ShowNormalDifficultyEnemies();
                break;
            case 1: // Hard
                ShowHardDifficultyEnemies();
                break;
            case 2: // Deadly
                ShowDeadlyDifficultyEnemies();
                break;
        }
    }

    // Show enemies for Normal difficulty
    void ShowNormalDifficultyEnemies()
    {
        switch (currentMapSelection)
        {
            case MapSelection.Village:
                ShowEnemies(new GameObject[] { villageEnemies[0] }); // Show Goblin for Village map
                break;
            case MapSelection.Dungeon:
                ShowEnemies(new GameObject[] { dungeonEnemies[0], dungeonEnemies[1] }); // Show Kobold and Skeleton for Dungeon map
                break;
            case MapSelection.Forest:
                ShowEnemies(new GameObject[] { forestEnemies[0], forestEnemies[1] }); // Show lizardfolk and brown bear for forest map
                break;
        }
    }

    // Show enemies for Hard difficulty
    void ShowHardDifficultyEnemies()
    {
        switch (currentMapSelection)
        {
            case MapSelection.Village:
                ShowEnemies(new GameObject[] { villageEnemies[0], villageEnemies[1], villageEnemies[2] }); // Show Goblin, Bandit, and Orc for Village map
                break;
            case MapSelection.Dungeon:
                ShowEnemies(new GameObject[] { dungeonEnemies[0], dungeonEnemies[1], dungeonEnemies[2], dungeonEnemies[3] }); // Show Kobold, Skeleton, Zombie, and Gray Ooze for Dungeon map
                break;
            case MapSelection.Forest:
                ShowEnemies(new GameObject[] { forestEnemies[0], forestEnemies[1], forestEnemies[2], forestEnemies[3] }); // Show lizardfolk, brown bear, dire wolf, and druid for forest map
                break;
        }
    }

    // Show enemies for Deadly difficulty
    void ShowDeadlyDifficultyEnemies()
    {
        switch (currentMapSelection)
        {
            case MapSelection.Village:
                ShowEnemies(new GameObject[] { villageEnemies[0], villageEnemies[1], villageEnemies[2], villageEnemies[3], villageEnemies[4] }); // Show Goblin, Bandit, Orc, Bandit Captain, and Orc War Chief for Village map
                break;
            case MapSelection.Dungeon:
                ShowEnemies(new GameObject[] { dungeonEnemies[0], dungeonEnemies[1], dungeonEnemies[2], dungeonEnemies[3], dungeonEnemies[4] }); // Show Kobold, Skeleton, Zombie, Gray Ooze, and Lich for Dungeon map
                break;
            case MapSelection.Forest:
                ShowEnemies(new GameObject[] { forestEnemies[0], forestEnemies[1], forestEnemies[2], forestEnemies[3], forestEnemies[4] }); // Show lizardfolk, brown bear, dire wolf, druid, and hill giant for forest map
                break;
        }
    }

    // Hide all enemy tokens
    void HideAllEnemies()
    {
        foreach (GameObject enemy in villageEnemies)
        {
            enemy.SetActive(false);
        }

        foreach (GameObject enemy in dungeonEnemies)
        {
            enemy.SetActive(false);
        }

        foreach (GameObject enemy in forestEnemies)
        {
            enemy.SetActive(false);
        }
    }

    // Show specified enemy tokens based on the selected map
    void ShowEnemies(GameObject[] enemies)
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(true);
        }
    }
}
