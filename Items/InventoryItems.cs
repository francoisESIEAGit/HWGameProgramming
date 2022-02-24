using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryItems : HotBarItem
{
    [Header("Item Data")]
    [Min(0)] private int maxStack = 1;

    public override string ColouredName
    { get { return Name; } }
    public int MaxStack => maxStack;



}
