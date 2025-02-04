using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;

using UnityEngine.EventSystems;

public class dialogueManager : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float typingSpeed = 0.02f;

    [Header("Global Ink JSON")]
    [SerializeField] private TextAsset loadGlobalsJSON;


    [Header("Diagogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject UIcontroller;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private Animator portraitAnimator;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;

    private TextMeshProUGUI[] choicesText;
    private Story currentStory;
    public bool dialogueIsPlaying {  get; private set; }
    private dialogueVariables dialogueVariables; 
    
    private static dialogueManager instance;
    private Coroutine displayLineCoroutine;
    private const string speakerTag = "speaker";
    private bool canContinueToNextLine = false;
    private const string portraitTag = "portait";
    
    private void Awake()
    {
        
        if (instance != null) 
        {
            Debug.LogWarning(">1 instance");
        }
        instance = this;
        dialogueVariables = new dialogueVariables(loadGlobalsJSON);
    }

    public static dialogueManager getInstance()
    {
        return instance;
    }

    public void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];

        int index = 0;
        foreach (GameObject choice in choices)
            {

                choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
                index++;
            }
        
    

    }

    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            UIcontroller.SetActive(true);  
            return;
        }

        if (canContinueToNextLine && currentStory.currentChoices.Count == 0 && inputManager.GetInstance().GetInteractPressed() && dialogueIsPlaying)
        {
            Invoke("continueStory", 0.2f);
        }
    }


 

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        UIcontroller.SetActive(false);
        dialoguePanel.SetActive(true);

        dialogueVariables.startListening(currentStory);

        continueStory();
    }
    
    public IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);
        dialogueVariables.stopListening(currentStory);
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        
    }

    public void continueStory()
    {
        if (currentStory.canContinue)
        {
           if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(displayLine(currentStory.Continue()));
           

            handleTags(currentStory.currentTags);
        }        
        else
        {
           StartCoroutine(ExitDialogueMode());
        }
    }

    private void handleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2) 
            {
                Debug.Log("Tag not parsed: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case speakerTag:
                    displayNameText.text = tagValue;
                    Debug.Log("speaker= " + tagValue);
                    break;
                case portraitTag:
                    portraitAnimator.Play(tagValue);
                    Debug.Log("portrait= " + tagValue);
                    break;
                default:
                    Debug.Log("Tag in but not handled: " + tag);
                    break;

            }
        }
    }

    private void displayChoices()
    {
        
            List<Choice> currentChoices = currentStory.currentChoices;

            if (currentChoices.Count > choices.Length)
            {
                Debug.LogError("too many choices" + currentChoices.Count);
            }
            int index = 0;
            foreach (Choice choice in currentChoices)
            {
                choices[index].gameObject.SetActive(true);
                choicesText[index].text = choice.text;
                index++;
            }
            for ( int i = index; i < choices.Length; i++)
            {
                choices[i].gameObject.SetActive(false);
            }
            StartCoroutine(selectFirstChoice());
        
    }

    private IEnumerator selectFirstChoice()
    {
        
            EventSystem.current.SetSelectedGameObject(null);
            yield return new WaitForEndOfFrame();
            EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
        
    }
    private IEnumerator displayLine(string line)
    {
        dialogueText.text = "";
        canContinueToNextLine = false;
        hideChoices();
        bool isAddingRTT = false;

        foreach(char letter in line.ToCharArray())
        {

            if (inputManager.GetInstance().GetInteractPressed())
            {
                dialogueText.text = line;
                break;
            }

            if(letter == '<' || isAddingRTT)
            {
                isAddingRTT = true;
                dialogueText.text += letter;
                if (letter == '>')
                {
                    isAddingRTT = false;
                }
            }
            else
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }

            
        }
        canContinueToNextLine = true;
        displayChoices();
    }
    public void makeChoice(int choiceIndex)
    {
        if (canContinueToNextLine)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
            continueStory();
        }
    }
    public void hideChoices()
    {
        foreach (GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
        }
    }
    public Ink.Runtime.Object getVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVariables.variables.TryGetValue(variableName, out variableValue);

        if (variableValue == null)
        {
            Debug.LogWarning("ink variable is null: " + variableName);
        }
        return variableValue;
    }
}
