using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : Singleton
{
    const int MinX = -260;
    const int MinY = -220;
    const int MaxX = 260;
    const int MaxY = 220;

    public GridLayoutGroup enemyDiceLayout;

    public GameObject enemyHeroPrefab;
    public GameObject enemyDicePrefab;

    List<HeroInBattle> enemyHeroList = new List<HeroInBattle>();
    List<DiceInBattle> enemyDiceList = new List<DiceInBattle>();

    public void Set()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject temp = Instantiate(enemyHeroPrefab, enemyHeroPrefab.transform.parent);
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
            enemyDiceList.Add(tempDice);
        }
    }

    public void PrepareEnemy()
    {
        for (int i = 0; i < enemyDiceList.Count; i++)
        {
            DiceInBattle dice = enemyDiceList[i];
            dice.gameObject.SetActive(true);
            dice.SetSide(Random.Range(0, 6));
        }

        StartCoroutine(_RollDiceAndSelectDice());
    }

    IEnumerator _RollDiceAndSelectDice()
    {
        yield return null;

        enemyDiceLayout.gameObject.SetActive(true);
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

        yield return new WaitForSeconds(0.2f);
        enemyDiceLayout.enabled = true;
        yield return new WaitForSeconds(1);
        enemyDiceLayout.enabled = false;

        for(int i = 0; i < 2; i++)
        {
            var diceInfo = enemyDiceList[i].GetDiceInfo();
            enemyHeroList[i].SetDice(diceInfo);
            enemyDiceList[i].gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }

        for(int i = 0; i < 2; i++)
        {
            enemyDiceList[i].gameObject.SetActive(false);
        }

        enemyDiceLayout.gameObject.SetActive(false);
        battleSM.currentStatusActivated = false;
    }
}
