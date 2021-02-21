using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class TalkTrigger : DialogueTrigger
{
    public AudioSource audioS;
    public AudioClip sfx;
    public bool end = false;
    public bool trig = false;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player"))
        {
            TriggerDialogue();
            audioS.PlayOneShot(sfx);
            if(!end) Destroy(this);
            trig = true;
        }
    }

    void Update(){
        if(!end) return;
        if(!manager.inProgress && trig){
            PlayerPrefs.SetInt("playthrough", 1);
            SceneManager.LoadScene(0, LoadSceneMode.Single);
            Destroy(this);
        }
    }
}
