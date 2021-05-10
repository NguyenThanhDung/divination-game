using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private GameObject display;
    [SerializeField] private Text text;

    public void Show()
    {
        StartCoroutine(ShowInSeconds(3f));
    }

    private IEnumerator ShowInSeconds(float time)
    {
        this.display.SetActive(true);
        yield return new WaitForSeconds(time);
        this.display.SetActive(false);
    }
}
