using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Boss1 : Boss
{
    public Sprite[] images;
    public string[] text;
    public TextMeshProUGUI prompt;
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
        if(reps <= 12) prompt.gameObject.SetActive(true);
        //Debug.Log("fsfsf");
        timer += Time.deltaTime;
        if(timer >= 1.5f){
            timer = 0;
            reps++;
            int index = Random.Range(0, 4);
            prompt.text = "TYPE: " + text[index].ToUpper();
            body.sprite = images[index];
        }
        if(reps > 12 && !booped){
            booped = true;
            prompt.gameObject.SetActive(false);
            audioS.clip = bzzz;
            audioS.volume = 0.15f;
            audioS.Play();
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
        if(reps > 15){
            Thread.Sleep(7500);
            PlayerPrefs.SetInt("playthrough", 2);
            SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
            Destroy(this);
            //Debug.Log("sgsgs");
        }
    }
}
