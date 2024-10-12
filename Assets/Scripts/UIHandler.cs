using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    public GameObject gameOverMenu;
    public UnityEvent onLastLevel;
    public bool lastLevel;

    private void Start() {
        if(lastLevel){
            onLastLevel.Invoke();
        }
    }
    public void gameOver(){
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void loadScene(int buildIndex){
        Time.timeScale = 1f;
        SceneManager.LoadScene(buildIndex);
    }
    public void Home(){
        loadScene(0);
    }

    public void RestartLevel(){
        loadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void loadScene(string sceneName){
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}
