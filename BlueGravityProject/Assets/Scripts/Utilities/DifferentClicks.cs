using System.Collections;
using System.Collections.Generic;
using Test.Player.InventorySystem;
using UnityEngine;
using UnityEngine.EventSystems;

public class DifferentClicks : MonoBehaviour, IPointerClickHandler
{
    private InventoryItem inventoryItem;

    private void Start()
    {
        inventoryItem = GetComponent<InventoryItem>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            inventoryItem.OnLeftClickPressed();
        }
        else if(eventData.button == PointerEventData.InputButton.Right)
        {
            inventoryItem.OnRightClickPressed();
        }
    }

}
