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

            AddItem(new Item 
            { 
                itemBodyPart = Item.ItemBodyPart.head,
                itemType = Item.ItemType.farmerHead,
                amount = 1,
                isOnIventory = true,
                headIndexInPlayer = 0
            });
            AddItem(new Item 
            { 
                itemBodyPart = Item.ItemBodyPart.body,
                itemType = Item.ItemType.farmerBody,
                amount = 1,
                isOnIventory = true,
                bodyIndexInPlayer = 0
            });

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
                item.amount = 1;
                itemsList.Add(item);
            }            
            OnItemListChanged?.Invoke(this,EventArgs.Empty);
        }

        public void RemoveItem(Item item)
        {
            int headItemsOnList = 0;
            int bodyItemsOnList = 0;

            foreach (Item inventoryItem in itemsList)
            {
                if (inventoryItem.itemBodyPart == Item.ItemBodyPart.head)
                {
                    headItemsOnList++;
                }
                if (inventoryItem.itemBodyPart == Item.ItemBodyPart.body)
                {
                    bodyItemsOnList ++;
                }
            }
            if((item.itemBodyPart == Item.ItemBodyPart.head && headItemsOnList <= 1) || (item.itemBodyPart == Item.ItemBodyPart.body && bodyItemsOnList <= 1))
            {
                return;
            }
            else
            {
                item.amount = 0;
                item.SetOninventary(false);
                itemsList.Remove(item);
                OnItemListChanged?.Invoke(this, EventArgs.Empty);
            }

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
        public void EquipItem(PlayerManager playerManager,Item item)
        {
            if(playerManager.StateMachine.CurrentState != playerManager.TalkState)
            {
                if (item.itemBodyPart == Item.ItemBodyPart.body)
                {
                    playerManager.AppearanceController.SetBodyIdex(item.bodyIndexInPlayer);
                }
                else if (item.itemBodyPart == Item.ItemBodyPart.head)
                {
                    playerManager.AppearanceController.SetHeadIndex(item.headIndexInPlayer);
                }
            }

        }

        public List<Item> GetItemList()
        {
            return itemsList;
        }
    }

}
