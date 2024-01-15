using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : Singleton
{
    const string path = "Arts/Sides";
    public List<Sprite> diceSprites = new List<Sprite>();

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (resourceManager == null)
            resourceManager = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        SetResources();
    }

    void SetResources()
    {
        foreach (Sprite side in Resources.LoadAll(path, typeof(Sprite)))
            diceSprites.Add(side);
    }
}
