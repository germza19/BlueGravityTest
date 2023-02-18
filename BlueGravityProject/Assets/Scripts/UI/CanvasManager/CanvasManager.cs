using System.Collections;
using System.Collections.Generic;
using Test.UI.DialogueSystem;
using UnityEngine;

namespace Test.UI
{
    public class CanvasManager : MonoBehaviour
    {
        public DialogueManager dialogueManager { get; private set; }

        public void Awake()
        {
            dialogueManager = GetComponentInChildren<DialogueManager>();
            SetDialoguePanel(false);


        }

        public void SetDialoguePanel(bool value)
        {
            dialogueManager.gameObject.SetActive(value);
        }
    }
}

