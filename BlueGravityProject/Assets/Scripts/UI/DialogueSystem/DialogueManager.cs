using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Test.Player;
using Test.Player.Movement;
using UnityEngine.EventSystems;

namespace Test.UI.DialogueSystem
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI dialogueText;
        [SerializeField] private GameObject[] choices;
        [SerializeField] private Animator portraitAnimator;
        [SerializeField] private Animator layoutAnimator;
        [SerializeField] float typingSpeed = 0.04f;
        [SerializeField] private TextAsset loadGlobalJSON;
        private Coroutine displayLineCoroutine;
        //[SerializeField] private GameObject choicesHolder;
        [SerializeField] private GameObject choicesBG;
        [SerializeField] private GameObject firstChoice;
        [SerializeField] private GameObject continueIcon;
        private TextMeshProUGUI[] choicesText;
        private Story currentStory;
        public bool dialogueIsPlaying;
        private bool canContinueToNextLine = false;
        private DialogueVariables dialogueVariables;

        private static DialogueManager instance;
        private const string SPEAKER_TAG = "speaker";
        private const string PORTRAIT_TAG = "portrait";
        private const string LAYOUT_TAG = "layout";
        public PlayerInputController inputController { get; private set; }
        public PlayerManager player { get; private set; }

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogWarning("More than one DialogueManager in scene");
            }
            instance = this;
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
            inputController = player.InputController;
            dialogueVariables = new DialogueVariables(loadGlobalJSON);
        }

        public static DialogueManager GetInstance()
        {
            return instance;
        }
        private void Start()
        {
            dialogueIsPlaying = false;
            choicesText = new TextMeshProUGUI[choices.Length];
            choicesBG.SetActive(false);


            int index = 0;
            foreach (GameObject choice in choices)
            {
                choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
                index++;
            }
        }

        private void Update()
        {
            if (BG())
            {
                choicesBG.SetActive(true);
            }
            else
            {
                choicesBG.SetActive(false);
            }
            if (!dialogueIsPlaying)
            {
                return;
            }
            //if (playerInput.pressedInteract && dialoguePanel.gameObject.activeSelf)
            //if (canContinueToNextLine && playerInput.GetNextPressed() && dialoguePanel.gameObject.activeSelf)
            if (canContinueToNextLine && inputController.GetNextPressed() && currentStory.currentChoices.Count == 0)
            {
                if (!choices[0].gameObject.activeSelf && continueIcon.activeSelf)
                {
                    ContinueStory();
                }
                //playerInput.pressedInteract = false;

            }
        }
        bool BG()
        {
            bool result = firstChoice.activeSelf;
            return result;
        }
        public void EnterDialogueMode(TextAsset inkJSON)
        {
            currentStory = new Story(inkJSON.text);
            dialogueIsPlaying = true;
            //dialoguePanel.SetActive(true);
            player.StateMachine.ChangeState(player.TalkState);
            dialogueVariables.StartListening(currentStory);

            //reset portrait
            portraitAnimator.Play("default");
            layoutAnimator.Play("left");

            ContinueStory();

        }

        private void ExitDialogueMode()
        {
            StartCoroutine(ExitDialogue());
        }

        private IEnumerator ExitDialogue()
        {
            yield return new WaitForSeconds(0.2f);
            dialogueVariables.StopListening(currentStory);
            dialogueIsPlaying = false;
            player.TalkState.Exit();
            //dialoguePanel.SetActive(false);
            dialogueText.text = "";

        }
        private void ContinueStory()
        {
            if (currentStory.canContinue)
            {
                //dialogueText.text = currentStory.Continue();          // full line
                if (displayLineCoroutine != null)
                {
                    StopCoroutine(displayLineCoroutine);
                }
                displayLineCoroutine = StartCoroutine(DisplayLines(currentStory.Continue()));  // letter by letter   

                HandleTags(currentStory.currentTags);
            }
            else
            {
                ExitDialogueMode();
                //playerInput.ShiftActionMapToPlayer();
                player.StateMachine.ChangeState(player.IdleState);
                //player.states.transitionToState(player.states.idleState);
            }
        }
        private void HandleTags(List<string> currentTags)
        {
            foreach (string tag in currentTags)
            {
                string[] splitTag = tag.Split(':');
                if (splitTag.Length != 2)
                {
                    Debug.LogError("Check tag lenght");
                }
                string tagKey = splitTag[0].Trim();
                string tagValue = splitTag[1].Trim();

                switch (tagKey)
                {
                    case SPEAKER_TAG:
                        //Debug.Log("speaker=" + tagValue);
                        break;
                    case PORTRAIT_TAG:
                        portraitAnimator.Play(tagValue);
                        //Debug.Log("portrait=" + tagValue);
                        break;
                    case LAYOUT_TAG:
                        layoutAnimator.Play(tagValue);
                        //Debug.Log("layout=" + tagValue);
                        break;
                    default:
                        Debug.LogWarning("Tag came but not handled");
                        break;
                }

            }
        }
        private void Displaychoices()
        {
            List<Choice> currentChoices = currentStory.currentChoices;
            //Debug.Log(currentStory.currentChoices);
            //Debug.Log(currentChoices);
            if (currentChoices.Count > choices.Length)
            {
                Debug.LogError("More choices than UI can support");
            }
            int index = 0;
            foreach (Choice choice in currentChoices)
            {
                //Debug.Log("ok");
                choices[index].gameObject.SetActive(true);
                choicesText[index].text = choice.text;
                index++;
            }
            //choicesBG.SetActive(false);
            for (int i = index; i < choices.Length; i++)
            {
                //Debug.Log("demas");
                choices[i].gameObject.SetActive(false);
            }
            StartCoroutine(SelectFirstChoice());

        }

        private IEnumerator SelectFirstChoice()
        {
            EventSystem.current.SetSelectedGameObject(null);
            yield return new WaitForEndOfFrame();
            EventSystem.current.SetSelectedGameObject(choices[0].gameObject);

        }
        public void MakeChoice(int choiceIndex)
        {
            if (canContinueToNextLine)
            {
                currentStory.ChooseChoiceIndex(choiceIndex);
                inputController.RegisterSubmitPressed();
                ContinueStory();
            }

        }
        private IEnumerator DisplayLines(string line)
        {

            dialogueText.text = "";
            continueIcon.gameObject.SetActive(false);

            HideChoices();
            canContinueToNextLine = false;
            foreach (char letter in line.ToCharArray())
            {
                dialogueText.text += letter;
                if (inputController.GetNextPressed())
                {
                    //Debug.Log("skip");
                    dialogueText.text = line;
                    break;
                }
                //dialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
            canContinueToNextLine = true;
            continueIcon.gameObject.SetActive(true);

            Displaychoices();
        }

        private void HideChoices()
        {
            //choicesBG.SetActive(false);
            foreach (GameObject choiceButton in choices)
            {
                choiceButton.SetActive(false);
            }
        }

        public Ink.Runtime.Object GetVariableState(string variableName)
        {
            Ink.Runtime.Object variableValue = null;
            dialogueVariables.variables.TryGetValue(variableName, out variableValue);
            if (variableValue == null)
            {
                Debug.Log("Ink variable null:" + variableName);
            }
            return variableValue;
        }
    }
}

