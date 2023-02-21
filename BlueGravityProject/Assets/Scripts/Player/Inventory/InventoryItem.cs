using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        public Item item;
        [SerializeField] private Image itemImage;
        [SerializeField] private TextMeshProUGUI amountText;
        public PlayerManager playerManager;

        public bool isOnInventory;
        private void Awake()
        {
            playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        }

        public void Update()
        {
            isOnInventory = this.item.isOnIventory;
        }
        public void SetItem(ItemAssets itemAssets, Item item)
        {
            this.item = item;
            itemImage.sprite = item.GetSprite(itemAssets);
            if(item.amount == 0)
            {
                amountText.text = "";
            }
            else
            {
                amountText.SetText(item.amount.ToString());
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
                playerManager.inventory.AddItem(GetItem());
                GetItem().SetOninventary(true);
                
            }
            else
            {                
                //equip
            }
            //DestroSelf();
        }
        public void OnRightClickPressed()
        {
            if (GetItem().isOnIventory == true)
            {
                playerManager.inventory.RemoveItem(GetItem());
            }
                
        }
}
}

