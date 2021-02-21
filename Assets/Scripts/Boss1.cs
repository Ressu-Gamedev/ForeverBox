using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss1 : Boss
{
    public Sprite[] images;
    public float timer = 0f;
    public int reps = 0;
    public SpriteRenderer body;
    public GameObject cam1;
    public GameObject cam2;
    bool booped = false;
    public AudioSource audioS;
    public AudioClip bzzz;


    void Start()
    {
        gameObject.SetActive(false);
    }

    void FixedUpdate(){
        if(!isActive) return;
        //Debug.Log("fsfsf");
        timer += Time.deltaTime;
        if(timer >= 1.5f){
            timer = 0;
            reps++;
            int index = Random.Range(0, 4);
            body.sprite = images[index];
        }
        if(reps > 12 && !booped){
            booped = true;
            audioS.clip = bzzz;
            audioS.volume = 0.15f;
            audioS.Play();
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
        if(reps > 15){
            Thread.Sleep(10000);
            PlayerPrefs.SetInt("playthrough", 2);
            SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
            Destroy(this);
            //Debug.Log("sgsgs");
        }
    }
}
