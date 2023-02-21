using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Test.Player.InventorySystem;
using JetBrains.Annotations;

namespace Test.ShopSystem
{
    public class ShopStock
    {
        private List<Item> itemsList;

        public ShopStock()
        {
            itemsList = new List<Item>();

            AddItem(new Item { itemBodyPart = Item.ItemBodyPart.head, itemType = Item.ItemType.farmerHead, amount = 0, isOnIventory = false });
            AddItem(new Item { itemBodyPart = Item.ItemBodyPart.head, itemType = Item.ItemType.samuraiHead, amount = 0, isOnIventory = false });
            AddItem(new Item { itemBodyPart = Item.ItemBodyPart.head, itemType = Item.ItemType.skullHead, amount = 0, isOnIventory = false });
            AddItem(new Item { itemBodyPart = Item.ItemBodyPart.head, itemType = Item.ItemType.soldierHead, amount = 0, isOnIventory = false });
            AddItem(new Item { itemBodyPart = Item.ItemBodyPart.body, itemType = Item.ItemType.farmerBody, amount = 0, isOnIventory = false });
            AddItem(new Item { itemBodyPart = Item.ItemBodyPart.body, itemType = Item.ItemType.samuraiBody, amount = 0, isOnIventory = false });
            AddItem(new Item { itemBodyPart = Item.ItemBodyPart.body, itemType = Item.ItemType.skullBody, amount = 0, isOnIventory = false });
            AddItem(new Item { itemBodyPart = Item.ItemBodyPart.body, itemType = Item.ItemType.soldierBody, amount = 0,isOnIventory = false });
            Debug.Log(itemsList.Count);
        }

        public void AddItem(Item item)
        {
            itemsList.Add(item);
        }

        public List<Item> GetItemList()
        {
            return itemsList;
        }
    }

}
