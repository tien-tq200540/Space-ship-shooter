using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLookAtTarget : TienMonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float rotSpeed = 3f;
    protected virtual void FixedUpdate()
    {
        this.LookAtTarget();
    }

    public virtual void SetRotSpeed(float rotSpeed)
    {
        this.rotSpeed = rotSpeed;
    }

    protected virtual void LookAtTarget()
    {
        Vector3 diff = this.targetPosition - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        float timeSpeed = this.rotSpeed * Time.fixedDeltaTime;
        Quaternion targetEuler = Quaternion.Euler(0f, 0f, rot_z);
        Quaternion currentEuler = Quaternion.Lerp(transform.parent.rotation, targetEuler, timeSpeed);

        transform.parent.rotation = currentEuler;
    }
}
