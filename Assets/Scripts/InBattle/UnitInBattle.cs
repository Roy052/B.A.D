using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitInBattle : MonoBehaviour
{
    public Image imgPortrait;
    public Text textName;
    public Text textAtk;
    public Text textDef;
    public RectTransform gauge;
    public Text textHealth;

    public GameObject magicPrefab;

    int maxHealth;
    int health;

    public void Set(int unitId)
    {

    }
}
