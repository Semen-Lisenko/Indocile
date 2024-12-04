using UnityEngine;

[CreateAssetMenu(fileName = "BuildingData", menuName = "Building Data")]
public class BuildingData : ScriptableObject
{
    public string buildingName;
    public GameObject prefab;
    public string buildingType;
    public int baseCost;
    public int income;
    public int[] upgradeCosts;
}
