using UnityEngine;
using System.Collections;

public class BuildingPanel : MonoBehaviour
{
    public bool isOpened = false;
    public GameObject panel;
    public void Start()
    {
        StartCoroutine(Panel());
    }
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
    public IEnumerator Panel()
    {
        yield return new WaitUntil(() => Input.GetButtonDown("BuildingPanel"));

        OpenPanel();

        yield return new WaitUntil(() => Input.GetButtonUp("BuildingPanel"));
        yield return new WaitUntil(() => Input.GetButtonDown("BuildingPanel"));

        ClosePanel();

        yield return new WaitUntil(() => Input.GetButtonUp("BuildingPanel"));

        StartCoroutine(Panel());
    }
}