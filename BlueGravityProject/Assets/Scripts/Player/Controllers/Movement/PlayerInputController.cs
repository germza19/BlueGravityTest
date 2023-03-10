using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Test.Player.Movement
{
    public class PlayerInputController : MonoBehaviour
    {
        public PlayerManager player { get; private set; }
        public Vector2 MovementInput { get; private set; }
        public int NormInputX { get; private set; }
        public int NormInputY { get; private set; }
        public bool InteractInput { get; private set; }
        public bool SubmitInput { get; private set; }
        public bool NextInput { get; private set; }
        public bool InventoryInput { get; private set; }
        public bool PauseInput { get; private set; }
        public bool isPaused { get; private set; }

        //InputActionMap playerActionMap;
        //InputActionMap uIActionMap;
        public void Awake()
        {
            //playerActionMap = this.GetComponent<PlayerInput>().actions.FindActionMap("Player");
            //uIActionMap = this.GetComponent<PlayerInput>().actions.FindActionMap("UI");
        }
        public void OnMoveInput(InputAction.CallbackContext context)
        {
            if(!isPaused)
            {
                MovementInput = context.ReadValue<Vector2>();
                NormInputX = (int)(MovementInput * Vector2.right).normalized.x;
                NormInputY = (int)(MovementInput * Vector2.up).normalized.y;
            }

        }
        public void OnInteractInput(InputAction.CallbackContext context)
        {
            if (!isPaused)
            {
                if (context.performed && InteractInput == false)
                {
                    InteractInput = true;
                }
                if (context.canceled)
                {
                    InteractInput = false;
                }
            }


        }
        public void PressedInteract()
        {
            InteractInput = false;
        }
        public void OnSubmitInput(InputAction.CallbackContext context)
        {
            if (!isPaused)
            {
                if (context.performed)
                {
                    SubmitInput = true;
                }
                else if (context.canceled)
                {
                    SubmitInput = false;
                }
            }
        }
        public bool GetSubmitPressed()
        {
            bool result = SubmitInput;
            SubmitInput = false;
            return result;
        }
        public void PressedSubmit()
        {
            SubmitInput = false;
        }
        public void OnNextInput(InputAction.CallbackContext context)
        {
            if (!isPaused)
            {
                if (context.performed)
                {
                    NextInput = true;
                }
                else if (context.canceled)
                {
                    NextInput = false;
                }
            }
        }
        public bool GetNextPressed()
        {
            bool result = NextInput;
            NextInput = false;
            return result;
        }

        public void OnInventoryInput(InputAction.CallbackContext context)
        {
            if (!isPaused)
            {
                if (context.performed)
                {
                    InventoryInput = true;
                }
                else if (context.canceled)
                {
                    InventoryInput = false;
                }
            }
        }
        public void PressedInventory()
        {
            InventoryInput = false;
        }
        public void OnPauseInput(InputAction.CallbackContext context)
        {

            if (context.performed && InteractInput == false)
            {
                PauseInput = true;
            }
            if (context.canceled)
            {
                PauseInput = false;
            }
        }
        public void PressedPauseInput()
        {
            PauseInput = false;
        }
        public void SetIsPaused(bool value)
        {
            isPaused = value;
        }

        //public void ShiftActionMapToUI()
        //{
        //    playerActionMap.Disable();
        //    uIActionMap.Enable();
        //}
        //public void ShiftActionMapToPlayer()
        //{
        //    uIActionMap.Disable();
        //    playerActionMap.Enable();
        //}
    }
}


