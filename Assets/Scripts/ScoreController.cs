using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score;
    private void Start() {
        UpdateTextUI();
    
    }
    public void incScore(){
        score += 1;
        UpdateTextUI();
    }
    void UpdateTextUI(){
        scoreText.text = "SCORE : " + score;
    }
}
