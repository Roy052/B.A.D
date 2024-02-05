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
        currentStatusActivated = true;
        Invoke($"Set{currentStatus}", 0);
        currentStatus++;
    }

    public void SetBattleStart()
    {
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
        heroMgr.diceMgr.PickDice();
        currentStatusActivated = false;
    }

    public void SetRollSelectDice()
    {
        heroMgr.diceMgr.RollDice();
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
