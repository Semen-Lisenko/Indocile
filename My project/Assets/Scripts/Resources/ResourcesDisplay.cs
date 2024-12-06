using TMPro;
using UnityEngine;

public class ResourcesDisplay : MonoBehaviour
{
    public TMP_Text energyHoney;
    public TMP_Text buildingHoney;
    public TMP_Text eatingHoney;
    void Start()
    {
        InvokeRepeating("Change", 0.0f, 1.0f);
    }

    void Change()
    {
        energyHoney.text = HoneyResources.energyHoney.ToString();
        buildingHoney.text = HoneyResources.buildingHoney.ToString();
        eatingHoney.text = HoneyResources.eatingHoney.ToString();
    }
    void Update()
    {
        
    }
}
