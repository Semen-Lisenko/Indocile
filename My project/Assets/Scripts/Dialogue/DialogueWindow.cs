using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "Dialogue Data")]
public class DialogueWindow : ScriptableObject
{
    public string dialogueName;
    public Sprite personImage;
    public string dialogueTitle;
    public string description;    
}
