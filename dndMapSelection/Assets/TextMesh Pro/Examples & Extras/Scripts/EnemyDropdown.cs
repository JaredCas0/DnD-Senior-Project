using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class EnemyDropdown : MonoBehaviour
{
    public TMP_Dropdown dropdown; // TMP_Dropdown for the difficulty levels
    public Transform tokenParent;
    public GameObject[] enemyTokenPrefabs; // Array to hold the prefabs for enemy tokens

    private List<GameObject> displayedTokens = new List<GameObject>(); // List to keep track of displayed tokens

    void Start()
    {
        // Subscribe to the OnValueChanged event of the dropdown
        // dropdown.onValueChanged.AddListener(delegate {
        //     OnDropdownValueChanged(dropdown);
        // });
    }

    void OnDropdownValueChanged(string optionText)
    {
        // Clear existing tokens
        foreach (GameObject token in displayedTokens)
        {
            Destroy(token);
        }
        displayedTokens.Clear();

        // Find the index of the selected option in the dropdown options
        int index = dropdown.options.FindIndex(option => option.text == optionText);

        // Display enemy tokens based on the selected difficulty level
        for (int i = 0; i <= index; i++)
        {
            if (i < enemyTokenPrefabs.Length)
            {
                GameObject enemyTokenPrefab = enemyTokenPrefabs[i];
                GameObject enemyToken = Instantiate(enemyTokenPrefab, tokenParent);
                displayedTokens.Add(enemyToken);
            }
        }
    }
}
