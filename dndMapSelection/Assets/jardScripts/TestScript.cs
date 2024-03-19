using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class TestScript : MonoBehaviour
{
    [SerializeField] private ConfirmationWindow myConfirmationWindow;
    public GameObject villagePreview;
    public GameObject dungeonPreview;
    public GameObject forestPreview;

    // Start is called before the first frame update
    void Start()
    {
        // Assuming VillagePreview, DungeonPreview, and ForestPreview are already assigned in the Unity Editor
        myConfirmationWindow.battleButton.onClick.AddListener(OpenConfirmationWindow);
    }

    private void OpenConfirmationWindow()
    {
        // Set confirmation window to active
        myConfirmationWindow.gameObject.SetActive(true);

        // Add listeners for yes and no buttons
        myConfirmationWindow.yesButton.onClick.AddListener(YesClicked);
        myConfirmationWindow.noButton.onClick.AddListener(NoClicked);

        // Set message in confirmation window
        myConfirmationWindow.messageText.text = "Are you sure?";
    }

    private void YesClicked()
    {
        // Determine which map is currently selected
        string currentMapScene = GetCurrentMapScene();

        // Load the scene corresponding to the current map selected
        SceneManager.LoadScene(currentMapScene);
    }

    private void NoClicked()
    {
        // Hide confirmation window
        myConfirmationWindow.gameObject.SetActive(false);
        Debug.Log("No clicked");
    }

    // Method to get the name of the scene corresponding to the current map selected
    private string GetCurrentMapScene()
    {
        if (villagePreview.activeSelf)
        {
            return "VillageScene"; // Assuming "VillageScene" is the scene name for the village map
        }
        else if (dungeonPreview.activeSelf)
        {
            return "DungeonScene"; // Assuming "DungeonScene" is the scene name for the dungeon map
        }
        else if (forestPreview.activeSelf)
        {
            return "ForestScene"; // Assuming "ForestScene" is the scene name for the forest map
        }
        else
        {
            // Default scene name or handle other cases
            return "DefaultScene";
        }
    }
}
