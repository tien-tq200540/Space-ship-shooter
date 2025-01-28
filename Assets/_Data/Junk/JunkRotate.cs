using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRotate : JunkAbstract
{
    [SerializeField] protected float speed = 9f;

    private void FixedUpdate()
    {
        this.JunkCtrl.Model.Rotate(new Vector3(0f, 0f, 1f) * speed * Time.fixedDeltaTime);
    }
}
