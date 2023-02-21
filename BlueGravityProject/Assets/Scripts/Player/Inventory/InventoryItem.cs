using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Test.ShopSystem;

namespace Test.Player.InventorySystem
{
    public class InventoryItem : MonoBehaviour
    {
        public static InventoryItem SpawnItemButton(ItemAssets itemAssets,Item item)
        {
            GameObject itemGO = Instantiate(itemAssets.pfItemButton);

            InventoryItem itemButton = itemGO.transform.GetComponent<InventoryItem>();
            itemButton.SetItem(itemAssets,item);

            return itemButton;
        }
        [SerializeField] IShopCustomer shopCustomer;

        public Item item;
        [SerializeField] private Image itemImage;
        [SerializeField] private TextMeshProUGUI goldValueText;
        public PlayerManager playerManager;

        public bool isOnInventory;
        private void Awake()
        {
            playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
            shopCustomer = playerManager;
        }

        public void Update()
        {
            isOnInventory = this.item.isOnIventory;
        }
        public void SetItem(ItemAssets itemAssets, Item item)
        {
            this.item = item;
            itemImage.sprite = item.GetSprite(itemAssets);
            int itemGoldValue = item.GetGoldValue(item.itemType);
            if(itemGoldValue == 0)
            {
                goldValueText.text = "";
            }
            else
            {
                goldValueText.SetText(itemGoldValue.ToString());
            }
            
        }
        public Item GetItem()
        {
            return item;
        }
        public void DestroSelf()
        {
            Destroy(gameObject);
        }
        public void OnLeftClickPressed()
        {
            if(GetItem().isOnIventory == false)
            {
                TryBuyItem(GetItem(),GetItem().itemType);
            }
            else
            {
                ShopStockManager parentStockManager = transform.GetComponentInParent<ShopStockManager>();
                if(parentStockManager == null)
                {
                    playerManager.inventory.EquipItem(playerManager,GetItem());
                }
                else
                {
                    return;
                }

            }
        }
        public void OnRightClickPressed()
        {
            if (GetItem().isOnIventory == true)
            {
                ShopStockManager parentStockManager = transform.GetComponentInParent<ShopStockManager>();
                if (parentStockManager == null)
                {
                    TrySellItem(GetItem(),GetItem().itemType);
                }
                else
                {
                    return;
                }
                

                //sell
            }
                
        }
        public void TryBuyItem(Item item,Item.ItemType itemType)
        {
            if(shopCustomer.TrySpendGoldAmount(item.GetGoldValue(itemType)))
            {
                shopCustomer.BoughtItem(itemType);
                playerManager.inventory.AddItem(item);
                item.SetOninventary(true);
            }
            else
            {
                Debug.Log("Notenough");
                return;
            }
        }
        public void TrySellItem(Item item,Item.ItemType itemType)
        {
            shopCustomer.SellItem(item.GetGoldValue(itemType));
            shopCustomer.SelledItem(itemType);
            playerManager.inventory.RemoveItem(item);
            item.SetOninventary(false);
        }

}
}

