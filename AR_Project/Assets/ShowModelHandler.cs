using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisibilityToggleHandler : MonoBehaviour
{
    public GameObject pelvisBone;
    public Button pelvisButton;
    public Text buttonText;

    private bool isVisible = false;

    void Start()
    {
        // Set up the button listener
        pelvisButton.onClick.AddListener(ToggleVisibility);
        UpdateButtonText();
    }

    void ToggleVisibility()
    {
        // Toggle the visibility of the pelvis bone
        isVisible = !isVisible;
        pelvisBone.SetActive(isVisible);
        UpdateButtonText();
    }

    void UpdateButtonText()
    {
        // Update the button text based on the visibility state
        if (isVisible)
        {
            buttonText.text = "Hide model";
        }
        else
        {
            buttonText.text = "Show model";
        }
    }
}