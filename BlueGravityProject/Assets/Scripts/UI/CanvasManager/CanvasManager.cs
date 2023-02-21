using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test.UI
{
    public class CanvasManager : MonoBehaviour
    {
        [field: SerializeField] public GameObject PlayerInventoryPanel { get; private set; }
        [field: SerializeField] public GameObject ShopUI { get; private set; }
        [field: SerializeField] public GameObject HeadsShopSlots { get; private set; }
        [field: SerializeField] public GameObject BodiesShopSlots { get; private set; }
        [field: SerializeField] public GameObject DialoguePanel { get; private set; }

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
            //SetActivePlayerInventoryPanel(false);
            //SetActiveShopUI(false);
            //SetActiveHeadsShopSlots(false);
            //SetActiveBodiesShopSlots(false);
            //SetActiveDialoguePanel(false);
        }
    }
}

