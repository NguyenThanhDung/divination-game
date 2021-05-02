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
        string content = "Question: " + question.text + "\n";

        int answerIndex = Random.Range(0, question.possibleAnswers.Length);
        content += "Answer: " + question.possibleAnswers[answerIndex].text;

        this.text.text = content;

        question.playedAnswer = question.possibleAnswers[answerIndex];

        this.display.SetActive(true);
    }

    public void OnBack()
    {
        this.questionList.Show();
        this.display.SetActive(false);
    }
}
