using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : ScriptableObject, ItemContainer
{
    public ItemSLot AddItem(ItemSLot itemSLot)
    {
        return itemSLot;
    }

    public void RemoveItem(ItemSLot itemSLot)
    {
        return;
    }

    public void RemoveAt(int slotIndex)
    {
        return;
    }

    public void Swap(int indeOne, int indexTwo)
    {
        return;
    }

    public bool HasItem(InventoryItems item)
    {
        return false;
    }

    public int GetTotalQuantity(InventoryItems item)
    {
        return 0;
    }
}
