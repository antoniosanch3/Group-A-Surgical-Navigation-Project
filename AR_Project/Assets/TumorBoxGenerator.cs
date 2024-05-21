using UnityEngine;
using UnityEngine.UI;

public class TumorBoxGenerator : MonoBehaviour
{
    public Dropdown tumorDropdown;
    public Button sphereButton;
    public GameObject[] tumors;
    public GameObject spherePrefab;
    private GameObject[] spheres;
    public Text buttonText;
    public InputField scaleNumberInput;
    private bool pressedStatus = false;

    void Start()
    {
        // Initialize array for spheres
        spheres = new GameObject[tumors.Length];

        // Add listener to call the method when the button is clicked
        sphereButton.onClick.AddListener(GenerateTumorSphere);
    }

    public void GenerateTumorSphere()
    {
        // Destroy existing spheres
        DestroyExistingSpheres();

        int tumorIndex = tumorDropdown.value;

        

        // Check if the selected tumor index is valid
        if (tumorIndex >= 0 && tumorIndex < tumors.Length)
        {
            // Calculate bounding box for the selected tumor
            Bounds bounds = CalculateTumorBounds(tumors[tumorIndex]);

            // Parse the scale value from the input field
            float scaleValue = 0f;
            if (!float.TryParse(scaleNumberInput.text, out scaleValue))
            {
                Debug.LogWarning("Invalid scale value entered. Using default value of 0.");
            }

            // Instantiate the sphere prefab around the selected tumor
            spheres[tumorIndex] = Instantiate(spherePrefab, bounds.center, Quaternion.identity);

            // Adjust the scale of the sphere prefab to match the size of the tumor plus the scale value
            float largestDimension = Mathf.Max(bounds.size.x, bounds.size.y, bounds.size.z);
            float adjustedDimension = largestDimension + scaleValue;
            spheres[tumorIndex].transform.localScale = new Vector3(adjustedDimension, adjustedDimension, adjustedDimension);

            // Set the active state of the sphere
            spheres[tumorIndex].SetActive(pressedStatus);

        }

        
    }

    Bounds CalculateTumorBounds(GameObject tumor)
    {
        Renderer[] renderers = tumor.GetComponentsInChildren<Renderer>();
        Bounds bounds = renderers[0].bounds;
        foreach (Renderer renderer in renderers)
        {
            bounds.Encapsulate(renderer.bounds);
        }
        return bounds;
    }

    public void DestroyExistingSpheres()
    {
        pressedStatus = !pressedStatus;
        spherePrefab.SetActive(pressedStatus);

        // Destroy existing spheres
        foreach (GameObject sphere in spheres)
        {
            if (sphere != null)
            {
                Destroy(sphere);
            }
        }

        UpdateButtonText();
    }

    void UpdateButtonText()
    {
        // Update the button text based on the visibility state
        if (pressedStatus)
        {
            buttonText.text = "Hide sphere";
        }
        else
        {
            buttonText.text = "Show sphere";
        }
    }
}
