using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Building : MonoBehaviour
{
    public BuildingData buildingData;
    public int level = 0;
    public bool placed = false;
    public bool isInOtherBuilding = false;

    void Start()
    {
        if (placed == true)
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
    void AddEnergyHoney()
    {
        Debug.Log("5");
        int amount = buildingData.income;
        HoneyResources.AddEnergyHoney(amount);
    }
    void AddEatingHoney()
    {
        int amount = buildingData.income;
        HoneyResources.AddEatingHoney(amount);
    }
    void AddBuildingHoney()
    {
        int amount = buildingData.income;
        Debug.Log(amount);
        HoneyResources.AddBuildingHoney(amount);
    }


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
        if (level < buildingData.upgradeCosts.Length)
        {
            level++;
            HoneyResources.RemoveBuildingHoney(GetUpgradeCost());
            buildingData.income = buildingData.income * 2;
        }
    }
}

