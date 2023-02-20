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

        [SerializeField] private RectTransform[] headsSlotsTransforms;
        [SerializeField] private RectTransform[] bodiesSlotsTransforms;

        [SerializeField] private Transform headsSlotsParent;
        [SerializeField] private Transform bodiesSlotsParent;

        [SerializeField] private GameObject itemSlotContainer;

        public void SetStock(ShopStock shopStock)
        {
            this.shopStock = shopStock;
            RefreshStock(itemAssets);
        }

        private void RefreshStock(ItemAssets itemAssets)
        {
            int headIndex = 0;
            int bodyIndex = 0;
            foreach (Item item in shopStock.GetItemList())
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

