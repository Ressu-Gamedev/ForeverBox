using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkTrigger : DialogueTrigger
{
    public AudioSource audioS;
    public AudioClip sfx;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player"))
        {
            TriggerDialogue();
            audioS.PlayOneShot(sfx);
            Destroy(this);
        }
    }
}
