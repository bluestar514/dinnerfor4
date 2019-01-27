using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{

    public string speakerName;
    public List<string> content;
    int page = 0;

    public float textSpeed = .01f; //seconds per character
    bool effectActive = false;

    public GameObject speakerNameObj; 
    public GameObject textObject;
    Text nameText;
    Text dialogueText;

    

    private void Awake() {
        nameText = speakerNameObj.GetComponent<Text>();
        dialogueText = textObject.GetComponent<Text>();

        
    }

    private void Start()
    {
        OpenWindow();
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)){
            if(effectActive){
                effectActive = false;
                dialogueText.text = content[page];
            }else{
                page++;
                if(page < content.Count){
                    StartTypewritterEffect(content[page], dialogueText);
                }else{
                    CloseWindow();
                }
            }
        }
    }

    public void OpenWindow(){
        page = 0;
        nameText.text = speakerName;
        StartTypewritterEffect(content[page], dialogueText);
        //dialogueText.text = content[page];
    }

    public void CloseWindow(){
        gameObject.SetActive(false);
    }

    public void StartTypewritterEffect(string dialogue, Text text){
        effectActive = true;

        IEnumerator coroutine = TypewritterEffect(dialogue, text);
        StartCoroutine(coroutine);
    }

    private IEnumerator TypewritterEffect(string dialogue, Text text){
        text.text = "";
        foreach(char c in dialogue){
            if(!effectActive) break;

            text.text += c;
            yield return new WaitForSeconds(textSpeed);            
        }

        effectActive = false;
    }

}
