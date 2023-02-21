using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test.Player.InventorySystem
{
    [Serializable]
    public class Item
    {
        public enum ItemBodyPart
        {
            head,
            body,
        }
        public enum ItemType
        {
            farmerHead,
            farmerBody,
            samuraiHead,
            samuraiBody,
            skullHead,
            skullBody,
            soldierHead,
            soldierBody,
        }

        public int headIndexInPlayer;
        public int bodyIndexInPlayer;

        public ItemType itemType;
        public ItemBodyPart itemBodyPart;
        public bool isOnIventory;
        public int amount;
        public int price;

        public void SetOninventary(bool value)
        {
            isOnIventory = value;
        }
        //public int GetBodyPartIndex(ItemAssets itemAssets)
        //{
        //    switch (itemBodyPart)
        //    {
        //        default:
        //        case ItemBodyPart.head: return itemAssets.headIndex;
        //        case ItemBodyPart.body: return itemAssets.bodyIndex;
        //    }
        //}

        public Sprite GetSprite(ItemAssets itemAssets)
        {
            switch (itemType)
            {
                default:
                case ItemType.farmerHead: return itemAssets.farmerHeadSprite;
                case ItemType.farmerBody: return itemAssets.farmerBodySprite;
                case ItemType.samuraiHead: return itemAssets.samuraiHeadSprite;
                case ItemType.samuraiBody: return itemAssets.samuraiBodySprite;
                case ItemType.skullHead: return itemAssets.skullHeadsprite;
                case ItemType.skullBody: return itemAssets.skullBodySprite;
                case ItemType.soldierHead: return itemAssets.soldierHeadSprite;
                case ItemType.soldierBody: return itemAssets.soldierBodySprite;
            }
        }
    }

}
