using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : UIInventoryAbstract
{
    private static UIInventory instance;
    public static UIInventory Instance => instance;

    protected bool isOpen = true;
    [SerializeField] protected InventorySort inventorySort = InventorySort.NoSort;

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
        if (this.inventorySort == InventorySort.NoSort) return;
        int itemCount = this.inventoryCtrl.Content.childCount;
        Transform curTransform, nextTransform;
        UIItemInventory curUIItemInv, nextUIItemInv;
        ItemProfileSO curProfile, nextProfile;

        for (int a = 0; a < itemCount - 1; a++)
        {
            bool isSwap = false;
            for (int i = 0; i < itemCount - 1; i++)
            {
                curTransform = this.inventoryCtrl.Content.GetChild(i);
                nextTransform = this.inventoryCtrl.Content.GetChild(i + 1);

                curUIItemInv = curTransform.GetComponent<UIItemInventory>();
                nextUIItemInv = nextTransform.GetComponent<UIItemInventory>();

                curProfile = curUIItemInv.ItemInventory.itemProfile;
                nextProfile = nextUIItemInv.ItemInventory.itemProfile;

                bool canSwap = false;

                switch (this.inventorySort)
                {
                    case InventorySort.ByNameASC:
                        canSwap = string.Compare(curProfile.itemName, nextProfile.itemName) == 1;
                        break;
                    case InventorySort.ByNameDES:
                        canSwap = string.Compare(curProfile.itemName, nextProfile.itemName) == -1;
                        break;
                    case InventorySort.ByCountASC:
                        canSwap = curUIItemInv.ItemInventory.itemCount > nextUIItemInv.ItemInventory.itemCount;
                        break;
                    case InventorySort.ByCountDES:
                        canSwap = curUIItemInv.ItemInventory.itemCount < nextUIItemInv.ItemInventory.itemCount;
                        break;
                }

                if (canSwap)
                {
                    this.SwapUIInvItem(curTransform, nextTransform);
                    isSwap = true;
                }
            }

            if (!isSwap) break;
        }
    }

    protected virtual void SortByName()
    {



        string curName, nextName;
        

    }

    protected virtual void SwapUIInvItem(Transform curTransform, Transform nextTransform)
    {
        int curIndex = curTransform.GetSiblingIndex();
        int nextIndex = nextTransform.GetSiblingIndex();

        curTransform.SetSiblingIndex(nextIndex);
        nextTransform.SetSiblingIndex(curIndex);
    }
}
