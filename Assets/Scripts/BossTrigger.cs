using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject player;
    public Vector2 newLoc;
    public AudioSource audioS;
    public AudioClip audio;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player"))
        {
            collision.transform.position = newLoc;
            cam1.SetActive(false);
            cam2.SetActive(true);
            audioS.clip = audio;
            audioS.Play();
            Destroy(this);
        }
    }
}
