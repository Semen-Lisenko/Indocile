using UnityEngine;
using UnityEngine.UI;

public class Planet : MonoBehaviour
{
    [SerializeField]public string planetScene = "";
    [HideInInspector]public Animator Animator;
    [HideInInspector] public Button Button;
    public void Start()
    {
        Button = GetComponent<Button>();
        Animator = GetComponent<Animator>();
        SpaceMenu.DeselectOther += Deselect;
    }
    public void Select()
    {
        SpaceMenu.DeselectOther -= Deselect;
        SpaceMenu.DeselectOther.Invoke();
        SpaceMenu.SelectedPlanetScene = planetScene;
        Animator.SetBool("IsSelected", true);
        SpaceMenu.DeselectOther += Deselect;
    }
    public void Deselect()
    {
        if(Animator != null)
        {
            Animator.SetBool("IsSelected", false);
        }
    }
    private void OnDisable()
    {
        Button.interactable = false;
        Button.interactable = true;
    }
}
