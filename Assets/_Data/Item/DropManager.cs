using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : TienMonoBehaviour
{
    private static DropManager instance;
    public static DropManager Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only 1 DropManager allow to exist!");
        instance = this;
    }

    public virtual void Drop(List<DropRate> dropList)
    {
        Debug.Log(dropList[0].item.itemName);
    }
}
