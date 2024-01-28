using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : Singleton
{
    public GameObject dicePrefab;

    List<DiceInBattle> diceList = new List<DiceInBattle>();
    List<int> unUsedDiceList = new List<int>();
    List<int> usedDiceList = new List<int>();
    List<int> currentDiceList = new List<int>();

    int pickedDice = -1;

    System.Random random = new System.Random();

    public void Set(int battleId)
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
        int remainCount = unUsedDiceList.Count;
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

    public RectTransform GetCurrentDiceRect(int order)
    {
        return diceList[currentDiceList[order]].transform as RectTransform;
    }
}
