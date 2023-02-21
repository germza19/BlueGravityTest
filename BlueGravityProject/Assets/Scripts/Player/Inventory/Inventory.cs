using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test.Player.InventorySystem
{
    public class Inventory
    {
        public event EventHandler OnItemListChanged;
        private List<Item> itemsList;

        public Inventory()
        {
            itemsList = new List<Item>();

            AddItem(new Item { itemBodyPart = Item.ItemBodyPart.head, itemType = Item.ItemType.farmerHead, amount = 1, isOnIventory = true });
            AddItem(new Item { itemBodyPart = Item.ItemBodyPart.body, itemType = Item.ItemType.farmerBody, amount = 1, isOnIventory = true });
            //AddItem(new Item { itemBodyPart = Item.ItemBodyPart.head, itemType = Item.ItemType.soldierHead, amount = 1 });
            //AddItem(new Item { itemBodyPart = Item.ItemBodyPart.body, itemType = Item.ItemType.farmerBody, amount = 1 });
            Debug.Log(itemsList.Count);
        }

        public void AddItem(Item item)
        {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in itemsList)
            {
                if(inventoryItem.itemType == item.itemType)
                {
                    itemAlreadyInInventory = true;
                }
            }
            if(!itemAlreadyInInventory)
            {
                itemsList.Add(item);
            }            
            OnItemListChanged?.Invoke(this,EventArgs.Empty);
        }

        public void RemoveItem(Item item)
        {
            item.SetOninventary(false);
            itemsList.Remove(item);
            OnItemListChanged?.Invoke(this, EventArgs.Empty);
            //Item itemInInventory = null;
            //foreach (Item inventoryItem in itemsList)
            //{
            //    if (inventoryItem.itemType == item.itemType)
            //    {
            //        inventoryItem.amount--;
            //        itemInInventory = inventoryItem;
            //    }
            //}
            //if (itemInInventory != null && itemInInventory.amount <= 0)
            //{
            //    itemsList.Remove(item);
            //}
        }

        public List<Item> GetItemList()
        {
            return itemsList;
        }
    }

}
