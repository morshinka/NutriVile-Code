using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    public enum LandStatus
    {
        Soil, Farmland, Watered,
    }

    public LandStatus landStatus;

    public GameObject select;

    new Renderer renderer;

    public Material soilMat, farmLandMat, wateredMat;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        SwitchLandStatus(LandStatus.Soil);
        select.SetActive(false);
    }

    public void SwitchLandStatus(LandStatus statusToSwitch)
    {
        landStatus = statusToSwitch;
        Material materialToSwitch = soilMat;

        switch (statusToSwitch)
        {
            case LandStatus.Soil: materialToSwitch = soilMat;
            break;
            case LandStatus.Farmland: materialToSwitch = farmLandMat;
            break;
            case LandStatus.Watered: materialToSwitch = wateredMat;
            break;
        }

        renderer.material = materialToSwitch; 
    }

    public void Select(bool toggle)
    {
        select.SetActive(toggle);
    }

    public void Interact()
    {
        SwitchLandStatus(LandStatus.Farmland);
    }
}
