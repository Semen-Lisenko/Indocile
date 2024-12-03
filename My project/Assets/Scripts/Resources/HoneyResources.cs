using UnityEngine;

public class HoneyResources : MonoBehaviour
{
    [SerializeField]
    public static int energyHoney {get; set;}
    public static int eatingHoney {get; set;}
    public static int buildingHoney {get; set;}


    void Update()
    {
    }

    public static void AddEnergyHoney(int amount)
    {
        energyHoney += amount;
        Debug.Log(amount);
    }
    public static void AddEatingHoney(int amount)
    {
        eatingHoney += amount;
    }
    public static void AddBuildingHoney(int amount)
    {
        buildingHoney += amount;
    }

    public static void RemoveEnergyHoney(int amount)
    {
        if (energyHoney > 0)
        {
            energyHoney -= amount;
        }
    }
    public static void RemoveEatingHoney(int amount)
    {
        if (eatingHoney > 0)
        {
            eatingHoney -= amount;
        }
    }
    public static void RemoveBuildingHoney(int amount)
    {
        if (buildingHoney > 0)
        {
            buildingHoney -= amount;
        }
    }
}
