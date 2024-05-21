using UnityEngine;
using UnityEngine.UI;

public class MarkerDistanceTracker : MonoBehaviour
{
    public Transform marker;
    public DropdownHandler dropdownHandler;
    public Text positionXText;
    public Button distanceButton;
    private bool isDistanceTextActive = false;

    void Start()
    {
        // Ensure the distance text is initially inactive
        positionXText.gameObject.SetActive(false);

        // Add a listener to the button to call the ToggleDistanceText method when pressed
        distanceButton.onClick.AddListener(ToggleDistanceText);
    }

    void Update()
    {
        if (isDistanceTextActive)
        {
            // Get the active tumor using the public method
            GameObject activeTumor = dropdownHandler.GetActiveTumor();
            if (activeTumor != null)
            {
                // Calculate the distances in x, y, z
                float distanceX = Mathf.Abs(marker.position.x - activeTumor.transform.position.x);
                float distanceY = Mathf.Abs(marker.position.y - activeTumor.transform.position.y);
                float distanceZ = Mathf.Abs(marker.position.z - activeTumor.transform.position.z);

                // Print the distances to the positionXText UI element in the format (X, Y, Z)
                positionXText.text = $"Distance (X, Y, Z): ({distanceX:F2}, {distanceY:F2}, {distanceZ:F2}) units";
            }
        }
    }

    void ToggleDistanceText()
    {
        // Toggle the active state of the distance text
        isDistanceTextActive = !isDistanceTextActive;
        positionXText.gameObject.SetActive(isDistanceTextActive);
    }
}
