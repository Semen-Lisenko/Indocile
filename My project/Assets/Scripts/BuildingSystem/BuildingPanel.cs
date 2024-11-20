using UnityEngine;

public class BuildingPanel : MonoBehaviour
{
    public bool isOpened = false;
    public GameObject panel;
    public void OpenPanel()
    {
        panel.SetActive(true);
        isOpened = true;
    }
    public void ClosePanel()
    {
        panel.SetActive(false);
        isOpened = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isOpened)
            {
                ClosePanel();
            }
            else
            {
                OpenPanel();
            }
        }
    }
}