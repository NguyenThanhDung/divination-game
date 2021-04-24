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
    }
}
