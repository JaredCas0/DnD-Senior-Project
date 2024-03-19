using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    private TextMeshProUGUI buttonText;
    private Color normalColor;
    private bool isSelected = false;
    public Color hoverColor = Color.yellow; // Color when hovering
    public Color selectedColor = Color.yellow; // Color when selected

    void Start()
    {
        // Get the TextMeshProUGUI component of the button
        buttonText = GetComponentInChildren<TextMeshProUGUI>();

        // Save the normal color of the text
        if (buttonText != null)
        {
            normalColor = buttonText.color;
        }
    }

    // Called when the pointer enters the button area
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Change the text color to the hover color if buttonText is not null and button is not selected
        if (buttonText != null && !isSelected)
        {
            buttonText.color = hoverColor;
        }
    }

    // Called when the pointer exits the button area
    public void OnPointerExit(PointerEventData eventData)
    {
        // Change the text color back to the normal color if buttonText is not null and button is not selected
        if (buttonText != null && !isSelected)
        {
            buttonText.color = normalColor;
        }
    }

    // Called when the button is selected
    public void OnSelect(BaseEventData eventData)
    {
        // Change the text color to selected color and set isSelected to true
        if (buttonText != null)
        {
            buttonText.color = selectedColor;
            isSelected = true;
        }
    }

    // Called when the button is deselected
    public void OnDeselect(BaseEventData eventData)
    {
        // Change the text color back to normal color and set isSelected to false
        if (buttonText != null)
        {
            buttonText.color = normalColor;
            isSelected = false;
        }
    }
}
