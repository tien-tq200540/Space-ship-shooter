using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;
using UnityEngine;

public class TienMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        LoadComponents();
    }

    protected virtual void Reset()
    {
        LoadComponents();
        ResetValue();
    }

    protected virtual void Start()
    {
        //For override
    }

    protected virtual void OnEnable()
    {
        //For override
    }

    protected virtual void LoadComponents()
    {
        //For override
    }

    protected virtual void ResetValue()
    {
        //For override
    }
}
