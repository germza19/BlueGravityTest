using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> itemsList;

    public Inventory()
    {
        itemsList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.Head, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Head, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Body, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Body, amount = 1 });
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
