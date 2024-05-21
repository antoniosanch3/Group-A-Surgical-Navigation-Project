using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour
{
    public Dropdown dropdown;
    public GameObject pelvisBone;
    public GameObject tumorPatient1;
    public GameObject tumorPatient2;
    public GameObject tumorPatient3;

    private Dictionary<int, GameObject> patientTumors;

    void Start()
    {
        // Initialize the dictionary with the tumor models
        patientTumors = new Dictionary<int, GameObject>
        {
            { 0, tumorPatient1 },
            { 1, tumorPatient2 },
            { 2, tumorPatient3 }
        };

        // Add listener to handle dropdown value change
        dropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(dropdown); });

        // Set the dropdown default value to "Select Patient"
        dropdown.value = 0;

        HideAllTumors();
        patientTumors[dropdown.value].SetActive(true);
    }

    void DropdownValueChanged(Dropdown change)
    {
        HideAllTumors();
        if (patientTumors.ContainsKey(change.value))
        {
            patientTumors[change.value].SetActive(true);
        }
    }

    void HideAllTumors()
    {
        foreach (var tumor in patientTumors.Values)
        {
            tumor.SetActive(false);
        }
    }

    // Public method to get the active tumor based on dropdown value
    public GameObject GetActiveTumor()
    {
        if (patientTumors.ContainsKey(dropdown.value))
        {
            return patientTumors[dropdown.value];
        }
        return null;
    }
}
