using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : TienMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log($"{transform.name}: LoadModel", gameObject);
    }
}
