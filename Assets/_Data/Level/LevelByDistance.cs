using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelByDistance : Level
{
    [Header("By Distance")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance;
    [SerializeField] protected float distancePerLevel = 10f;

    protected virtual void FixedUpdate()
    {
        this.Leveling();
    }

    protected virtual void Leveling()
    {
        if (this.target == null) return;
        this.distance = Vector3.Distance(transform.position, target.position);
        int newLevel = GetLevelByDistance();
        this.LevelSet(newLevel);
    }

    protected virtual int GetLevelByDistance()
    {
        return Mathf.FloorToInt(distance / distancePerLevel);
    }

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
}
