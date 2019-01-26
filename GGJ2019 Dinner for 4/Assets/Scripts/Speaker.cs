using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour
{
    public List<string> content;
    public string speakerName;
    public GameObject dialogueBoxPrefab;
    GameObject dialogueBoxObj;

    public GameObject canvas; 


    private void Start() {
        dialogueBoxObj = Instantiate(dialogueBoxPrefab, canvas.transform);
        DialogueBox box = dialogueBoxObj.GetComponent<DialogueBox>();
        box.speakerName = speakerName;
        box.content = content;

        box.CloseWindow();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.T)){
            OpenDialogueBox();
        }
    }

    public void OpenDialogueBox(){
        dialogueBoxObj.SetActive(true);
        dialogueBoxObj.GetComponent<DialogueBox>().OpenWindow();
    }
}
