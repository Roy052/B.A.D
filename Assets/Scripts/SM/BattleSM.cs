using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class BattleSM : MonoBehaviour
{
    public enum GameStatus
    {
        Ready,
        RollDice,
        UseDice,
        ActEnemy,
        CleanUp,
        BattleEnd,
    }

    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject dicePrefab;

    public Button btnRollDice;

    List<DiceInBattle> unUsedDiceList = new List<DiceInBattle>();
    List<DiceInBattle> usedDiceList = new List<DiceInBattle>();
    List<DiceInBattle> currentDiceList = new List<DiceInBattle>();
    List<DiceInBattle> pickedDiceList = new List<DiceInBattle>();

    GameStatus currentStatus;
    bool currentStatusActivated = false;
    System.Random random = new System.Random();

    public void Set(int battleId)
    {
        for(int i = 0; i < 10; i++)
        {
            GameObject temp = Instantiate(dicePrefab, dicePrefab.transform.parent);
            DiceInBattle tempDice = temp.GetComponent<DiceInBattle>();
            unUsedDiceList.Add(tempDice);
        }

        btnRollDice.gameObject.SetActive(true);

        currentStatus++;
        currentStatusActivated = true;

        List<DiceInBattle> shuffledList = unUsedDiceList.OrderBy(x => random.Next()).ToList();
        List<DiceInBattle> randomElements = shuffledList.Take(5).ToList();
        foreach(DiceInBattle element in randomElements)
        {
            unUsedDiceList.Remove(element);
            currentDiceList.Add(element);
        }
    }

    private void Update()
    {
        if (currentStatusActivated) return;

        switch (currentStatus)
        {
            case GameStatus.Ready:
                Set(0);
                break;
            case GameStatus.RollDice:
                break;
            case GameStatus.UseDice:
                break;
            case GameStatus.ActEnemy:
                break;
            case GameStatus.CleanUp:
                break;
            case GameStatus.BattleEnd:
                break;
        }
    }

    public void RollDice()
    {
        foreach (DiceInBattle dice in currentDiceList)
        {
            dice.gameObject.SetActive(true);
            dice.Set(0);
            dice.SetSide(Random.Range(0, 6));
        }
    }

    public void PickDice()
    {

    }
}
