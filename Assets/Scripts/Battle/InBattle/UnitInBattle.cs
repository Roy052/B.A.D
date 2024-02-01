using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class UnitInBattle : MonoBehaviour
{
    [NonSerialized] public int unitOrder;

    public Image imgPortrait;
    public Text textName;
    public Text textAtk;
    public Text textDef;
    public RectTransform gauge;
    public Text textHealth;

    public GameObject magicPrefab;

    public List<DiceInBattle> diceSlots;

    int maxHealth;
    int health;
    int maxSlot = 2;
    int currentSlot = 0;

    public void Set(int unitId, int order)
    {
        textName.text = "Hakos Baelz";
        unitOrder = order;
    }

    public void SetDice(int diceId, int sideNum)
    {
        if (currentSlot >= maxSlot)
            return;

        diceSlots[currentSlot].Set(diceId, currentSlot);
        diceSlots[currentSlot].SetSide(sideNum);
        diceSlots[currentSlot].gameObject.SetActive(true);
        currentSlot++;
    }
}
