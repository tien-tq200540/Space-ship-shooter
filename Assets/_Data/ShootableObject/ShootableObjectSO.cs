using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootableObject", menuName = "SO/ShootableObject")]
public class ShootableObjectSO : ScriptableObject
{
    public string objName = "ShootableObject";
    public ObjectType objectType;
    public int hpMax = 2;
    public List<DropRate> dropList = new();
}
