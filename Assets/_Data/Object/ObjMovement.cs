using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMovement : TienMonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float speed = 0.01f;
    [SerializeField] protected float rotSpeed = 3f;
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

        float timeSpeed = this.rotSpeed * Time.fixedDeltaTime;
        Quaternion targetEuler = Quaternion.Euler(0f, 0f, rot_z);
        Quaternion currentEuler = Quaternion.Lerp(transform.parent.rotation, targetEuler, timeSpeed);

        transform.parent.rotation = currentEuler;
    }

    protected virtual void Moving()
    {
        this.distance = Vector3.Distance(this.transform.position, this.targetPosition);
        if (this.distance < minDistance) return;

        Vector3 newPos = Vector3.Lerp(transform.parent.position, this.targetPosition, speed);
        transform.parent.position = newPos;
    }
}
