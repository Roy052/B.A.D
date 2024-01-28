using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class BattleSM : MonoBehaviour
{
    const int MinX = -640;
    const int MinY = -450;
    const int MaxX = 640;
    const int MaxY = 450;

    public enum GameStatus
    {
        BattleStart,
        PrepareEnemy,
        PickDice,
        RollDice,
        PlayDice,
        ActEnemy,
        CleanUp,
        BattleEnd,
    }

    public Button btnRollDice;

    public DiceManager diceMgr;
    public HeroManager heroMgr;
    public EnemyManager enemyMgr;

    public GridLayoutGroup diceGrid;

    List<UnitInBattle> unitList = new List<UnitInBattle>();


    GameStatus currentStatus;
    bool currentStatusActivated = false;

    private void Update()
    {
        if (currentStatusActivated) return;
        currentStatusActivated = true;
        Invoke($"Set{currentStatus}", 0);
    }

    public void SetBattleStart()
    {
        currentStatus++;
        diceMgr.Set(0);
        heroMgr.Set();
        currentStatusActivated = false;
    }

    public void SetPrepareEnemy()
    {
        currentStatus++;
        enemyMgr.Set();
        currentStatusActivated = false;
    }

    public void SetPickDice()
    {
        currentStatus++;
        diceMgr.PickDice();
        currentStatusActivated = false;
    }

    public void SetRollDice()
    {
        diceMgr.RollDice();
        StartCoroutine(_SetRollDice());
    }

    IEnumerator _SetRollDice()
    {
        yield return null;
        List<Vector2> randomPoints = new List<Vector2>();
        for(int i = 0; i < 5; i++)
            randomPoints.Add(new Vector2(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY)));
        float currentTime = 0;

        diceGrid.enabled = false;
        while(currentTime < 1)
        {
            for(int i = 0; i < 5; i++)
            {
                RectTransform temp = diceMgr.GetCurrentDiceRect(i);
                temp.anchoredPosition = Vector2.Lerp(temp.anchoredPosition, randomPoints[i], currentTime);
            }
            currentTime += Time.deltaTime;
            yield return null;
        }

        diceGrid.enabled = true;
    }

    public void SetPlayDice()
    {

    }

    public void SetActEnemy()
    {

    }

    public void SetCleanUp()
    {

    }

    public void SetBattleEnd()
    {

    }
}
