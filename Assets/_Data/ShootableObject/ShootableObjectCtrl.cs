using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjectCtrl : TienMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected Despawn despawn;
    public Despawn Despawn => despawn;

    [SerializeField] protected ShootableObjectSO shootableObjectSO;
    public ShootableObjectSO ShootableObjectSO => shootableObjectSO;

    [SerializeField] protected ObjShooting objShooting;
    public ObjShooting ObjShooting => objShooting;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
        LoadDespawn();
        LoadSO();
        LoadObjShooting();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log($"{transform.name}: LoadModel", gameObject);
    }

    protected virtual void LoadObjShooting()
    {
        if (this.objShooting != null) return;
        this.objShooting = GetComponentInChildren<ObjShooting>();
        Debug.Log($"{transform.name}: LoadObjShooting", gameObject);
    }

    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.GetComponentInChildren<Despawn>();
        Debug.Log($"{transform.name}: LoadDespawn", gameObject);
    }

    protected virtual void LoadSO()
    {
        if (this.shootableObjectSO != null) return;
        string resPath = @$"ShootableObject/{this.GetObjectTypeString()}/{transform.name}";
        this.shootableObjectSO = Resources.Load<ShootableObjectSO>(resPath);
        Debug.Log($"{transform.name}: LoadJunkSO", gameObject);
    }

    protected abstract string GetObjectTypeString();
}
