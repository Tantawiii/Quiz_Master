using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "Question 1")]
public class QuestionSO : ScriptableObject
{   
    [TextArea(2,6)]
    [SerializeField] string question = "Enter new question text here";
    [SerializeField] string [] answer = new string[4];
    [SerializeField] int correct;

    public string GetQuestion()
    {
        return question;
    }
    public int GetCorrect()
    {
        return correct;
    }
    public string GetAnswer(int index)
    {
        return answer[index];
    }
}
