using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class UnitInBattle : MonoBehaviour
{
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
    [NonSerialized]public int unitOrder;

    public void Set(int unitId, int order)
    {
        textName.text = "Hakos Baelz";
        unitOrder = order;
    }

}
