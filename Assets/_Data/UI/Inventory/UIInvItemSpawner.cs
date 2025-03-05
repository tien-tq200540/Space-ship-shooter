using System;
using System.Collections;
using UnityEngine;

public class UIInvItemSpawner : Spawner
{
    private static UIInvItemSpawner instance;
    public static UIInvItemSpawner Instance => instance;

    public static string normalUIItem = "UIInvItem";

    [SerializeField] protected UIInventoryCtrl inventoryCtrl;
    public UIInventoryCtrl UIInventoryCtrl => inventoryCtrl;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only 1 UIInvItemSpawner allows to exist!");
        else instance = this;
    }

    protected virtual void LoadUIInvItemCtrl()
    {
        if (this.inventoryCtrl != null) return;
        this.inventoryCtrl = transform.parent.GetComponent<UIInventoryCtrl>();
        Debug.Log($"{transform.name}: LoadUIInvItemCtrl", gameObject);
    }

    protected override void LoadHolder()
    {
        this.LoadUIInvItemCtrl();

        if (this.holder != null) return;
        this.holder = inventoryCtrl.Content;
        Debug.Log($"{transform.name}: LoadHolder", gameObject);
    }
}
