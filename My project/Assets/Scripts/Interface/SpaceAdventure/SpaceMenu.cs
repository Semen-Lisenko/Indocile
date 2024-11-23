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
    public bool inAdventure = false;

    public void Clear()
    {
        SelectedPlanetScene = "";
    }
    public void OnEnable()
    {
        DeselectOther += Clear;
        Canvas.SetActive(false);
        StartCoroutine(MenuExecutor());
    }
    public IEnumerator MenuExecutor()
    {
        yield return new WaitUntil(() => Input.GetButtonDown("MAP"));

        Canvas.SetActive(true);

        yield return new WaitUntil(() => Input.GetButtonUp("MAP") || inAdventure);
        yield return new WaitUntil(() => Input.GetButtonDown("MAP") || inAdventure);

        Canvas.SetActive(false);

        yield return new WaitUntil(() => Input.GetButtonUp("MAP") || inAdventure);

        inAdventure = false;
        StartCoroutine(MenuExecutor());
    }
    public void InvokeCoroutineCP()
    {
        StartCoroutine(ChangePlanet());
    }
    public IEnumerator ChangePlanet()
    {
        if (Equals(SelectedPlanetScene, "") || Equals(SceneManager.GetActiveScene().name, SelectedPlanetScene))
        {
            yield break;
        }
        inAdventure = true;
        AdventureLoadScreen.SetActive(true);
        yield return new WaitForSeconds(ALSTimeOffset);

        SceneManager.LoadScene(SelectedPlanetScene);
        Canvas.SetActive(false);

        yield return new WaitForSeconds(ALSTime - ALSTimeOffset);

        AdventureLoadScreen.SetActive(false);
        inAdventure = false;
        yield break;
    }
}
