using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] public GameObject SettingsCanvas;
    [SerializeField] public GameObject InterfaceParent;
    [SerializeField] public GameObject regCanvas;
    [SerializeField] public RegMenuControl regMenu;
    [SerializeField] public Button ContinueButton;

    public void OnEnable()
    {
        ContinueButton.enabled = PlayerPrefs.GetInt("FirstPlay") != 0;
    }
    public void StartNewGame()
    {
        PlayerPrefs.SetInt("FirstPlay", 1);
        PlayerPrefs.SetString("LastUsername", "");
        PlayerPrefs.SetString("QuitScene", "planet1");
        if(PlayerPrefs.GetString("LastUsername") == "")
        {
            StartCoroutine(regMenu.InvokeRegCanvas());
        }
    }
    public void ContinueGame()
    {
        InterfaceParent.GetComponent<InterfaceContol>().SetInGame();
        SceneManager.LoadScene(PlayerPrefs.GetString("QuitScene"));
    }
    public void Quit()
    {
        Application.Quit();
    }
}
