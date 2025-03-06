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

    public virtual void ClearItems()
    {
        foreach(Transform item in this.holder)
        {
            this.Despawn(item);
        }
    }

    public virtual void SpawnUIItem(ItemInventory item)
    {
        Transform uiItem = Spawn(normalUIItem, Vector3.zero, Quaternion.identity);
        UIItemInventory uIItemInventory = uiItem.GetComponent<UIItemInventory>();
        uIItemInventory.ShowItem(item);

        uiItem.localScale = new Vector3(1f, 1f, 1f);
        uiItem.gameObject.SetActive(true);
    }
}
