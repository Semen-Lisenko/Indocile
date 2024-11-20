using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    private Building building;
    private GameObject planetCenter;
    private float radius;
    public GameObject buildingPrefab;
    private GameObject previewObject;
    private bool isBuildingActive = false;

    void Start()
    {
        building = GetComponent<Building>();
        planetCenter = building.planetCenter;
        radius = building.radius;

        previewObject = Instantiate(buildingPrefab, planetCenter.transform);
        Color color = Color.green;
        color.a = 0.25f;
        previewObject.GetComponent<SpriteRenderer>().color = color;
        previewObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            isBuildingActive = !isBuildingActive;
            previewObject.SetActive(isBuildingActive); 
        }

        if (isBuildingActive)
        {
            Build();
        }
    }

    public void Build()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector3 direction = mousePosition - planetCenter.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x);

        float x = planetCenter.transform.position.x + radius * Mathf.Cos(angle);
        float y = planetCenter.transform.position.y + radius * Mathf.Sin(angle);

        previewObject.transform.position = new Vector3(x, y, 0);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(buildingPrefab, previewObject.transform.position, Quaternion.identity, planetCenter.transform);
        }
    }
}