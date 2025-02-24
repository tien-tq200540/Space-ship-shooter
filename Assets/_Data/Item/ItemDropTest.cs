using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropTest : TienMonoBehaviour
{
    public JunkCtrl junkCtrl;

    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(this.Dropping), 2, 0.5f);
    }

    protected virtual void Dropping()
    {
        transform.GetPositionAndRotation(out Vector3 dropPos, out Quaternion dropRot);
        ItemDropSpawner.Instance.Drop(this.junkCtrl.ShootableObjectSO.dropList, dropPos, dropRot);
    }
}
