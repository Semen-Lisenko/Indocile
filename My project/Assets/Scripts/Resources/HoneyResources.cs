using System.Collections;
using UnityEngine;

public class HoneyResources : MonoBehaviour
{
    public static int energyHoney {get; set;}
    public static int eatingHoney {get; set;}
    public static int buildingHoney  {get; set;}


    public RequestAPI _RequestAPI;
    public void Start()
    {
        if (PlayerPrefs.GetString("LastUsername") != "")
        {
            User user = new User();
            user.name = PlayerPrefs.GetString("LastUsername");
            StartCoroutine(_RequestAPI.GetPlayerResourcesCorutine(user, LoadResources));
        }
        StartCoroutine(UpdateServerResources());
    }

    void Update()
    {
    }
    public void LoadResources(User user)
    {
        buildingHoney = user.resources.buildHoney;
        energyHoney = user.resources.energyHoney;
        eatingHoney = user.resources.eatHoney;
    }
    public static void AddEnergyHoney(int amount)
    {
        energyHoney += amount;
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
    public IEnumerator UpdateServerResources()
    {
        if(PlayerPrefs.GetString("LastUsername") != "")
        {
            User user = new User();
            user.name = PlayerPrefs.GetString("LastUsername");
            user.password = PlayerPrefs.GetString("LastPassword");
            user.resources.eatHoney = eatingHoney;
            user.resources.buildHoney = buildingHoney;
            user.resources.energyHoney = energyHoney;
            Debug.Log(user.name);
            StartCoroutine(_RequestAPI.PutPlayerResourcesCorutine(user));
        }
        yield return new WaitForSecondsRealtime(180f);
        StartCoroutine(UpdateServerResources());
    }
}
