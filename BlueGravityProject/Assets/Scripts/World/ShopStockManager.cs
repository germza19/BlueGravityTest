using System.Collections;
using System.Collections.Generic;
using Test.Player.InventorySystem;
using UnityEngine.UI;
using UnityEngine;

namespace Test.ShopSystem
{
    public class ShopStockManager : MonoBehaviour
    {
        private ShopStock shopStock;
        [SerializeField] private ItemAssets itemAssets;

        [SerializeField] private Transform headsSlotsParent;
        [SerializeField] private Transform bodiesSlotsParent;

        [SerializeField] private GameObject shopItemGO;

        public void SetStock(ShopStock shopStock)
        {
            this.shopStock = shopStock;
            RefreshStock(itemAssets);
        }
        public void Awake()
        {
            SetStock(shopStock);
        }

        private void RefreshStock(ItemAssets itemAssets)
        {
            if(shopStock != null)
            {
                foreach (Item item in shopStock.GetItemList())
                {
                    if (item.itemBodyPart == Item.ItemBodyPart.head)
                    {
                        GameObject instantiatedItem = InventoryItem.SpawnItemButton(itemAssets, item).gameObject;
                        instantiatedItem.transform.SetParent(headsSlotsParent.transform);
                    }
                    else if (item.itemBodyPart == Item.ItemBodyPart.body)
                    {
                        GameObject instantiatedItem = InventoryItem.SpawnItemButton(itemAssets, item).gameObject;
                        instantiatedItem.transform.SetParent(bodiesSlotsParent.transform);
                    }
                }
            

            }
        }
    }
}

