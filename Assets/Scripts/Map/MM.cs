using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MM : MonoBehaviour
{
    SortedDictionary<int, List<(int, int)>> roads = new SortedDictionary<int, List<(int, int)>>();

    private void Start()
    {
        Set();
    }

    public void Set()
    {
        for (int i = 0; i < 5; i++)
            MakeRoad();

        string temp = "";
        foreach(var kvp in roads)
        {
            var roadList = kvp.Value;
            bool[] isNodeExist = new bool[5];
            foreach (var road in roadList)
                isNodeExist[road.Item1] = true;

            for (int i = 0; i < 5; i++)
                temp += isNodeExist[i] ? "0" : "-";
            temp += "\n";
        }
        Debug.Log(temp);
    }

    void MakeRoad()
    {
        int start = Random.Range(0, 5);

        int count = 0;
        int end = start + (Random.Range(0, 2) == 0 ? -1 : 1); 
        if (end < 0) end = 0;
        if (end > 4) end = 4;
        if (roads.ContainsKey(count) == false)
            roads.Add(count, new List<(int, int)>());
        roads[count].Add((start, end));
        count++;

        while (count < 15)
        {
            start = end;
            end = start + (Random.Range(0, 2) == 0 ? -1 : 1);
            if (end < 0) end = 0;
            if (end > 4) end = 4;

            if (roads.ContainsKey(count) == false)
                roads.Add(count, new List<(int, int)>());
            roads[count].Add((start, end));
            count++;
        }
    }
}
