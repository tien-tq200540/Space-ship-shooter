using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPressAlpha : TienMonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        this.CheckAlphaIsPress();
    }

    protected virtual void CheckAlphaIsPress()
    {
        if (InputHotKeyManager.Instance.isPressAlpha1) Debug.Log("Press 1");
        if (InputHotKeyManager.Instance.isPressAlpha2) Debug.Log("Press 2");
        if (InputHotKeyManager.Instance.isPressAlpha3) Debug.Log("Press 3");
        if (InputHotKeyManager.Instance.isPressAlpha4) Debug.Log("Press 4");
        if (InputHotKeyManager.Instance.isPressAlpha5) Debug.Log("Press 5");
        if (InputHotKeyManager.Instance.isPressAlpha6) Debug.Log("Press 6");
        if (InputHotKeyManager.Instance.isPressAlpha7) Debug.Log("Press 7");
    }
}
