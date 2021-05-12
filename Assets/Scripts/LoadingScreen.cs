using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private GameObject display;
    [SerializeField] private Text text;

    private string originalText = "The result will sock you";

    public void Show()
    {
        StartCoroutine(ShowInSeconds(1.5f));
        StartCoroutine(UpdateText());
    }

    private IEnumerator ShowInSeconds(float time)
    {
        this.display.SetActive(true);
        yield return new WaitForSeconds(time);
        this.display.SetActive(false);
    }

    private IEnumerator UpdateText()
    {
        for(int i = 0; i <= this.originalText.Length; i++)
        {
            this.text.text = this.originalText.Substring(0, i) + "...";
            yield return new WaitForSeconds(0.05f);
            if (this.display.activeInHierarchy == false)
                break;
        }
    }
}
