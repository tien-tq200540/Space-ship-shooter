using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjApprearing : TienMonoBehaviour
{
    [Header("Obj Apprearing")]
    [SerializeField] protected bool isAppearing = true;
    [SerializeField] protected bool appear = false;
    public bool IsApprearing => isAppearing;
    public bool Appear => appear;

    [SerializeField] protected List<IObjectAppearObserver> observers = new List<IObjectAppearObserver>();

    protected override void Start()
    {
        base.Start();
        OnAppearStart();
    }

    protected virtual void FixedUpdate()
    {
        this.Appearing();
    }

    protected abstract void Appearing();

    protected virtual void ObjAppear()
    {
        this.appear = true;
        this.isAppearing = false;
        OnAppearFinish();
    }

    protected virtual void OnAppearStart()
    {
        foreach (IObjectAppearObserver observer in observers)
        {
            observer.OnAppearStart();
        }
    }

    protected virtual void OnAppearFinish()
    {
        foreach (IObjectAppearObserver observer in observers)
        {
            observer.OnAppearFinish();
        }
    }

    public virtual void AddObserver(IObjectAppearObserver observer)
    {
        this.observers.Add(observer);
    }
}
