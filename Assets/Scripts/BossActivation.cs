using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivation : DialogueTrigger
{
    private bool has;
    public Boss boss;
    public AudioSource audioS;
    public AudioClip theme;
    public AudioClip theme2;
    public AudioClip sfx;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player"))
        {
            has = true;
            audioS.clip = theme;
            audioS.Play();
            TriggerDialogue();
        }
    }
    
    void Update(){
        if(manager.inProgress || !has) return;
        boss.gameObject.SetActive(true);
        boss.isActive = true;
        audioS.clip = theme2;
        audioS.Play();
        audioS.PlayOneShot(sfx);
        Destroy(this);
    }
}
