using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SavingManager : MonoBehaviour
{
    private string saveFilePath;
    public List<Building> buildingList = new List<Building>();

     public void Start()
    {
        string fileName = SceneManager.GetActiveScene().name;
        saveFilePath = Path.Combine(Application.streamingAssetsPath, fileName + ".json");
        LoadBuildings();
    }

    public void SaveBuildings()
    {
        List<BuildingSaveData> saveDataList = new List<BuildingSaveData>();

        foreach (var building in buildingList)
        {
            BuildingSaveData data = new BuildingSaveData
            {
                buildingName = building.buildingData.buildingName,
                income = building.income,
                position = building.gameObject.transform.position,
                rotation = building.gameObject.transform.rotation,
                prefab = building.buildingData.prefab,
                level = building.level,
                placed = building.placed,
                isInOtherBuilding = building.isInOtherBuilding
            };
            saveDataList.Add(data);
        }

        string json = JsonUtility.ToJson(new Serialization<BuildingSaveData>(saveDataList));
        File.WriteAllText(saveFilePath, json);
        Debug.Log("Buildings saved to " + saveFilePath);
    }

    public List<Building> LoadBuildings()
    {
        if (!File.Exists(saveFilePath))
        {
            Debug.LogWarning("Save file not found!");
            return new List<Building>();
        }

        string json = File.ReadAllText(saveFilePath);
        Serialization<BuildingSaveData> data = JsonUtility.FromJson<Serialization<BuildingSaveData>>(json);
        List<Building> buildings = new List<Building>();
        if(data.items.Count == 0)
        {
            return new List<Building>();
        }
        foreach (var buildingData in data.items)
        {
            Building building = CreateBuilding(buildingData);
            buildings.Add(building);
        }

        return buildings;
    }

    private Building CreateBuilding(BuildingSaveData data)
    {
        GameObject buildingObject = Instantiate(data.prefab);
        Building building = buildingObject.GetComponent<Building>();
        building.level = data.level;
        building.income = data.income;
        building.placed = data.placed;
        building.transform.position = data.position;
        building.transform.rotation = data.rotation;
        building.isInOtherBuilding = data.isInOtherBuilding;
        building.isCreated = true;

        buildingList.Add(building);
        return building;
    }
}

[System.Serializable]
public class Serialization<T>
{
    public List<T> items;

    public Serialization(List<T> items)
    {
        this.items = items;
    }
}
