using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseBreak : MonoBehaviour
{
    [SerializeField] public GameObject Canvas;
    [SerializeField] public HoneyResources honeyResources;
    [SerializeField] public GameObject InterfaceParent;
    public bool inPauseBreakMenu = false;
    private void OnEnable()
    {
        Canvas.SetActive(false);
        StartCoroutine(MenuExecutor());
    }
    public IEnumerator MenuExecutor()
    {
        yield return new WaitUntil(() => Input.GetButtonDown("PAUSE"));

        Canvas.SetActive(true);
        inPauseBreakMenu = true;
        Time.timeScale = 0;

        yield return new WaitUntil(() => Input.GetButtonUp("PAUSE") || !inPauseBreakMenu);
        yield return new WaitUntil(() => Input.GetButtonDown("PAUSE") || !inPauseBreakMenu);

        Canvas.SetActive(false);
        inPauseBreakMenu = false;
        Time.timeScale = 1;     

        yield return new WaitUntil(() => Input.GetButtonUp("PAUSE") || !inPauseBreakMenu);

        StartCoroutine(MenuExecutor());
    }
    public void Continue()
    {
        inPauseBreakMenu = false;
    }
    public void QuitOutGame()
    {
        honeyResources.UpdateServerRecources();
        Application.Quit();
    }
    public void QuitInMain()
    {
        honeyResources.UpdateServerRecources();
        inPauseBreakMenu = false;
        Canvas.SetActive(false);
        Time.timeScale = 1;
        InterfaceParent.GetComponent<InterfaceContol>().SetOutGame();
        SceneManager.LoadScene("StartScene");
    }
}
