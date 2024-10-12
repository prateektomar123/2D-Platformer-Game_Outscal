using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    public UnityEvent onLevelComplete;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            onLevelComplete.Invoke();

            LevelManager.Instance.SetLevelStatus(SceneManager.GetActiveScene().name,LevelStatus.Completed);

            Debug.Log("Level Completed");
        }
    }

    public void NextLevel()
{
    Scene currentScene = SceneManager.GetActiveScene();
    LevelManager.Instance.SetLevelStatus(currentScene.name, LevelStatus.Completed);

    int nextSceneIndex = currentScene.buildIndex + 1;

    // Ensure that the next scene index is valid (i.e., within build settings range)
    if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
    {
        LevelManager.Instance.SetLevelStatus("Level" + nextSceneIndex, LevelStatus.Unlocked); // Assuming level naming convention
        SceneManager.LoadScene(nextSceneIndex);
    }
    else
    {
        Debug.LogError("Next scene index is out of range!");
    }
}
}
