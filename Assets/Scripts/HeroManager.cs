using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManager : Singleton
{
    public GameObject playerPrefab;

    List<HeroInBattle> heroList = new List<HeroInBattle>();

    public void Set()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject temp = Instantiate(playerPrefab, playerPrefab.transform.parent);
            HeroInBattle tempHero = temp.GetComponent<HeroInBattle>();
            heroList.Add(tempHero);
        }
    }
}
