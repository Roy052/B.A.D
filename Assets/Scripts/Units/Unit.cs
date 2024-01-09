using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    int atk;
    int def;
    int health;

    public void Set(int atk, int def, int health)
    {
        this.atk = atk;
        this.def = def;
        this.health = health;
    }
}
