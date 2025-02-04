using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class dialogueVariables 
{
    public Dictionary<string, Ink.Runtime.Object> variables {  get; private set; }

    public dialogueVariables(TextAsset loadGlobalsJSON)
    {
        Story globalVariablesStory = new Story(loadGlobalsJSON.text);

        variables = new Dictionary<string, Ink.Runtime.Object>();
        foreach (string name in globalVariablesStory.variablesState)
        {
            Ink.Runtime.Object value = globalVariablesStory.variablesState.GetVariableWithName(name);
            variables.Add(name, value);
            Debug.Log("dictionary initialized: " + name + " " + value);
        }



    }
    public void startListening(Story story)     
    {
        variablesToStory(story);
        story.variablesState.variableChangedEvent += variableChanged;
    }
    
    public void stopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= variableChanged;
    }
    
    private void variableChanged(string name, Ink.Runtime.Object value)
    {
        if (variables.ContainsKey(name))
        {
            variables.Remove(name);
            variables.Add(name, value);
        }
    }

    private void variablesToStory(Story story)
    {
        foreach (KeyValuePair<string, Ink.Runtime.Object> variable in variables)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    }
}
