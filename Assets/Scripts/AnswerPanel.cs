using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerPanel : MonoBehaviour
{
    [SerializeField] private GameObject display;

    public void ShowAnswer()
    {
        this.display.SetActive(true);
    }
}
