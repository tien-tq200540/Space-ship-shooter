using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjShooting : TienMonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 0.2f;
    [SerializeField] protected float shootTimer = 0f;

    private void Update()
    {
        this.IsShooting();
    }

    private void FixedUpdate()
    {
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        if (!this.isShooting) return;

        this.shootTimer += Time.fixedDeltaTime;
        if (this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0f;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;

        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, spawnPos, rotation);
        if (newBullet == null) return;

        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.Shooter = this.transform.parent;
        newBullet.gameObject.SetActive(true);
    }

    protected abstract bool IsShooting();
}
