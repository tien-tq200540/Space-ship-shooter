using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectApprearWithoutShoot : ShootableObjectAbstract, IObjectAppearObserver
{
    [Header("Appear Without Shoot")]
    [SerializeField] protected ObjApprearing objApprearing;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadObjAppearing();
    }

    protected virtual void LoadObjAppearing()
    {
        if (this.objApprearing != null) return;
        this.objApprearing = GetComponent<ObjApprearing>();
        Debug.Log($"{transform.name}: LoadObjAppearing", gameObject);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        objApprearing.AddObserver(this);
    }

    public void OnAppearFinish()
    {
        this.shootableObjectCtrl.ObjShooting.gameObject.SetActive(true);
        this.shootableObjectCtrl.ObjLookAtTarget.gameObject.SetActive(true);
    }

    public void OnAppearStart()
    {
        this.shootableObjectCtrl.ObjShooting.gameObject.SetActive(false);
        this.shootableObjectCtrl.ObjLookAtTarget.gameObject.SetActive(false);
    }
}
