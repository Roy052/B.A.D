using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class UnitInBattle : MonoBehaviour
{
    [NonSerialized] public int unitIdx;

    public Image imgPortrait;
    public Text textName;
    public Text textAtk;
    public Text textDef;
    public RectTransform gauge;
    public Text textHealth;

    public GameObject magicPrefab;

    public List<DiceInBattle> diceSlots;

    public UnityAction<int, int> releaseDice;

    int maxHealth;
    int health;
    int maxSlot = 2;
    int currentSlot = 0;

    public virtual void Set(int unitId, int idx)
    {
        textName.text = "Hakos Baelz";
        unitIdx = idx;
    }

    public void SetDice(DiceInBattleInfo info)
    {
        if (currentSlot >= maxSlot)
            return;

        diceSlots[currentSlot].Set(info.diceId, info.idx);
        diceSlots[currentSlot].SetSide(info.sideNum);
        diceSlots[currentSlot].gameObject.SetActive(true);
        diceSlots[currentSlot].pickDice = ReleaseDice;
        currentSlot++;
    }

    public void ReleaseDice(int idx)
    {
        if (idx == -1 || (diceSlots[0].GetDiceInfo().idx != idx && diceSlots[1].GetDiceInfo().idx != idx))
        {
            Debug.Log("Not Exist Dice");
            return;
        }

        int diceOrder = diceSlots[0].GetDiceInfo().idx == idx ? 0 : 1;
        diceSlots[diceOrder].ResetDice();
        if (diceOrder == 1)
        {
            diceSlots[0].SetDiceInfo(diceSlots[1].GetDiceInfo());
            diceSlots[1].ResetDice();
        }
        currentSlot--;


        releaseDice?.Invoke(unitIdx, idx);
    }
}
