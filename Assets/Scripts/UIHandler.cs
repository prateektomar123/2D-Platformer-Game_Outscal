using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    public GameObject gameOverMenu;

    public void gameOver(){
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void loadScene(int buildIndex){
        Time.timeScale = 1f;
        SceneManager.LoadScene(buildIndex);
    }
}
