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
        this.text.text = "This is the answer of question:\n" + question.text;
        this.display.SetActive(true);
    }

    public void OnBack()
    {
        this.questionList.Show();
        this.display.SetActive(false);
    }
}
