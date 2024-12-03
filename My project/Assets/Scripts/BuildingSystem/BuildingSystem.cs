using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class BuildingSystem : MonoBehaviour
{
    public GameObject planetCenter;
    public BuildingUI buildingUI;
    // placed
    public float radius = 4.5f;
    public GameObject buildingMenu;
    public List<BuildingData> buildingDatas;
    public GameObject buildingPrefab;

    public GameObject previewObject;
    private bool isBuildingActive = false;
    private BuildingData selectedBuildingData;

    void Start()
    {
        buildingMenu.SetActive(false);
        previewObject.SetActive(false);

        HoneyResources.AddBuildingHoney(1000);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isBuildingActive == false)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                Building building = hit.collider.GetComponent<Building>();
                if (building != null)
                {
                    building.Upgrade();
                }
                else
                {
                    Debug.Log("Нет компонента Building");
                }
            }
        }


        if (Input.GetKeyDown(KeyCode.B))
        {
            isBuildingActive = !isBuildingActive;
            buildingMenu.SetActive(isBuildingActive);
            previewObject.SetActive(isBuildingActive);
        }

        if (isBuildingActive && selectedBuildingData != null)
        {
            UpdatePreviewPosition();

            if (Input.GetMouseButtonDown(0))
            {
                PlaceBuilding();
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
    }

    public void SelectBuilding(BuildingData buildingData)
    {
        selectedBuildingData = buildingData;
        previewObject = Instantiate(buildingPrefab, planetCenter.transform);
        previewObject.name = "BuildingPreview";

        Renderer previewRenderer = previewObject.GetComponent<Renderer>();
        if (previewRenderer != null)
        {
            Color color = Color.green;
            color.a = 0.25f;
            previewRenderer.material.color = color;
        }
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

        if (!collisionDetected && HoneyResources.buildingHoney - selectedBuildingData.baseCost > 0)
        {
            GameObject buildingInstance = Instantiate(selectedBuildingData.prefab, previewObject.transform.position, Quaternion.identity);
            buildingInstance.name = "Building";
            buildingInstance.GetComponent<Building>().placed = true;
            Renderer buildingRenderer = buildingInstance.GetComponent<Renderer>();
            if (buildingRenderer != null) buildingRenderer.material.color = Color.white;
        }
    }
}
