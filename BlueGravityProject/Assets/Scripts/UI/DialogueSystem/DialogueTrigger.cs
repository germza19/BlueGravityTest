using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Test.Player;

namespace Test.DialogueSystem
{
    public class DialogueTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject visualCue;
        public bool playerInRange;
        [SerializeField] TextAsset inkJSON;
        private PlayerManager playerManager;

        private void Awake()
        {
            visualCue.SetActive(false);
        }

        private void Update()
        {
            EnterDialogue();
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                playerManager = other.gameObject.GetComponent<PlayerManager>();
                playerInRange = true;
                visualCue.SetActive(true);
            }
        }


        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                playerInRange = false;
                visualCue.SetActive(false);
            }
        }

        public void EnterDialogue()
        {
            if(!playerInRange)
                return;

            if (playerManager.InputController.InteractInput && playerManager.StateMachine.CurrentState != playerManager.TalkState )
                //&& !DialogueManager.GetInstance().dialogueIsPlaying)
            {
                playerManager.InputController.PressedInteract();
                playerManager.StateMachine.ChangeState(playerManager.TalkState);
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
    }
}

