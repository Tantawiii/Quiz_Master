using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz quiz;
    EndGame endGame;
    void Awake(){
        quiz = FindObjectOfType<Quiz>();
        endGame = FindObjectOfType<EndGame>();
    }
    void Start()
    {
        quiz.gameObject.SetActive(true);
        endGame.gameObject.SetActive(false);
    }
    void Update()
    {
        if(quiz.isComplete){
            quiz.gameObject.SetActive(false);
            endGame.gameObject.SetActive(true);
            endGame.ShowScore();
        }
    }
    public void OnReplay(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
