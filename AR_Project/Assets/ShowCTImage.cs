using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CTImageVisibilityToggle : MonoBehaviour
{
    public GameObject imageCT;
    public Button imageCTButton;
    public Text imageCTText;

    private bool isCTImageVisible = false;

    void Start()
    {
        // Set up the button listener
        imageCTButton.onClick.AddListener(ToggleCTImageVisibility);
        UpdateButtonText();
    }

    void ToggleCTImageVisibility()
    {
        // Toggle the visibility of the CT image
        isCTImageVisible = !isCTImageVisible;
        imageCT.SetActive(isCTImageVisible);
        UpdateButtonText();
    }

    void UpdateButtonText()
    {
        // Update the button text based on the visibility state
        imageCTText.text = isCTImageVisible ? "Hide CT" : "Show CT";
    }
}