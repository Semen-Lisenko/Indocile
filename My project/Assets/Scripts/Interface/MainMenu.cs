using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] public GameObject SettingsCanvas;
    [SerializeField] public GameObject InterfaceParent;
    [SerializeField] public Button ContinueButton;
    public void OnEnable()
    {
        ContinueButton.enabled = PlayerPrefs.GetInt("FirstPlay") != 0;
    }
    public void StartNewGame()
    {
        PlayerPrefs.SetInt("FirstPlay", 1);
        PlayerPrefs.SetString("QuitScene", "planet1");
        ContinueGame();
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
    public void Settings()
    {
        SettingsCanvas.SetActive(SettingsCanvas.active ? false : true);
    }
}
