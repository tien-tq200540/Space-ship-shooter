using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : TienMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    [SerializeField] protected JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn { get => junkDespawn; }

    [SerializeField] protected JunkSO junkSO;
    public JunkSO JunkSO => junkSO;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
        LoadJunkDespawn();
        LoadJunkSO();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log($"{transform.name}: LoadModel", gameObject);
    }

    protected virtual void LoadJunkDespawn()
    {
        if (this.junkDespawn != null) return;
        this.junkDespawn = transform.Find("Despawn").GetComponent<JunkDespawn>();
        Debug.Log($"{transform.name}: LoadJunkDespawn", gameObject);
    }

    protected virtual void LoadJunkSO()
    {
        if (this.junkSO != null) return;
        string resPath = @$"Junk/{transform.name}";
        this.junkSO = Resources.Load<JunkSO>(resPath);
        Debug.Log($"{transform.name}: LoadJunkSO", gameObject);
    }
}
