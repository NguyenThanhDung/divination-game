using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionButton : MonoBehaviour
{
    public Question question;
    public Text text;
    public QuestionList questionList;

    public void OnClick()
    {
        this.questionList.OnClickQuestion(question);
    }
}
