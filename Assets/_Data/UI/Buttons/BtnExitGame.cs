using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnExitGame : BaseButton
{
    protected override void OnClick()
    {
        Debug.Log("On Click Button Exit");
        Application.Quit();
    }
}
