using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerPanel : MonoBehaviour
{
    [SerializeField] private GameObject display;
    [SerializeField] private Text text;
    [SerializeField] private Image image;
    [SerializeField] private QuestionList questionList;

    public void ShowAnswer(Question question)
    {
        this.text.text = "Question: " + question.text + "\nAnswer: ";
        if (question.playedAnswer.text != null)
        {
            this.text.text += question.playedAnswer.text;
            this.image.sprite = Resources.Load<Sprite>(question.playedAnswer.image);
        }
        else
        {
            int answerIndex = Random.Range(0, question.possibleAnswers.Length);
            this.text.text += question.possibleAnswers[answerIndex].text;
            this.image.sprite = Resources.Load<Sprite>(question.possibleAnswers[answerIndex].image);
            question.playedAnswer = question.possibleAnswers[answerIndex];
        }
        this.display.SetActive(true);
    }

    public void OnBack()
    {
        this.questionList.Show();
        this.display.SetActive(false);
    }
}
