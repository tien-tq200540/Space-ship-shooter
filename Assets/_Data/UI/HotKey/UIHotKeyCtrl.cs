using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHotKeyCtrl : TienMonoBehaviour
{
    private static UIHotKeyCtrl instance;
    public static UIHotKeyCtrl Instance => instance;

    public List<ItemSlot> itemSlots = new();

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only 1 UIHotKeyCtrl allows to exist!");
        else instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemSlots();
    }

    protected virtual void LoadItemSlots()
    {
        if (this.itemSlots.Count > 0) return;

        ItemSlot[] itemSlots = GetComponentsInChildren<ItemSlot>();
        this.itemSlots.AddRange(itemSlots);
        /*
        Transform grid = transform.Find("Grid");
        foreach (Transform child in grid)
        {
            ItemDrop itemDrop = child.GetComponent<ItemDrop>();
            this.itemSlots.Add(itemDrop);
        }*/
        Debug.Log($"{transform.name}: LoadItemSlots", gameObject);
    }
}
