using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionList : MonoBehaviour
{
    [SerializeField] private TextAsset dataFile;
    [SerializeField] private GameObject display;
    [SerializeField] private QuestionButton questionButtonPrefab;
    [SerializeField] private AnswerPanel answerPanelPrefab;

    private Data data;
    private QuestionButton[] questionButtons;
    private AnswerPanel answerPanel;

    void Start()
    {
        Debug.Log("Data File:");
        Debug.Log(dataFile.text);

        this.data = JsonUtility.FromJson<Data>(dataFile.text);
        this.questionButtons = new QuestionButton[this.data.questions.Length];
        for (int i = 0; i < this.data.questions.Length; i++)
        {
            Debug.Log($"Question: "+ this.data.questions[i].text);
            for (int j = 0; j < this.data.questions[i].possibleAnswers.Length; j++)
            {
                Debug.Log($"  Answer {j}:");
                Debug.Log($"    {this.data.questions[i].possibleAnswers[j].text}");
                Debug.Log($"    {this.data.questions[i].possibleAnswers[j].image}");
                Debug.Log($"    {this.data.questions[i].possibleAnswers[j].should_show_profile_image}");
            }
            this.questionButtons[i] = Instantiate<QuestionButton>(this.questionButtonPrefab, this.display.transform);
            this.questionButtons[i].question = this.data.questions[i];
            this.questionButtons[i].text.text = this.data.questions[i].text;
            this.questionButtons[i].image.sprite = Resources.Load<Sprite>(this.data.questions[i].image);
            this.questionButtons[i].questionList = this;
        }
    }

    public void Show()
    {
        for (int i = 0; i < this.questionButtons.Length; i++)
        {
            this.questionButtons[i].text.text = string.Empty;
            if (this.data.questions[i].playedAnswer.text != null)
                this.questionButtons[i].text.text += "[X] ";
            this.questionButtons[i].text.text += this.data.questions[i].text;
        }
        this.display.SetActive(true);
    }

    public void OnClickQuestion(Question question)
    {
        if (this.answerPanel != null)
            Destroy(this.answerPanel);
        this.answerPanel = Instantiate<AnswerPanel>(this.answerPanelPrefab, this.display.transform);
        this.answerPanel.transform.SetSiblingIndex(0);
        this.answerPanel.ShowAnswer(question);
    }
}
