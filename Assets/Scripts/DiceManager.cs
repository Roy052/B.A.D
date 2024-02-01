using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceManager : Singleton
{
    const int MinX = -260;
    const int MinY = -220;
    const int MaxX = 260;
    const int MaxY = 220;

    public GameObject dicePrefab;

    public GridLayoutGroup diceGrid;

    List<DiceInBattle> diceList = new List<DiceInBattle>();
    List<int> unUsedDiceList = new List<int>();
    List<int> usedDiceList = new List<int>();
    List<int> currentDiceList = new List<int>();

    int pickedDice = -1;

    System.Random random = new System.Random();

    public void Set()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject temp = Instantiate(dicePrefab, dicePrefab.transform.parent);
            DiceInBattle tempDice = temp.GetComponent<DiceInBattle>();
            diceList.Add(tempDice);
            tempDice.pickDice = PickDice;
            tempDice.releaseDice = ReleaseDice;
        }

        for (int i = 0; i < diceList.Count; i++)
            unUsedDiceList.Add(i);
    }

    public void PickDice()
    {
        int remainCount = Mathf.Max(0, 5 - unUsedDiceList.Count);
        for (int i = 0; i < remainCount; i++)
        {
            int randomIdx = random.Next(0, unUsedDiceList.Count);
            currentDiceList.Add(unUsedDiceList[randomIdx]);
            unUsedDiceList.RemoveAt(randomIdx);
        }

        while(usedDiceList.Count > 0)
        {
            unUsedDiceList.Add(usedDiceList[0]);
            usedDiceList.RemoveAt(0);
        }

        for(int i = remainCount; i < 5; i++)
        {
            int randomIdx = random.Next(0, unUsedDiceList.Count);
            currentDiceList.Add(unUsedDiceList[randomIdx]);
            unUsedDiceList.RemoveAt(randomIdx);
        }
    }

    public void RollDice()
    {
        for (int i = 0; i < currentDiceList.Count; i++)
        {
            DiceInBattle dice = diceList[currentDiceList[i]];
            dice.gameObject.SetActive(true);
            dice.Set(0, i);
            dice.SetSide(Random.Range(0, 6));
        }

        StartCoroutine(_RollDice());
    }

    IEnumerator _RollDice()
    {
        yield return null;
        List<Vector2> randomPoints = new List<Vector2>();
        for (int i = 0; i < 5; i++)
        {
            bool overlayed = true;
            Vector2 tempVec = Vector2.zero;
            while (overlayed)
            {
                overlayed = false;
                tempVec = new Vector2(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY));
                for (int j = 0; j < i; j++)
                {
                    if(Vector2.Distance(randomPoints[j], tempVec) <= 150)
                    {
                        overlayed = true;
                        break;
                    }
                }
            }
            

            randomPoints.Add(tempVec);
        }
        float currentTime = 0;

        diceGrid.enabled = false;
        while (currentTime < 1)
        {
            for (int i = 0; i < 5; i++)
            {
                RectTransform temp = diceList[currentDiceList[i]].transform as RectTransform;
                temp.anchoredPosition = Vector2.Lerp(temp.anchoredPosition, randomPoints[i], currentTime);
            }
            currentTime += Time.deltaTime;
            yield return null;
        }

        diceGrid.enabled = true;

        battleSM.currentStatusActivated = false;
    }

    public void PickDice(int idx)
    {
        pickedDice = idx;
    }

    public void ReleaseDice()
    {
        pickedDice = -1;
    }

    public void SetDice(int heroIdx)
    {
        currentDiceList.Remove(pickedDice);
    }

    public void RefreshDice()
    {
        while(currentDiceList.Count > 0)
        {
            usedDiceList.Add(currentDiceList[0]);
            currentDiceList.RemoveAt(0);
        }
    }

    public (int,int) GetPickedDice()
    {
        if (pickedDice == -1) return (-1, -1);
        return diceList[pickedDice].GetDiceInfo();
    }
}
