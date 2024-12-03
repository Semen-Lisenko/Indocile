using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUI : MonoBehaviour
{
    public BuildingSystem buildingSystem; //Reference to BuildingSystem
    public List<Button> buildingButtons; //Use a list for easier management

    void Start()
    {
        //Remove the old onClick listener - handled by the for loop below
        if (buildingSystem == null) {
            Debug.LogError("BuildingUI: No BuildingSystem assigned!");
            return;
        }

        for (int i = 0; i < buildingButtons.Count; i++) {
            int index = i; //Capture index for lambda expression
            buildingButtons[i].onClick.AddListener(() => SelectBuilding(index));
        }
    }

    void SelectBuilding(int index)
    {
        if(index >= 0 && index < buildingSystem.buildingDatas.Count)
            buildingSystem.SelectBuilding(buildingSystem.buildingDatas[index]);
        else
            Debug.LogError("Invalid building index selected!");
    }
}