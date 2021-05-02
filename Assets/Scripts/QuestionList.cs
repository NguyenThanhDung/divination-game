using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionList : MonoBehaviour
{
    [SerializeField] private TextAsset dataFile;
    [SerializeField] private GameObject display;
    [SerializeField] private QuestionButton questionButtonPrefab;
    [SerializeField] private AnswerPanel answerPanel;

    private Data data;
    private QuestionButton[] questionButtons;
    private int[] answersOfQuestions;

    void Start()
    {
        Debug.Log("Data File:");
        Debug.Log(dataFile.text);

        this.data = JsonUtility.FromJson<Data>(dataFile.text);
        this.questionButtons = new QuestionButton[this.data.questions.Length];
        for (int i = 0; i < this.data.questions.Length; i++)
        {
            Debug.Log($"Question: "+ this.data.questions[i].text);
            for (int j = 0; j < this.data.questions[i].answers.Length; j++)
            {
                Debug.Log($"  Answer {j}:");
                Debug.Log($"    {this.data.questions[i].answers[j].text}");
                Debug.Log($"    {this.data.questions[i].answers[j].image_url}");
                Debug.Log($"    {this.data.questions[i].answers[j].should_show_profile_image}");
            }
            this.questionButtons[i] = Instantiate<QuestionButton>(this.questionButtonPrefab, this.display.transform);
            this.questionButtons[i].question = this.data.questions[i];
            this.questionButtons[i].text.text = this.data.questions[i].text;
            this.questionButtons[i].questionList = this;
        }

        this.answersOfQuestions = new int[this.data.questions.Length];
        for (int i = 0; i < this.answersOfQuestions.Length; i++)
        {
            this.answersOfQuestions[i] = -1;
        }
    }

    public void Show()
    {
        for (int i = 0; i < this.answersOfQuestions.Length; i++)
        {
            this.questionButtons[i].text.text = this.answersOfQuestions[i] >= 0 ? ("[X] " + this.data.questions[i].text) : this.data.questions[i].text;
        }
        this.display.SetActive(true);
    }

    public void OnClickQuestion(Question question)
    {
        this.display.SetActive(false);
        this.answerPanel.ShowAnswer(question);
    }

    public void SetAnswer(int questionID, int answerID)
    {
        this.answersOfQuestions[questionID] = answerID;
    }
}
