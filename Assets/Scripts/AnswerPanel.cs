using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerPanel : MonoBehaviour
{
    [SerializeField] private GameObject display;
    [SerializeField] private QuestionList questionList;

    public void ShowAnswer()
    {
        this.display.SetActive(true);
    }

    public void OnBack()
    {
        this.questionList.Show();
        this.display.SetActive(false);
    }
}
