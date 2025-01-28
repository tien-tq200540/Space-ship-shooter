using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : TienMonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected Transform target;

    private void FixedUpdate()
    {
        this.Following();
    }

    protected virtual void Following()
    {
        if (this.target == null) return;
        transform.position = Vector3.Lerp(this.transform.position, target.position, speed * Time.fixedDeltaTime);
    }
}
