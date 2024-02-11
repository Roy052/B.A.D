using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DiceInBattleInfo
{
    public int diceId;
    public int sideNum;
    public int idx;
}

public class DiceInBattle : MonoBehaviour
{
    public Image imgSide;
    public Image imgPicked;

    public UnityAction<int> pickDice;
    public UnityAction releaseDice;

    public bool onlyPick = false;

    DiceInBattleInfo info = new DiceInBattleInfo();
    List<int> sideIds = new List<int>();
    List<Sprite> sideSprites = new List<Sprite>();

    bool isPicked = false;

    public void Set(int diceId, int idx)
    {
        info.diceId = diceId;
        info.idx = idx;

        sideIds.Clear();
        for (int i = 0; i < 6; i++)
            sideIds.Add(i); //Add Another Ids

        for (int i = 0; i < 6; i++)
            sideSprites.Add(Singleton.resourceManager.diceSprites[sideIds[i]]);

        imgPicked.gameObject.SetActive(false);
    }

    public void SetSide(int num)
    {
        info.sideNum = num;
        imgSide.sprite = sideSprites[num];
    }

    public void SetDiceInfo(DiceInBattleInfo otherInfo)
    {
        Set(otherInfo.diceId, otherInfo.idx);
        SetSide(otherInfo.sideNum);
    }

    public DiceInBattleInfo GetDiceInfo()
    {
        return info;
    }

    public void OnClickDice()
    {
        if (isPicked == false || onlyPick)
            pickDice?.Invoke(info.idx);
        else
            releaseDice?.Invoke();

        isPicked = !isPicked;
        imgPicked.gameObject.SetActive(isPicked);
    }

    public void ResetDice()
    {
        onlyPick = false;
        info.diceId = -1;
        info.idx = -1;
        info.sideNum = -1;
        isPicked = false;
        imgSide.sprite = null;
    }
}
