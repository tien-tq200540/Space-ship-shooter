using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarSpawner : Spawner
{
    private static HPBarSpawner instance;
    public static HPBarSpawner Instance => instance;

    public static string HPBar = "HPBar";

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only 1 HPBarSpawner allows to exist");
        else instance = this;
    }
}
