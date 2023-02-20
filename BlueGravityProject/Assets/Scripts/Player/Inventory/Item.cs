using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Head,
        Body,
    }

    public ItemType itemType;
    public int amount;
    public int price;
}
