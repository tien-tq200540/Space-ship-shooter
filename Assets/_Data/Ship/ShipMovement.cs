using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : TienMonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float speed = 0.01f;
    [SerializeField] protected float distance = 1f;
    [SerializeField] protected float minDistance = 1f;
    protected virtual void FixedUpdate()
    {
        this.LookAtTarget();
        this.Moving();
    }

    protected virtual void LookAtTarget()
    {
        Vector3 diff = this.targetPosition - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }

    protected virtual void Moving()
    {
        this.distance = Vector3.Distance(this.transform.position, this.targetPosition);
        if (this.distance < minDistance) return;

        Vector3 newPos = Vector3.Lerp(transform.parent.position, this.targetPosition, speed);
        transform.parent.position = newPos;
    }
}
