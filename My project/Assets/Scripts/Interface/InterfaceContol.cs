using UnityEngine;

public class InterfaceContol : MonoBehaviour
{
    [SerializeField] public GameObject InGame;
    [SerializeField] public GameObject OutGame;
    [SerializeField] public GameObject SpaceMenuCanvas;
    [SerializeField] public GameObject BreakPauseCanvas;
    public bool inGame = false;
    public void SetInGame()
    {
        InGame.SetActive(true);
        OutGame.SetActive(false);
        SpaceMenuCanvas.SetActive(false);
        BreakPauseCanvas.SetActive(false);
    }
    public void SetOutGame()
    {
        InGame.SetActive(false);
        OutGame.SetActive(true);
        SpaceMenuCanvas.SetActive(false);
        BreakPauseCanvas.SetActive(false);
    }
}
