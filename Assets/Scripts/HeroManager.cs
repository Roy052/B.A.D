using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroManager : Singleton
{
    public GameObject heroPrefab;

    public VerticalLayoutGroup heroLayout;

    public DiceManager diceMgr;

    List<HeroInBattle> heroList = new List<HeroInBattle>();

    int currentHeroIdx = -1;
    int currentDiceIdx = -1;
    public void Set()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject temp = Instantiate(heroPrefab, heroPrefab.transform.parent);
            HeroInBattle tempHero = temp.GetComponent<HeroInBattle>();
            heroList.Add(tempHero);
            temp.SetActive(true);
            tempHero.Set(0, i);
            tempHero.pickUnit = PickUnit;
        }

        diceMgr.Set();
        Report.PickDiceInRollSelectDice = PickDice;
    }

    public void MoveSelectableHeroes()
    {

    }

    void PickDice(int idx) 
    {
        currentDiceIdx = idx;
        if (currentHeroIdx != -1 && currentHeroIdx != -1)
            SetDiceToUnit();
    }

    void PickUnit(int heroOrder)
    {
        currentHeroIdx = heroOrder;
        if (currentHeroIdx != -1 && currentDiceIdx != -1)
            SetDiceToUnit();
    }

    void SetDiceToUnit()
    {
        var diceInfo = diceMgr.GetDice(currentDiceIdx);
        heroList[currentHeroIdx].SetDice(diceInfo);
        heroList[currentHeroIdx].releaseDice = ReleaseDice;
        currentHeroIdx = -1;
        currentDiceIdx = -1;
        diceMgr.SetDiceActive(diceInfo.idx, false);
    }

    void ReleaseDice(int unitIdx,int diceIdx)
    {
        var diceInfo = diceMgr.GetDice(diceIdx);
        diceMgr.SetDiceActive(diceInfo.idx, true);
    }

    void CleanUp()
    {
        currentHeroIdx = -1;
        currentDiceIdx = -1;
        diceMgr.CleanUp();
    }
}
