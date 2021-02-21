using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager manager;

    void Start(){
        manager = FindObjectOfType<DialogueManager>();
    }

    public void TriggerDialogue(){
        manager.StartDialogue(dialogue);
    }
}
