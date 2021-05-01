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
        string content = "Question: " + question.text + "\nAnswers:\n";
        foreach (Answer answer in question.answers)
        {
            content += "  * " + answer.text + "\n";
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
