using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    public string text;
    public string image;
    public Answer[] possibleAnswers;
    public Answer playedAnswer;
}
