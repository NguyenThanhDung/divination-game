using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerPanel : MonoBehaviour
{
    [SerializeField] private GameObject display;
    [SerializeField] private Text text;
    [SerializeField] private QuestionList questionList;

    public void ShowAnswer(Question question)
    {
        string content = "Question: " + question.text + "\nAnswer: ";
        if (question.playedAnswer.text != null)
        {
            content += question.playedAnswer.text;
        }
        else
        {
            int answerIndex = Random.Range(0, question.possibleAnswers.Length);
            content += question.possibleAnswers[answerIndex].text;
            question.playedAnswer = question.possibleAnswers[answerIndex];
        }
        this.text.text = content;
        this.display.SetActive(true);
    }

    public void OnBack()
    {
        this.questionList.Show();
        this.display.SetActive(false);
    }
}
