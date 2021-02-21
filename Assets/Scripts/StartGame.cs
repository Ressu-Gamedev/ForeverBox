using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private int nextScene;
    void OnMouseOver(){
        if (Input.GetMouseButtonDown(0)){
            nextScene = PlayerPrefs.GetInt("playthrough", 1);
            SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
        }
    }
}
