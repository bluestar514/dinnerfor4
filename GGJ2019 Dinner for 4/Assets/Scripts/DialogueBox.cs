using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{

    public string speakerName;
    public List<string> content;
    int page = 0;

    public GameObject speakerNameObj; 
    public GameObject textObject;
    Text nameText;
    Text dialogueText;

    private void Start() {
        nameText = speakerNameObj.GetComponent<Text>();
        dialogueText = textObject.GetComponent<Text>();

        nameText.text = speakerName;
        dialogueText.text = content[page];
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)){
            page++;
            if(page < content.Count){
                dialogueText.text = content[page];
            }else{
                CloseWindow();
            }
        }
    }

    private void CloseWindow(){
        Destroy(gameObject);
    }

}
