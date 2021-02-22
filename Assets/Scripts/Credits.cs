using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public float counter = 0f;

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if(counter > 9.7f){
            PlayerPrefs.SetInt("playthrough", 4);
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
