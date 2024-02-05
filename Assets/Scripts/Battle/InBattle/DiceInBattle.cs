using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DiceInBattle : MonoBehaviour
{
    public Image imgSide;
    public Image imgPicked;

    public UnityAction<int> pickDice;
    public UnityAction releaseDice;

    public bool onlyPick = false;

    int diceId;
    int sideNum;
    int idx;
    List<int> sideIds = new List<int>();
    List<Sprite> sideSprites = new List<Sprite>();

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
        sideNum = num;
        imgSide.sprite = sideSprites[num];
    }

    public (int, int) GetDiceInfo()
    {
        return (diceId, sideNum);
    }

    public void OnClickDice()
    {
        if (isPicked == false || onlyPick)
            pickDice?.Invoke(idx);
        else
            releaseDice?.Invoke();

        isPicked = !isPicked;
        imgPicked.gameObject.SetActive(isPicked);
    }

    public void ResetDice()
    {
        onlyPick = false;
        diceId = -1;
        idx = -1;
        sideNum = -1;
        isPicked = false;
    }
}
