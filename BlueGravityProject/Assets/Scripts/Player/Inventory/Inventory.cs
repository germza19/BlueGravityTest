using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test.Player.InventorySystem
{
    public class Inventory
    {
        private List<Item> itemsList;

        public Inventory()
        {
            itemsList = new List<Item>();

            AddItem(new Item { itemBodyPart = Item.ItemBodyPart.head, itemType = Item.ItemType.skullHead, amount = 1 });
            AddItem(new Item { itemBodyPart = Item.ItemBodyPart.body, itemType = Item.ItemType.samuraiBody, amount = 1 });
            AddItem(new Item { itemBodyPart = Item.ItemBodyPart.head, itemType = Item.ItemType.soldierHead, amount = 1 });
            AddItem(new Item { itemBodyPart = Item.ItemBodyPart.body, itemType = Item.ItemType.farmerBody, amount = 1 });
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
