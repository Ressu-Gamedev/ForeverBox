using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Boss3 : Boss
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
    public AudioSource audioS;
    public AudioClip bzzz;
    public AudioClip bzzz2;
    public GameObject finale;
    public Vector2 newPos;
    public GameObject player;


    void Start()
    {
        finale.SetActive(false);
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
            finale.SetActive(true);
            audioS.clip = bzzz;
            audioS.volume = 0.4f;
            audioS.Play();
            audioS.PlayOneShot(bzzz2);
            cam1.SetActive(false);
            cam2.SetActive(true);
            prompt.gameObject.SetActive(false);
            player.transform.position = newPos;
            Destroy(this);
            return;
        }

        prompt.text = "TYPE: " + text[location].ToUpper();
        if(Input.GetKeyDown(text[location])){
            location++;
        }

    }
}
