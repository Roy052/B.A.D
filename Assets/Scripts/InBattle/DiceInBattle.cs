using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceInBattle : MonoBehaviour
{
    public Image imgSide;

    int currentSide;
    List<int> sideIds = new List<int>();
    List<Sprite> sideSprites = new List<Sprite>();

    public void Set(int diceId)
    {
        sideIds.Clear();
        for (int i = 0; i < 6; i++)
            sideIds.Add(i); //Add Another Ids

        for (int i = 0; i < 6; i++)
            sideSprites.Add(Singleton.resourceManager.diceSprites[sideIds[i]]);
    }

    public void SetSide(int num)
    {
        currentSide = num;
        imgSide.sprite = sideSprites[num];
    }

    public int GetSide()
    {
        return currentSide;
    }
}
