using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> dialogue;
    public SpriteRenderer profile;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;

    void Start()
    {
        dialogue = new Queue<string>();
    }

    public void StartDialogue(Dialogue toPlay){
        //Debug.Log("Starting " + toPlay.name);
        animator.SetBool("IsOpen", true);
        profile.sprite = toPlay.profile;
        nameText.text = toPlay.name;
        dialogue.Clear();
        foreach (string phrase in toPlay.dialogue){
            dialogue.Enqueue(phrase);
        }

        DisplayNextPhrase();
    }

    public void DisplayNextPhrase(){
        if(dialogue.Count == 0){
            EndDialogue();
            return;
        }
        string phrase = dialogue.Dequeue();
        //Debug.Log(phrase);
        dialogueText.text = phrase;
    }

    void EndDialogue(){
        //Debug.Log("Ending dialogue");
        animator.SetBool("IsOpen", false);
    }

}
