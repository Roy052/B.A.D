using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager: MonoBehaviour
{
    const string path = "./Assets/Data/";

    [System.Serializable]
    public class MyData
    {
        public string a;
        public string b;
        public string c;
        public string d;
    }

    [System.Serializable]
    public class MyDataList
    {
        public List<MyData> data;
    }

    private void Awake()
    {
        SetDatas();
    }

    public void SetDatas()
    {
        var unitDatas = LoadFromJson();
        for(int i = 0; i < unitDatas.data.Count; i++)
        {
            //UnitData.unitDatas.Add(i, unitDatas.UnitDatas[i]);
        }
    }

    MyDataList LoadFromJson()
    {
        try
        {
            //Debug.Log(path);
            if (File.Exists(path + "Sheet1.json"))
            {
                string jsonText = File.ReadAllText(path + "Sheet1.json");
                //Debug.Log(json);
                MyDataList dataList = JsonUtility.FromJson<MyDataList>("{\"data\":" + jsonText + "}");
                return dataList;
            }
        }
        catch (FileNotFoundException e)
        {
            Debug.Log("The file was not found:" + e.Message);
            return default;
        }
        catch (DirectoryNotFoundException e)
        {
            Debug.Log("The directory was not found: " + e.Message);
            return default;
        }
        catch (IOException e)
        {
            Debug.Log("The file could not be opened:" + e.Message);
            return default;
        }
        return default;
    }
}
