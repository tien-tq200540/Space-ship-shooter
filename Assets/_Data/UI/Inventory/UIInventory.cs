using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : UIInventoryAbstract
{
    private static UIInventory instance;
    public static UIInventory Instance => instance;

    protected bool isOpen = true;
    [SerializeField] protected InventorySort inventorySort = InventorySort.ByName;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only 1 UIInventory allows to exist!");
        else instance = this;
    }

    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(this.ShowItems), 1f, 1f);
    }

    protected virtual void FixedUpdate()
    {
        //this.ShowItem();
    }

    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (isOpen) Open();
        else Close();
    }

    public virtual void Open()
    {
       this.inventoryCtrl.gameObject.SetActive(true);
        this.isOpen = true;
    }

    public virtual void Close()
    {
        this.inventoryCtrl.gameObject.SetActive(false);
        this.isOpen = false;
    }

    protected virtual void ShowItems()
    {
        if (!this.isOpen) return;
        this.ClearItems();

        List<ItemInventory> items = PlayerCtrl.Instance.CurrentShip.Inventory.Items;
        UIInvItemSpawner spawner = UIInvItemSpawner.Instance;

        foreach (ItemInventory item in items)
        {
            spawner.SpawnUIItem(item);
        }

        this.SortItems();
    }

    protected virtual void ClearItems()
    {
        UIInvItemSpawner.Instance.ClearItems();
    }

    protected virtual void SortItems()
    {
        switch(this.inventorySort)
        {
            case InventorySort.ByName:
                Debug.Log("Sort ByName");
                break;
            case InventorySort.ByCount:
                Debug.Log("Sort ByCount");
                break;
            default:
                Debug.Log("No Sort");
                break;
        }
    }
}
