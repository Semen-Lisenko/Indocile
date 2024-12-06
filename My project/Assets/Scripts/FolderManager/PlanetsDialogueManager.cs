using UnityEngine;
using UnityEngine.UI; // Не забудьте добавить этот using для работы с UI
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class PlanetsDialogueManager : MonoBehaviour
{
    public DialogueDisplay dialogueDisplay;
    public GameObject panelObject;
    public List<DialogueWindow> dialogueWindows;

    void Start()
    {
        panelObject.SetActive(false);

        string sceneName = SceneManager.GetActiveScene().name;
        int planetIndex = int.Parse(sceneName.Substring(sceneName.Length - 1)) - 1; // Предполагается, что название сцены имеет формат "PlanetX"

        if (planetIndex >= 0 && planetIndex < dialogueWindows.Count && !dialogueWindows[planetIndex].wasOnPlanet)
        {
            Display(dialogueWindows[planetIndex]);
            dialogueWindows[planetIndex].wasOnPlanet = true;
        }
    }

    public void Display(DialogueWindow dialogueData)
    {
        Image image = panelObject.transform.Find("Image").GetComponent<Image>(); // Изменено на Image
        TMP_Text title = panelObject.transform.Find("Title").GetComponent<TMP_Text>();
        TMP_Text description = panelObject.transform.Find("Description").GetComponent<TMP_Text>();

        image.sprite = dialogueData.personImage; // Установите спрайт
        title.text = dialogueData.dialogueTitle;
        description.text = dialogueData.description;

        Debug.Log("Activating panel");
        panelObject.gameObject.SetActive(true);
        Debug.Log("Panel active: " + panelObject.activeSelf);
    }

    void Update()
    {
        Debug.Log(dialogueWindows[0].wasOnPlanet);
    }
}
