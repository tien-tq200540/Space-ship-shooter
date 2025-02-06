using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class DropRate
{
    public ItemProfileSO itemSO; //information about item
    //Information about item drop stats
    public int dropRate;
    public int minDrop;
    public int maxDrop;
}
