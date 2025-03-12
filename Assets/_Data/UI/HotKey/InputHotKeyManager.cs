using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHotKeyManager : MonoBehaviour
{
    private static InputHotKeyManager instance;
    public static InputHotKeyManager Instance => instance;

    public bool isPressAlpha1 = false;
    public bool isPressAlpha2 = false;
    public bool isPressAlpha3 = false;
    public bool isPressAlpha4 = false;
    public bool isPressAlpha5 = false;
    public bool isPressAlpha6 = false;
    public bool isPressAlpha7 = false;

    private void Awake()
    {
        if (instance != null) Debug.LogError("Only 1 InputHotKey allows to exist");
        else instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        this.GetHotKeyPress();
    }

    protected virtual void GetHotKeyPress()
    {
        isPressAlpha1 = Input.GetKeyDown(KeyCode.Alpha1);
        isPressAlpha2 = Input.GetKeyDown(KeyCode.Alpha2);
        isPressAlpha3 = Input.GetKeyDown(KeyCode.Alpha3);
        isPressAlpha4 = Input.GetKeyDown(KeyCode.Alpha4);
        isPressAlpha5 = Input.GetKeyDown(KeyCode.Alpha5);
        isPressAlpha6 = Input.GetKeyDown(KeyCode.Alpha6);
        isPressAlpha7 = Input.GetKeyDown(KeyCode.Alpha7);
    }
}
