using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroManager : Singleton
{
    public GameObject playerPrefab;

    public VerticalLayoutGroup heroLayout;

    List<HeroInBattle> heroList = new List<HeroInBattle>();

    public void Set()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject temp = Instantiate(playerPrefab, playerPrefab.transform.parent);
            HeroInBattle tempHero = temp.GetComponent<HeroInBattle>();
            heroList.Add(tempHero);
            temp.SetActive(true);
            tempHero.pickUnit = PickUnit;
        }
    }

    public void MoveSelectableHeroes()
    {

    }

    void PickUnitDice() 
    {

    }

    void PickUnit(int heroOrder)
    {
        var diceInfo = battleSM.diceMgr.GetPickedDice();
        if (diceInfo.Item1 == -1) return;
        heroList[heroOrder].SetDice(diceInfo.Item1, diceInfo.Item2);
        ;
    }
}
