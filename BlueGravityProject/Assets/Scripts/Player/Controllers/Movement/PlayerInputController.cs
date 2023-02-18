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

        public void OnMoveInput(InputAction.CallbackContext context)
        {
            MovementInput = context.ReadValue<Vector2>();
            NormInputX = (int)(MovementInput * Vector2.right).normalized.x;
            NormInputY = (int)(MovementInput * Vector2.up).normalized.y;
        }
        public void OnInteractInput(InputAction.CallbackContext context)
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
        public void PressedInteract()
        {
            InteractInput = false;
        }
    }
}


