using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : TienMonoBehaviour
{
    private static PlayerCtrl instance;
    public static PlayerCtrl Instance => instance;

    [SerializeField] protected ShipCtrl currentShip;
    public ShipCtrl CurrentShip => currentShip;

    [SerializeField] protected PlayerPickable playerPickable;
    public PlayerPickable PlayerPickable => playerPickable;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only 1 PlayerCtrl allow to exist!");
        instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerPickable();
    }

    protected virtual void LoadPlayerPickable()
    {
        if (this.playerPickable != null) return;
        this.playerPickable = GetComponentInChildren<PlayerPickable>();
        Debug.Log($"{transform.name}: LoadPlayerPickable", gameObject);
    }
}
