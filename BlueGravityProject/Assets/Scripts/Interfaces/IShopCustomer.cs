using System.Collections;
using System.Collections.Generic;
using Test.Player.InventorySystem;
using UnityEngine;

public interface IShopCustomer
{
    void BoughtItem(Item.ItemType itemType);
    void SelledItem(Item.ItemType itemType);
    bool TrySpendGoldAmount(int goldAmount);
    void SellItem(int goldAmount);
}
