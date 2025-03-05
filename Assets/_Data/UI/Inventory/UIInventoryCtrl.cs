using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryCtrl : TienMonoBehaviour
{
    [SerializeField] protected Transform content;
    public Transform Content => content;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadContent();
    }

    protected override void Start()
    {
        base.Start();
        for (int i = 0; i <= 70; i++)
        {
            this.SpawnTest(i);
        }
    }

    protected virtual void SpawnTest(int i)
    {
        Transform uiItem = UIInvItemSpawner.Instance.Spawn(UIInvItemSpawner.normalUIItem, Vector3.zero, Quaternion.identity);
        uiItem.name = "InvItem_" + i.ToString();
        uiItem.localScale = new Vector3(1f, 1f, 1f);
        uiItem.gameObject.SetActive(true);
    }

    protected virtual void LoadContent()
    {
        if (this.content != null) return;
        this.content = transform.Find("Scroll View").Find("Viewport").Find("Content");
        Debug.Log($"{transform.name}: LoadContent", gameObject);
    }
}
