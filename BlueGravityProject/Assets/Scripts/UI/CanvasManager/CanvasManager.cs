using System.Collections;
using System.Collections.Generic;
using Test.DialogueSystem;
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
        [field: SerializeField] public TextMeshProUGUI goldAmountShop { get; private set; }
        [field: SerializeField] public TextMeshProUGUI goldAmountInventory { get; private set; }
        private int amountOfGoldToGive;

        public void SetAmountOfGoldToGive( int value)
        {
            amountOfGoldToGive = value;
        }


        public void FixedUpdate()
        {
            goldAmountShop.text = playerManager.GetGoldAmount().ToString();         // optimize with event
            goldAmountInventory.text = playerManager.GetGoldAmount().ToString();
            //CheckIfShouldOpenShop();
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
            if(playerManager.StateMachine.CurrentState != playerManager.TalkState)
            {
                SetActiveShopUI(false);
            }
            
        }

        public void CheckIfShouldGiveMoney()
        {
            string giveMoney = ((Ink.Runtime.StringValue)DialogueManager.GetInstance().GetVariableState("GiveGold")).value;

            if (giveMoney != null)
            {
                Debug.Log(giveMoney);
                switch (giveMoney)
                {
                    case "":
                        break;
                    case "true":
                        playerManager.ModifyGoldAmount(amountOfGoldToGive);
                        break;
                    case "false":
                        Debug.Log("AlreadyGiven");
                        break;
                    default:
                        Debug.LogWarning("no giveGold variable");
                        break;
                }
            }
        }
        public void CheckIfShouldOpenShop()
        {
            string OpenShop = ((Ink.Runtime.StringValue)DialogueManager.GetInstance().GetVariableState("OpenShop")).value;

            if(OpenShop != null && !ShopUI.activeSelf)
            {
                Debug.Log(OpenShop);
                switch(OpenShop)
                {
                    case "":
                        if(ShopUI.activeSelf)
                        {
                            SetActiveShopUI(false);
                        }
                        break;
                    case "true":
                        if(!ShopUI.activeSelf)
                        {
                            SetActiveShopUI(true);
                            if (PlayerInventoryPanel.activeSelf)
                            {
                                SetActivePlayerInventoryPanel(false);
                            }                        
                        }
                        break;
                    case "false":
                        if (ShopUI.activeSelf)
                        {
                            SetActiveShopUI(false);
                        }
                        break;
                    default:
                        Debug.LogWarning("no shop variable");
                        break;
                }
            }
            else
            {
                return;
            }
        }
    }
}

