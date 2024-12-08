using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class BuildingSaveData
{
    public string buildingName;
    public int level;
    public int income;
    public string sceneName;
    public bool placed;
    public bool isInOtherBuilding;
    public Vector2 position;
    public Quaternion rotation;
    public GameObject prefab;
}


public class Building : MonoBehaviour
{
    public BuildingData buildingData;
    public GameObject panel;
    public int level = 0;
    public string sceneName;
    public int income;
    public bool placed = false;
    public bool isInOtherBuilding = false;

    public bool isOpened = false;
    public bool isCreated = false;

    void Start()
    {
        if (!isCreated)
        {
            income = buildingData.income;
        }
        else
        {

        }
        sceneName = SceneManager.GetActiveScene().name; 

        if (placed)
        {
            switch (buildingData.buildingType)
            {
                case "EnergyHoneyFactory":
                    InvokeRepeating("AddEnergyHoney", 0.0f, 5.0f);
                    break;
                case "EatingHoneyFactory":
                    InvokeRepeating("AddEatingHoney", 0.0f, 5.0f);
                    break;
                case "BuildingHoneyFactory":
                    InvokeRepeating("AddBuildingHoney", 0.0f, 5.0f);
                    break;
            }
        }
    }

    // public void OnClick()
    // {
    //     isOpened = !isOpened;
    //     panel.SetActive(isOpened);
    // }
    public void OnCreated(int income)
    {
        this.income = income;
    }

    void AddEnergyHoney() => HoneyResources.AddEnergyHoney(income);
    void AddEatingHoney() => HoneyResources.AddEatingHoney(income);
    void AddBuildingHoney() => HoneyResources.AddBuildingHoney(income);

    public int GetUpgradeCost()
    {
        if (level < buildingData.upgradeCosts.Length)
        {
            return buildingData.upgradeCosts[level];
        }
        return 0;
    }

    public int GetCost()
    {
        if (level < buildingData.upgradeCosts.Length)
        {
            return buildingData.baseCost + buildingData.upgradeCosts[level];
        }
        return buildingData.baseCost;
    }

    public void Upgrade()
    {
        Debug.Log("Upgraded");
        if (level < buildingData.upgradeCosts.Length)
        {
            level++;
            HoneyResources.RemoveBuildingHoney(GetUpgradeCost());
            income *= 2;
            // spriteRenderer.sprite = buildingData.buildingLevels[level - 1];

        }
    }
}

