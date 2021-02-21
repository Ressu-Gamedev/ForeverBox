using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Boss2 : Boss
{
    public Sprite[] images;
    public string[] text;
    private int location = 0;
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

    void Update(){
        if(!isActive) return;
        prompt.gameObject.SetActive(true);
        //Debug.Log("fsfsf");
        timer += Time.deltaTime;
        if(timer >= 1.5f){
            timer = 0;
            reps++;
            int index = Random.Range(0, 3);
            body.sprite = images[index];
        }

        if(location >= text.Length){
            if(!booped){
                booped = true;
                audioS.clip = bzzz;
                audioS.volume = 0.05f;
                audioS.Play();
                cam1.SetActive(false);
                cam2.SetActive(true);
                timer = 0f;
            }
            if(timer > 0.75f){
                PlayerPrefs.SetInt("playthrough", 3);
                SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
                Destroy(this);
            }
            return;
        }

        prompt.text = "TYPE: " + text[location].ToUpper();
        if(Input.GetKeyDown(text[location])){
            location++;
        }

    }
}
