using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private TextAsset dataFile;

    void Start()
    {
        Debug.Log("Data File:");
        Debug.Log(dataFile.text);

        Data data = JsonUtility.FromJson<Data>(dataFile.text);
        for (int i = 0; i < data.questions.Length; i++)
        {
            Debug.Log("Question "+ i +": "+ data.questions[i].text);
            for (int j = 0; j < data.questions[i].answers.Length; j++)
            {
                Debug.Log($"  Answer {j}:");
                Debug.Log($"    {data.questions[i].answers[j].text}");
                Debug.Log($"    {data.questions[i].answers[j].image_url}");
                Debug.Log($"    {data.questions[i].answers[j].should_show_profile_image}");
            }
        }
    }
}
