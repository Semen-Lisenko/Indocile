using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUI : MonoBehaviour
{
    public BuildingSystem buildingSystem; // ссылка на систему строительства
    public List<Button> buildingButtons; // все кнопки

    void Start()
    {
        if (buildingSystem == null) {
            return;
        }

        for (int i = 0; i < buildingButtons.Count; i++) {
            int index = i;
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