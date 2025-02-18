using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMovement : TienMonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float speed = 0.01f;
    [SerializeField] protected float distance = 1f;
    [SerializeField] protected float minDistance = 1f;
    protected virtual void FixedUpdate()
    {
        this.Moving();
    }

    public virtual void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    protected virtual void Moving()
    {
        this.distance = Vector3.Distance(this.transform.position, this.targetPosition);
        if (this.distance < minDistance) return;

        Vector3 newPos = Vector3.Lerp(transform.parent.position, this.targetPosition, speed);
        transform.parent.position = newPos;
    }
}
