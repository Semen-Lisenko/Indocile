using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceMenu : MonoBehaviour
{
    public static Action DeselectOther;
    public static string SelectedPlanetScene = "";

    [SerializeField] public GameObject Canvas;
    [SerializeField] public GameObject AdventureLoadScreen;
    [SerializeField] public float ALSTime;
    [SerializeField] public float ALSTimeOffset;
    public bool inGame = true;
    public void Clear()
    {
        SelectedPlanetScene = "";
    }
    public void Start()
    {
        DeselectOther += Clear;
        Canvas.SetActive(false);
        DontDestroyOnLoad(this);
        StartCoroutine(MenuExecutor());
    }
    public IEnumerator MenuExecutor()
    {
        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => Input.GetButtonDown("MAP") && inGame);

        Canvas.SetActive(true);

        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => Input.GetButtonDown("MAP") || !inGame);

        Canvas.SetActive(false);
        StartCoroutine(MenuExecutor());
    }
    public void InvokeCoroutineCP()
    {
        StartCoroutine(ChangePlanet());
    }
    public IEnumerator ChangePlanet()
    {
        if (Equals(SelectedPlanetScene, ""))
        {
            yield break;
        }
        AdventureLoadScreen.SetActive(true);
        yield return new WaitForSeconds(ALSTimeOffset);
        Canvas.SetActive(false);
        SceneManager.LoadScene(SelectedPlanetScene);
        yield return new WaitForSeconds(ALSTime - ALSTimeOffset);
        AdventureLoadScreen.SetActive(false);
        yield break;
    }
}
