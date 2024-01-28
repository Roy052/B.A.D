using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DiceInBattle : MonoBehaviour
{
    public Image imgSide;
    public Image imgPicked;

    int diceId;
    int idx;
    int currentSide;
    List<int> sideIds = new List<int>();
    List<Sprite> sideSprites = new List<Sprite>();

    public UnityAction<int> pickDice;
    public UnityAction releaseDice;

    bool isPicked = false;

    public void Set(int diceId, int idx)
    {
        this.diceId = diceId;
        this.idx = idx;

        sideIds.Clear();
        for (int i = 0; i < 6; i++)
            sideIds.Add(i); //Add Another Ids

        for (int i = 0; i < 6; i++)
            sideSprites.Add(Singleton.resourceManager.diceSprites[sideIds[i]]);

        imgPicked.gameObject.SetActive(false);
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

    public void OnClickDice()
    {
        if (isPicked == false)
            pickDice?.Invoke(idx);
        else
            releaseDice?.Invoke();

        isPicked = !isPicked;
        imgPicked.gameObject.SetActive(isPicked);
    }
}
