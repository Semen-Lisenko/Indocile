using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    [SerializeField] private GameObject buildingPrefab; 
    private Building building;
    private GameObject planetCenter;
    private GameObject previewObject;

    private float radius;
    private bool isBuildingActive = false;

    void Start()
    {
        building = GetComponent<Building>();
        planetCenter = building.planetCenter;
        radius = building.radius;

        // Создаем предварительный объект
        previewObject = Instantiate(buildingPrefab, planetCenter.transform);
        SetPreviewObjectColor(Color.green, 0.25f);
        previewObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) // я поменял с ButtonDown("BUILD") на время
        {
            isBuildingActive = !isBuildingActive;
            previewObject.SetActive(isBuildingActive); 
        }

        if (isBuildingActive)
        {
            UpdatePreviewPosition();
            if (Input.GetMouseButtonDown(0))
            {
                Build(buildingPrefab);
            }
        }
    }

    private void UpdatePreviewPosition()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector3 direction = mousePosition - planetCenter.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x);

        float x = planetCenter.transform.position.x + radius * Mathf.Cos(angle);
        float y = planetCenter.transform.position.y + radius * Mathf.Sin(angle);

        previewObject.transform.position = new Vector3(x, y, 0);
    }

    public void Build(GameObject go)
    {
        Instantiate(go, previewObject.transform.position, Quaternion.identity, planetCenter.transform);
    }

    public void SetPreviewObject(GameObject newPrefab)
    {
        Destroy(previewObject);

        previewObject = Instantiate(newPrefab, planetCenter.transform);
        SetPreviewObjectColor(Color.green, 0.25f); 
        previewObject.SetActive(isBuildingActive);
    }

    private void SetPreviewObjectColor(Color color, float alpha)
    {
        color.a = alpha;
        previewObject.GetComponent<SpriteRenderer>().color = color;
    }
}