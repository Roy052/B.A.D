using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager: Singleton
{
    string[] sheets = new string[]{ "Hero", "Mob" };

    const string pathHead = "./Assets/Data/";
    const string pathTail = ".bad";

    [System.Serializable]
    public class DataList<T>
    {
        public List<T> data;
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (dataManager == null)
            dataManager = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        SetDatas();
    }

    public void SetDatas()
    {
        var unitDatas = LoadFromJson_Hero();
        for(int i = 0; i < unitDatas.data.Count; i++)
        {
            //UnitData.unitDatas.Add(i, unitDatas.UnitDatas[i]);
        }
    }

    DataList<HeroData> LoadFromJson_Hero()
    {
        try
        {
            //Debug.Log(path);
            if (File.Exists(pathHead + sheets[0] + pathTail))
            {
                string jsonText = File.ReadAllText(pathHead + sheets[0] + pathTail);
                //Debug.Log(json);
                DataList<HeroData> dataList = JsonUtility.FromJson<DataList<HeroData>> ("{\"data\":" + jsonText + "}");
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
