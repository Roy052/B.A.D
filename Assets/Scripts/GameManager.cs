using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton
{
    void Awake()
    {
        DontDestroyOnLoad(this);
        if (gameManager == null)
            gameManager = this;
        else
            Destroy(gameObject);
    }
}
