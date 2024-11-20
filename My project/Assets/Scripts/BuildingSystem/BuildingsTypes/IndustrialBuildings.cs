using UnityEngine;

public class IndustrialBuildings : Building
{
    public enum IndustryType
    {
        BuildingHoneyFactory,
        EnergyHoneyFactory,
        EatingHoneyFactory
    }

    [System.Serializable]
    public class Level
    {
        public int level;
        public int costToBuild;
        public int productionPer;
    }

    public IndustryType industryType;
    public Level[] levels;
    void Start()
    {
        levels = new Level[3];
        levels[0] = new Level { level = 1, costToBuild = 100, productionPer = 50 };
        levels[1] = new Level { level = 2, costToBuild = 200, productionPer = 100 };
        levels[2] = new Level { level = 3, costToBuild = 300, productionPer = 150 };
    }
}