using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton
{
    const int MinX = -260;
    const int MinY = -220;
    const int MaxX = 260;
    const int MaxY = 220;

    public GridLayout enemyDiceLayout;

    public GameObject enemyPrefab;
    public GameObject enemyDicePrefab;

    List<HeroInBattle> enemyHeroList = new List<HeroInBattle>();
    List<DiceInBattle> enemyDiceList = new List<DiceInBattle>();

    public void Set()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject temp = Instantiate(enemyPrefab, enemyPrefab.transform.parent);
            HeroInBattle tempHero = temp.GetComponent<HeroInBattle>();
            tempHero.Set(0, i);
            enemyHeroList.Add(tempHero);
            temp.SetActive(true);
        }

        for(int i = 0; i < 2; i++)
        {
            GameObject temp = Instantiate(enemyDicePrefab, enemyDicePrefab.transform.parent);
            DiceInBattle tempDice = temp.GetComponent<DiceInBattle>();
            tempDice.Set(0, i);
        }
    }

    public void PrepareEnemy()
    {
        for (int i = 0; i < enemyDiceList.Count; i++)
        {
            DiceInBattle dice = enemyDiceList[i];
            dice.gameObject.SetActive(true);
            dice.Set(0, i);
            dice.SetSide(Random.Range(0, 6));
        }

        StartCoroutine(_RollDice());
    }

    IEnumerator _RollDice()
    {
        yield return null;
        List<Vector2> randomPoints = new List<Vector2>();
        for (int i = 0; i < 2; i++)
        {
            bool overlayed = true;
            Vector2 tempVec = Vector2.zero;
            while (overlayed)
            {
                overlayed = false;
                tempVec = new Vector2(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY));
                for (int j = 0; j < i; j++)
                {
                    if (Vector2.Distance(randomPoints[j], tempVec) <= 150)
                    {
                        overlayed = true;
                        break;
                    }
                }
            }


            randomPoints.Add(tempVec);
        }
        float currentTime = 0;

        enemyDiceLayout.enabled = false;
        while (currentTime < 1)
        {
            for (int i = 0; i < 2; i++)
            {
                RectTransform temp = enemyDiceList[i].transform as RectTransform;
                temp.anchoredPosition = Vector2.Lerp(temp.anchoredPosition, randomPoints[i], currentTime);
            }
            currentTime += Time.deltaTime;
            yield return null;
        }

        enemyDiceLayout.enabled = true;

        battleSM.currentStatusActivated = false;
    }
}
