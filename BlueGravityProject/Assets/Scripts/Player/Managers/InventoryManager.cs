using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Test.Player.InventorySystem
{
    public class InventoryManager : MonoBehaviour
    {
        private Inventory inventory;
        [SerializeField] private ItemAssets itemAssets;

        //[SerializeField] private RectTransform[] headsSlotsTransforms;
        //[SerializeField] private RectTransform[] bodiesSlotsTransforms;

        [SerializeField] private Transform headsSlotsParent;
        [SerializeField] private Transform bodiesSlotsParent;

        [SerializeField] private GameObject inventoryItemGO;
        //[SerializeField] private GameObject itemSlotTemplate;

        public void SetInventory(Inventory inventory)
        {
            this.inventory = inventory;

            inventory.OnItemListChanged += Inventory_OnItemListChanged;
            RefreshInventory(itemAssets);
        }

        private void Inventory_OnItemListChanged ( object sender, System.EventArgs e)
        {
            RefreshInventory(itemAssets);
        }

        private void RefreshInventory(ItemAssets itemAssets)
        {
            foreach (Transform child in headsSlotsParent)
            {
                Destroy(child.gameObject);
            }
            foreach (Transform child in bodiesSlotsParent)
            {
                Destroy(child.gameObject);
            }
            foreach (Item item in inventory.GetItemList())
            {
                if (item.GetBodyPartIndex(itemAssets) == 0)
                {
                    GameObject instantiatedItem = InventoryItem.SpawnItemButton(itemAssets, item).gameObject;
                    instantiatedItem.transform.SetParent(headsSlotsParent.transform);
                }
                else if (item.GetBodyPartIndex(itemAssets) == 1)
                {
                    GameObject instantiatedItem = InventoryItem.SpawnItemButton(itemAssets, item).gameObject;
                    instantiatedItem.transform.SetParent(bodiesSlotsParent.transform);
                }

            }
        }
    }

}
