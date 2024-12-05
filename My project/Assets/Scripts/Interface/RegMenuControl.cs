using System.Collections;
using UnityEngine;

public class RegMenuControl : MonoBehaviour
{
    public GameObject regCanvas;
    public MainMenu mainMenu;
    public IEnumerator InvokeRegCanvas()
    {
        regCanvas.SetActive(true);
        yield return new WaitUntil(() => PlayerPrefs.GetString("LastUsername") != "");
        regCanvas.SetActive(false);
        mainMenu.ContinueGame();
    }
}
