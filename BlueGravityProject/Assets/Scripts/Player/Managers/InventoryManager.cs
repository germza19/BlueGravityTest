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

        [SerializeField] private RectTransform[] headsSlotsTransforms;
        [SerializeField] private RectTransform[] bodiesSlotsTransforms;

        [SerializeField] private Transform headsSlotsParent;
        [SerializeField] private Transform bodiesSlotsParent;

        [SerializeField] private GameObject itemSlotContainer;
        //[SerializeField] private GameObject itemSlotTemplate;

        public void SetInventory(Inventory inventory)
        {
            this.inventory = inventory;
            RefreshInventory(itemAssets);
        }

        private void RefreshInventory(ItemAssets itemAssets)
        {
            int headIndex = 0;
            int bodyIndex = 0;
            foreach (Item item in inventory.GetItemList())
            {
                if (item.GetBodyPartIndex(itemAssets) == 0)
                {
                    GameObject itemSlotGO = Instantiate(itemSlotContainer);
                    //GameObject itemTemplateGO = Instantiate(itemSlotTemplate);
                    //itemTemplateGO.transform.SetParent(itemSlotGO.transform);
                    itemSlotGO.transform.SetParent(headsSlotsParent);
                    itemSlotGO.SetActive(true);
                    
                    Transform itemGO = itemSlotGO.transform.GetChild(0);
                    //itemTemplateGO.SetActive(true);
                    Image image = itemGO.GetComponentInChildren<Image>();
                    image.sprite = item.GetSprite(itemAssets);
                    itemSlotGO.transform.position = headsSlotsTransforms[headIndex].position;
                    //itemTemplateGO.GetComponent<RectTransform>().position = Vector3.zero;
                    headIndex++;
                }
                else if (item.GetBodyPartIndex(itemAssets) == 1)
                {
                    GameObject itemSlotGO = Instantiate(itemSlotContainer);
                    //GameObject itemTemplateGO = Instantiate(itemSlotTemplate);
                    //itemTemplateGO.transform.SetParent(itemSlotGO.transform);
                    itemSlotGO.transform.SetParent(bodiesSlotsParent);
                    itemSlotGO.SetActive(true);
                    //itemTemplateGO.SetActive(true);
                    Transform itemGO = itemSlotGO.transform.GetChild(0);
                    Image image = itemGO.GetComponentInChildren<Image>();
                    image.sprite = item.GetSprite(itemAssets);
                    itemSlotGO.transform.position = bodiesSlotsTransforms[bodyIndex].position;
                    //itemTemplateGO.GetComponent<RectTransform>().position = Vector3.zero;
                    bodyIndex++;
                }

            }
        }
    }

}
