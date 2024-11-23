using UnityEngine;
using UnityEngine.SceneManagement;

public class SavesControl : MonoBehaviour
{

    public static void SaveGame()
    {
        if (Equals(SceneManager.GetActiveScene().name[5], 't'))
        {
            PlayerPrefs.SetString("QuitScene", SceneManager.GetActiveScene().name);
        }
    }
}
