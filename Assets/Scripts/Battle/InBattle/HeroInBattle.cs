using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeroInBattle : UnitInBattle
{
    public GameObject ultimatePrefab;

    public UnityAction<int> pickUnit;
    public UnityAction releaseUnit;

    bool isPicked = false;

    public void OnClickHero()
    {
        if(isPicked)
        {
            releaseUnit?.Invoke();
            return;
        }

        pickUnit?.Invoke(unitOrder);
    }
}
