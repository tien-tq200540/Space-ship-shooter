using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSlider : TienMonoBehaviour
{
    [Header("Base Silder")]
    [SerializeField] protected Slider slider;

    protected override void Start()
    {
        base.Start();
        this.AddOnChangedEvent();
    }

    protected virtual void FixedUpdate()
    {
        //For override
    }

    protected virtual void AddOnChangedEvent()
    {
        this.slider.onValueChanged.AddListener(this.OnChanged);
    }

    protected abstract void OnChanged(float newValue);

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
    }

    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        slider = GetComponent<Slider>();
        Debug.Log($"{transform.name}: LoadSlider", gameObject);
    }
}
