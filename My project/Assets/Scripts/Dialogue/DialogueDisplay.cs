using TMPro;
using UnityEngine;

public class DialogueDisplay : MonoBehaviour
{
    private DialogueWindow dialogueData;

    public GameObject panel;

    bool isDisplaying;

    void Display()
    {
        if (isDisplaying)
        {
            panel.SetActive(true);

            Sprite image = panel.gameObject.transform.Find("Image").GetComponent<Sprite>();
            TMP_Text title = panel.gameObject.transform.Find("Title").GetComponent<TMP_Text>();
            TMP_Text description = panel.gameObject.transform.Find("Description").GetComponent<TMP_Text>();

            image = dialogueData.personImage;
            title.text = dialogueData.dialogueTitle;
            description.text = dialogueData.description;
        }
        else
        {
            panel.SetActive(false);
        }
    }
}
