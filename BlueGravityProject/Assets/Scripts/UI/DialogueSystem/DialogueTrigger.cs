using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Test.Player;

namespace Test.UI.DialogueSystem
{
    public class DialogueTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject visualCue;
        public bool playerInRange;
        [SerializeField] TextAsset inkJSON;
        private PlayerManager player;

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
                player = other.gameObject.GetComponent<PlayerManager>();
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

            if (player.InputController.InteractInput && player.StateMachine.CurrentState != player.TalkState )
                //&& !DialogueManager.GetInstance().dialogueIsPlaying)
            {
                player.InputController.PressedInteract();
                player.StateMachine.ChangeState(player.TalkState);
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
    }
}

