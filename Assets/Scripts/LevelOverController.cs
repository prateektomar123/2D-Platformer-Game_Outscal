using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Events;

public class LevelOverController : MonoBehaviour
{
    public UnityEvent onLevelComplete;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            onLevelComplete.Invoke();
            Debug.Log("Level Completed");
        }
    }
}
