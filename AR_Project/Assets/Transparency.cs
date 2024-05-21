using UnityEngine;
using UnityEngine.UI;

public class TransparencyController : MonoBehaviour
{
    public Slider transparencySlider; 
    public Dropdown tumorDropdown;
    public GameObject tumorPatient1;
    public GameObject tumorPatient2;
    public GameObject tumorPatient3;
    private Renderer[] targetRenderers;
    private Material[] targetMaterials;

    public void Start()
    {
        // Initialize arrays for renderers and materials
        targetRenderers = new Renderer[3];
        targetMaterials = new Material[3];

        targetRenderers[0] = tumorPatient1.GetComponent<Renderer>();
        targetRenderers[1] = tumorPatient2.GetComponent<Renderer>();
        targetRenderers[2] = tumorPatient3.GetComponent<Renderer>();

        for (int i = 0; i < targetRenderers.Length; i++)
        {
            // Ensure the material uses a shader that supports transparency
            targetMaterials[i] = targetRenderers[i].material;
            targetMaterials[i].SetFloat("_Mode", 3); 
            targetMaterials[i].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            targetMaterials[i].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            targetMaterials[i].SetInt("_ZWrite", 0);
            targetMaterials[i].DisableKeyword("_ALPHATEST_ON");
            targetMaterials[i].EnableKeyword("_ALPHABLEND_ON");
            targetMaterials[i].DisableKeyword("_ALPHAPREMULTIPLY_ON");
            targetMaterials[i].renderQueue = 3000;
        }

        if (transparencySlider != null)
        {
            // Add listener to call the method when the slider value changes
            transparencySlider.onValueChanged.AddListener(UpdateTransparency);
        }

        if (tumorDropdown != null)
        {
            // Add listener to call the method when the dropdown value changes
            tumorDropdown.onValueChanged.AddListener(UpdateTargetRenderer);
        }
    }

    public void UpdateTransparency(float value)
    {
        // Update transparency for the currently selected tumor
        int selectedTumorIndex = tumorDropdown.value;
        if (selectedTumorIndex >= 0 && selectedTumorIndex < targetMaterials.Length)
        {
            Color color = targetMaterials[selectedTumorIndex].color;
            color.a = value;
            targetMaterials[selectedTumorIndex].color = color;
        }
    }

    public void UpdateTargetRenderer(int tumorIndex)
    {
        // Update target renderer and material based on the selected tumor
        if (tumorIndex >= 0 && tumorIndex < targetRenderers.Length)
        {
            // Ensure the material uses a shader that supports transparency
            targetMaterials[tumorIndex].SetFloat("_Mode", 3);  // Transparent mode
            targetMaterials[tumorIndex].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            targetMaterials[tumorIndex].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            targetMaterials[tumorIndex].SetInt("_ZWrite", 0);
            targetMaterials[tumorIndex].DisableKeyword("_ALPHATEST_ON");
            targetMaterials[tumorIndex].EnableKeyword("_ALPHABLEND_ON");
            targetMaterials[tumorIndex].DisableKeyword("_ALPHAPREMULTIPLY_ON");
            targetMaterials[tumorIndex].renderQueue = 3000;
        }
    }
}
