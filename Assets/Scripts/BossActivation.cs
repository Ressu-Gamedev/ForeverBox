using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivation : DialogueTrigger
{
    private bool has;
    public Boss boss;
    public AudioSource audioS;
    public AudioClip theme;
    public AudioClip sfx;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player"))
        {
            has = true;
            TriggerDialogue();
            //Debug.Log("bababooey");
        }
    }
    
    void Update(){
        if(manager.inProgress || !has) return;
        boss.gameObject.SetActive(true);
        boss.isActive = true;
        audioS.clip = theme;
        audioS.Play();
        audioS.PlayOneShot(sfx);
        Destroy(this);
    }
}
