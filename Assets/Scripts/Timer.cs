using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool isAnsweringQ;
    public bool loadNextQ;
    public float timerFiller;
    [SerializeField]float questionTime = 15f;
    [SerializeField]float answerTime = 5f;
    float timerCounter;
    void Update()
    {
        UpdateTimer();
    }
    public void CancelTimer(){
        timerCounter = 0;
    }
    void UpdateTimer(){
        timerCounter -= Time.deltaTime;
        if(isAnsweringQ){
            if(timerCounter > 0){
                timerFiller = timerCounter/questionTime;
            }
            else{
                isAnsweringQ = false;
                timerCounter = answerTime;
            }
        }
        else{
            if(timerCounter > 0){
                timerFiller = timerCounter/answerTime;
            }
            else{
                isAnsweringQ = true;
                timerCounter = questionTime;
                loadNextQ = true;
            }
        }
        Debug.Log(isAnsweringQ + ":" + timerCounter + "=" + timerFiller);
    }
}
