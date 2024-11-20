using Unity.VisualScripting;
using UnityEngine;

public class SelectBuilding : MonoBehaviour
{
    private IndustrialBuildings industrialBuildings;
    void Start()
    {
        industrialBuildings = GetComponent<IndustrialBuildings>();
        if (industrialBuildings != null) // также потом проработать с другими типами зданий
        {
            
        }
        else
        {

        }
    }

    public void OnClick()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 3 ; j++)
            {
                if (industrialBuildings.levels[i].level == j) // реализация выбора объекта (недоделанная)
                {

                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
