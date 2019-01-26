using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour
{
    //public List<string> content;
    public List<Conversation> conversations;
    public string speakerName;
    int conversationNum=0;

    public GameObject dialogueBoxPrefab;
    GameObject dialogueBoxObj;

    public GameObject canvas; 


    private void Start() {
        dialogueBoxObj = Instantiate(dialogueBoxPrefab, canvas.transform);
        DialogueBox box = dialogueBoxObj.GetComponent<DialogueBox>();
        box.speakerName = speakerName;
        

        box.CloseWindow();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.T)){
            OpenDialogueBox();
        }
    }

    public void OpenDialogueBox(){
        dialogueBoxObj.SetActive(true);
        
        DialogueBox box = dialogueBoxObj.GetComponent<DialogueBox>();
        Conversation current = conversations[conversationNum];
        
        box.content = current.content;
        if(!current.repeated) conversationNum += 1;
        if(conversationNum >= conversations.Count) conversationNum = 0;
        if(current.absoluteNumber > 0) current.absoluteNumber--;
        if(current.absoluteNumber == 0) conversations.Remove(current);
        

        dialogueBoxObj.GetComponent<DialogueBox>().OpenWindow();
    }
}

[System.Serializable]
public class Conversation{
    public List<string> content;
    public bool repeated;
    public int absoluteNumber = -1;
}
