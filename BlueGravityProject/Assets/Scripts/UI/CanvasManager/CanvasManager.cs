using System.Collections;
using System.Collections.Generic;
using Test.Player;
using TMPro;
using UnityEngine;

namespace Test.UI
{
    public class CanvasManager : MonoBehaviour
    {
        [SerializeField] PlayerManager playerManager;
        [field: SerializeField] public GameObject PlayerInventoryPanel { get; private set; }
        [field: SerializeField] public GameObject ShopUI { get; private set; }
        [field: SerializeField] public GameObject HeadsShopSlots { get; private set; }
        [field: SerializeField] public GameObject BodiesShopSlots { get; private set; }
        [field: SerializeField] public GameObject DialoguePanel { get; private set; }
        public TextMeshProUGUI goldAmount;


        public void FixedUpdate()
        {
            goldAmount.text = playerManager.currentGoldAmount.ToString();
        }
        public void SetActivePlayerInventoryPanel(bool value)
        {
            PlayerInventoryPanel.SetActive(value);
        }
        public void SetActiveShopUI(bool value)
        {
            ShopUI.SetActive(value);
        }
        public void SetActiveHeadsShopSlots(bool value)
        {
            HeadsShopSlots.SetActive(value);
        }
        public void SetActiveBodiesShopSlots(bool value)
        {
            BodiesShopSlots.SetActive(value);
        }
        public void SetActiveDialoguePanel(bool value)
        {
            DialoguePanel.SetActive(value);
        }


        public void Start()
        {
            SetActivePlayerInventoryPanel(false);
            SetActiveHeadsShopSlots(true);
            SetActiveBodiesShopSlots(true);
            SetActiveShopUI(false);
            SetActiveDialoguePanel(false);
        }

        public void Update()
        {
            CheckInventoryInput();
        }

        public void CheckInventoryInput()
        {
            bool inventoryInput = playerManager.InputController.InventoryInput;
            if(inventoryInput && !ShopUI.activeSelf)
            {
                if(!PlayerInventoryPanel.activeSelf)
                {
                    playerManager.InputController.PressedInventory();
                    SetActivePlayerInventoryPanel(true);
                }
                else
                {
                    playerManager.InputController.PressedInventory();
                    SetActivePlayerInventoryPanel(false);
                }
               
            }
        }
        public void CloseShopUI()
        {
            SetActiveShopUI(false);
        }
    }
}

