using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ItemContainer
{
    ItemSLot AddItem(ItemSLot itemSLot);
    
    void RemoveItem(ItemSLot itemSLot);
    
    void RemoveAt(int slotIndex);
    
    void Swap(int indeOne, int indexTwo);
    
    bool HasItem(InventoryItems item);
    
    int GetTotalQuantity(InventoryItems item);


   
}
