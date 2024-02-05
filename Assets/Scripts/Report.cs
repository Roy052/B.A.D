using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class Report
{
    public static UnityAction<int> PickHeroInRollSelectDice;
    public static UnityAction<int> PickDiceInRollSelectDice;
    public static UnityAction ReleaseHeroInRollSelectDice;
    public static UnityAction ReleaseDiceInRollSelectDice;
}
