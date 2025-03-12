using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressable : TienMonoBehaviour
{
    public virtual void Pressed()
    {
        Debug.Log($"Slot {transform.parent.parent} is pressed!");
    }
}
