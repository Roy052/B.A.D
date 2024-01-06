using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    const string path = "./Sheet/GameData.csv";

    private void Start()
    {
        XlsToJson.ConvertCsvFileToJsonObject(path);
    }
}
