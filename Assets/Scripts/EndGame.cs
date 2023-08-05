using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScore;
    ScoreKeeper scoreKeeper;
    void Awake(){
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    public void ShowScore(){
        finalScore.text = "Congratulations!\nYour score is " + scoreKeeper.CalculateScore() + "%";
    }
}
