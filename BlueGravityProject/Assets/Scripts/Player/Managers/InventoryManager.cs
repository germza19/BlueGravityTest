using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private RectTransform[] headsSlotsTransforms;
    [SerializeField] private RectTransform[] bodiesSlotsTransforms;

    [SerializeField] private Transform headsSlotsParent;
    [SerializeField] private Transform bodiesSlotsParent;

    [SerializeField] private GameObject itemSlotContainer;
    [SerializeField] private GameObject itemSlotTemplate;

    public int type;


    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventory();
    }

    private void RefreshInventory()
    {
        int index = 0;
        foreach (Item item in inventory.GetItemList())
        {
            if(type == 0)
            {
                GameObject itemSlotGO = Instantiate(itemSlotContainer);
                GameObject itemTemplateGO = Instantiate(itemSlotTemplate);
                itemTemplateGO.transform.SetParent(itemSlotGO.transform);
                itemTemplateGO.GetComponent<RectTransform>().position = Vector3.zero;
                itemSlotGO.transform.SetParent(headsSlotsParent);
                itemSlotGO.SetActive(true);
                itemTemplateGO.SetActive(true);
                itemSlotGO.transform.position = headsSlotsTransforms[index].position;
                index++;
            }
            else if(type == 1)
            {
                GameObject itemSlotGO = Instantiate(itemSlotContainer);
                GameObject itemTemplateGO = Instantiate(itemSlotTemplate);
                itemTemplateGO.transform.SetParent(itemSlotGO.transform);
                itemTemplateGO.GetComponent<RectTransform>().position = Vector3.zero;
                itemSlotGO.transform.SetParent(bodiesSlotsParent);
                itemSlotGO.SetActive(true);
                itemTemplateGO.SetActive(true);
                itemSlotGO.transform.position = bodiesSlotsTransforms[index].position;
                index++;
            }

        }
    }
}
