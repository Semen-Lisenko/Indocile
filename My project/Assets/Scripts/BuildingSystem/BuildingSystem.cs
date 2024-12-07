using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Unity.Mathematics;
using Unity.Mathematics.Geometry;
using Unity.VisualScripting;

public class BuildingSystem : MonoBehaviour
{
    public GameObject planetCenter;
    public SavingManager savingManager;
    public BuildingUI buildingUI;
    // placed
    public float radius = 3.5f;
    public GameObject buildingMenu;
    public List<BuildingData> buildingDatas;
    private bool buildingPlaced = false;

    public GameObject previewObject;
    private bool isBuildingActive = false;
    private BuildingData selectedBuildingData;

    
    
    public bool isOnPanel = false;

    void Start()
    {
        // HoneyResources.buildingHoney = 100;
        buildingMenu.SetActive(false);
        previewObject.SetActive(false);

        savingManager = GetComponent<SavingManager>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isBuildingActive == false)
        {
            Upgrade();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            savingManager.SaveBuildings();
        }


        if (Input.GetKeyDown(KeyCode.B))
        {
            isBuildingActive = !isBuildingActive;
            buildingMenu.SetActive(isBuildingActive);
            previewObject.SetActive(isBuildingActive);
        }

         if (isBuildingActive && selectedBuildingData != null && !buildingPlaced) // Проверяем флаг
        {
            UpdatePreviewPosition();

            if (Input.GetMouseButtonDown(0))
            {
                PlaceBuilding();
            }
        }
    }

    void Upgrade()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                Building building = hit.collider.GetComponent<Building>();
                if (building != null)
                {
                    // building.OnClick();
                    building.Upgrade();
                    savingManager.SaveBuildings();
                }
                else if (hit.collider.gameObject == buildingMenu.gameObject)
                {
                    isOnPanel = true;
                }
                else
                {
                    isOnPanel = false;
                    Debug.Log("Нет компонента Building");
                }
            }
    }

    void UpdatePreviewPosition()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = planetCenter.transform.position.z;

        Vector3 direction = (mousePosition - planetCenter.transform.position).normalized;
        Vector3 position = planetCenter.transform.position + direction * radius;
        previewObject.transform.position = position;

        Vector3 rotation = previewObject.transform.position - planetCenter.transform.position;
        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        previewObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    void PlaceBuilding()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(previewObject.transform.position, 0.5f);

        bool collisionDetected = false;
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != previewObject && collider.GetComponent<Building>() != null)
            {
                collisionDetected = true;
                break;
            }
        }

        if (!collisionDetected && HoneyResources.buildingHoney - selectedBuildingData.baseCost >= 0 && isOnPanel == false)
        {
            GameObject buildingInstance = Instantiate(selectedBuildingData.prefab, previewObject.transform.position, previewObject.transform.rotation);
            buildingInstance.name = selectedBuildingData.name;
            Building buildingComponent = buildingInstance.GetComponent<Building>();
            buildingComponent.placed = true;

            savingManager.buildingList.Add(buildingComponent);

            Renderer buildingRenderer = buildingInstance.GetComponent<Renderer>();
            if (buildingRenderer != null) buildingRenderer.material.color = Color.white;
            HoneyResources.RemoveBuildingHoney(selectedBuildingData.baseCost);

            buildingPlaced = true; // Устанавливаем флаг в true после установки здания
        }
        Destroy(previewObject);
    }

    public void SelectBuilding(BuildingData buildingData)
    {
        selectedBuildingData = buildingData;
        previewObject = Instantiate(buildingData.prefab, planetCenter.transform);
        previewObject.name = "BuildingPreview";

        Renderer previewRenderer = previewObject.GetComponent<Renderer>();
        if (previewRenderer != null)
        {
            Color color = Color.green;
            color.a = 0.25f;
            previewRenderer.material.color = color;
        }

        buildingPlaced = false; // Сбрасываем флаг при выборе нового здания
    }
}

