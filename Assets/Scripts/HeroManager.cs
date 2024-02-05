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

    int currentHeroOrder;
    int currentDiceOrder;
    public void Set()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject temp = Instantiate(heroPrefab, heroPrefab.transform.parent);
            HeroInBattle tempHero = temp.GetComponent<HeroInBattle>();
            heroList.Add(tempHero);
            temp.SetActive(true);
            tempHero.pickUnit = PickUnit;
        }

        diceMgr.Set();
        Report.PickDiceInRollSelectDice = PickDice;
    }

    public void MoveSelectableHeroes()
    {

    }

    void PickDice(int diceOrder) 
    {
        currentDiceOrder = diceOrder;
        if(currentHeroOrder != -1 && currentHeroOrder != -1)
        {
            var diceInfo = diceMgr.GetDice(currentDiceOrder);
            heroList[currentHeroOrder].SetDice(diceInfo.Item1, diceInfo.Item2);
        }
    }

    void PickUnit(int heroOrder)
    {
        currentHeroOrder = heroOrder;
        if(currentHeroOrder != -1 && currentDiceOrder != -1)
        {
            var diceInfo = diceMgr.GetDice(currentDiceOrder);
            heroList[currentHeroOrder].SetDice(diceInfo.Item1, diceInfo.Item2);
        }
    }

    void ReleaseDice()
    {

    }
}
