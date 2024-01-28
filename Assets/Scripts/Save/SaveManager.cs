using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public enum PickType
{
    NotPicked = -2,
    Current = -1,
}

public enum GradeType
{
    GradeOne = 0,
    GradeTwo = 1,
    GradeThree = 2,
}

public enum StateType
{
    None        = 0,
    SetTicket   = 1,
    SetGift     = 2,
    PickGift    = 3,
    Gacha       = 4,
}


[Serializable]
public class SaveData
{
    public string dataName;

    //PlayerStatus

    //InGame

    //Map
    int currentMap;
    string mapSeed;
    public List<int> passedRoute;

    //
    public int battleId;

    public List<int> earnedItems;
    public List<HeroData> heroDatas; 

}

[Serializable]
public class HeroData
{
    public int heroId;
    public int slotNum;
    public List<int> sideIds;
}

public class SaveManager : Singleton
{
    public List<Sprite> sprites;

    public SaveData data;

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (saveManager == null)
            saveManager = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        LoadData();
    }

    void LoadData()
    {
        data = LoadFromJson();
        if(data == null)
        {
            Debug.Log("No Data");
            data = new SaveData();
        }
    }

    public void DataReset()
    {
        data = new SaveData();
    }

    public void SaveData()
    {
        SaveIntoJson(data);
    }

    const string path = "./Assets/Save/SaveData.json";

    static public void SaveIntoJson(SaveData data)
    {
        data.dataName = $"Save_{DateTime.Now}";

        string save = JsonUtility.ToJson(data);
        //Debug.Log(save);
        File.WriteAllText(path, save);
        RefreshEditor();
    }

    static public SaveData LoadFromJson()
    {
        try
        {
            //Debug.Log(path);
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                //Debug.Log(json);
                SaveData gl = JsonUtility.FromJson<SaveData>(json);
                return gl;
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

    static public void DeleteSave()
    {
        try
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                RefreshEditor();
            }
        }
        catch (FileNotFoundException e)
        {
            Debug.Log("The file was not found:" + e.Message);
        }
        catch (DirectoryNotFoundException e)
        {
            Debug.Log("The directory was not found: " + e.Message);
        }
        catch (IOException e)
        {
            Debug.Log("The file could not be opened:" + e.Message);
        }
    }

    static public void RefreshEditor()
    {
#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
    }
}

