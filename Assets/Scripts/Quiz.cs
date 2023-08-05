using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questiontext;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentQuestion;

    [Header("Answers")]
    [SerializeField] GameObject [] answers;
    int correctAnswer;
    bool answeredEarly = true;

    [Header("Buttons")]
    [SerializeField] Sprite defaultAnswerS;
    [SerializeField] Sprite correctAnswerS;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoretext;
    ScoreKeeper scoreKeeper;

    [Header("ProgressBar")]
    [SerializeField] Slider progressBar;

    public bool isComplete;

    void Awake(){
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
    }
    void Update() {
        timerImage.fillAmount = timer.timerFiller;
        if(timer.loadNextQ){
            if(progressBar.value == progressBar.maxValue){
                isComplete = true;
                return;
            }
            answeredEarly = false;
            OnToNextQ();
            timer.loadNextQ = false;
        }
        else if(!answeredEarly && !timer.isAnsweringQ){
            DisplayA(-1);
            ButtonState(false);
        }
    }
    void DisplayA(int index){
        Image buttonImage;
        if(index == currentQuestion.GetCorrect()){
            questiontext.text = "Correct!";
            buttonImage = answers[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerS;
            scoreKeeper.SetCorrectAnswers();
        }
        else{
            int CA = currentQuestion.GetCorrect();
            questiontext.text = "Incorrect! Correct Answer was \t" + currentQuestion.GetAnswer(CA);
            buttonImage = answers[CA].GetComponent<Image>();
            buttonImage.sprite = correctAnswerS;
        }
    }
    public void OnAnswerSelected(int index){
        answeredEarly = true;
        DisplayA(index);
        ButtonState(false);
        timer.CancelTimer();
        scoretext.text = "Score: " + scoreKeeper.CalculateScore() + "%";
    }
    void DisplayQ(){
        questiontext.text = currentQuestion.GetQuestion();
        for(int i = 0; i<answers.Length; i++){
            TextMeshProUGUI buttonText = answers[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
        }
    }
    void ButtonState(bool state){
        for(int i = 0; i<answers.Length; i++){
            Button button = answers[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
    void OnToNextQ(){
        if(questions.Count != 0){
            ButtonState(true);
            SetDefaultBSprite();
            GetRandomQ();
            DisplayQ();
            progressBar.value++;
            scoreKeeper.SetQuestionsSeen();
        }
    }

    void GetRandomQ()
    {
        int index = UnityEngine.Random.Range(0, questions.Count);
        currentQuestion = questions[index];
        if(questions.Contains(currentQuestion)){
            questions.Remove(currentQuestion);
        }
    }

    void SetDefaultBSprite()
    {
        Image buttonImage;
        for(int i = 0; i<answers.Length; i++){
            buttonImage = answers[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerS;
        }  
    }
}
