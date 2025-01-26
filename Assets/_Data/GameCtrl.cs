using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameCtrl : TienMonoBehaviour
{
    private static GameCtrl instance;
    public static GameCtrl Instance { get => instance; }

    [SerializeField] protected Transform mainCamera;
    public Transform MainCamera { get => mainCamera; }

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only 1 GameCtrl allow to exist!");
        instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadMainCamera();
    }

    protected virtual void LoadMainCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = Transform.FindObjectOfType<Camera>().transform;
        Debug.Log($"{transform.name}: LoadMainCamera", gameObject);
    }
}
