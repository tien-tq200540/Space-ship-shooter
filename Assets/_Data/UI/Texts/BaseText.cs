using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseText : TienMonoBehaviour
{
    [Header("Base Text")]
    [SerializeField] protected TMPro.TMP_Text text;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadText();
    }

    protected virtual void LoadText()
    {
        if (this.text != null) return;
        this.text = GetComponent<TMPro.TMP_Text>();
        Debug.Log($"{transform.name}: LoadText", gameObject);
    }
}
