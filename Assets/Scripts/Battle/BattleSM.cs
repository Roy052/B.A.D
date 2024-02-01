using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class BattleSM : Singleton
{
    
    public enum GameStatus
    {
        BattleStart,
        PrepareEnemy,
        PickDice,
        RollSelectDice,
        PlayDice,
        ActEnemy,
        CleanUp,
        BattleEnd,
    }

    public Button btnRollDice;
    public Button btnEndRollDice;

    public DiceManager diceMgr;
    public HeroManager heroMgr;
    public EnemyManager enemyMgr;

    GameStatus currentStatus;
    public bool currentStatusActivated = false;

    private void Awake()
    {
        if (battleSM == null)
            battleSM = this;
        else
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        battleSM = null;
    }

    private void Update()
    {
        if (currentStatusActivated) return;
        currentStatus++;
        currentStatusActivated = true;
        Invoke($"Set{currentStatus}", 0);
    }

    public void SetBattleStart()
    {
        diceMgr.Set();
        heroMgr.Set();
        enemyMgr.Set();
        currentStatusActivated = false;
    }

    public void SetPrepareEnemy()
    {
        enemyMgr.PrepareEnemy();
    }

    public void SetPickDice()
    {
        diceMgr.PickDice();
        currentStatusActivated = false;
    }

    public void SetRollSelectDice()
    {
        diceMgr.RollDice();
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

    public void OnEndRollDice()
    {
        currentStatusActivated = false;
    }

    void RefreshUI()
    {
        btnRollDice.gameObject.SetActive(currentStatus == GameStatus.RollSelectDice);
        btnEndRollDice.gameObject.SetActive(currentStatus == GameStatus.RollSelectDice);
    }
}
