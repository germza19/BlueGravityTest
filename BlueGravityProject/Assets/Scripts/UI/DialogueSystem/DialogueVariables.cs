using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

namespace Test.DialogueSystem
{
    public class DialogueVariables
    {
        public Dictionary<string, Ink.Runtime.Object> variables { get; private set; }

        public DialogueVariables(TextAsset loadGlobalsJSON)
        {
            Story globalVariablesStory = new Story(loadGlobalsJSON.text);
            //story compiler
            //string infKileContents = File.ReadAllText(globalsFilePath);
            //Ink.Compiler compiler = new Ink.Compiler(infKileContents);
            //Story globalVariablesStory = compiler.Compile();
            // initialize dictionary
            variables = new Dictionary<string, Ink.Runtime.Object>();
            foreach (string name in globalVariablesStory.variablesState)
            {
                Ink.Runtime.Object value = globalVariablesStory.variablesState.GetVariableWithName(name);
                variables.Add(name, value);
                //Debug.Log("Initialize global dialogue variables: " + name + "=" + value);
            }
        }
        public void StartListening(Story story)
        {
            VariablesToStory(story);
            story.variablesState.variableChangedEvent += VariableChanged;

        }
        public void StopListening(Story story)
        {
            story.variablesState.variableChangedEvent -= VariableChanged;
        }
        private void VariableChanged(string name, Ink.Runtime.Object value)
        {
            if (variables.ContainsKey(name))
            {
                variables.Remove(name);
                variables.Add(name, value);
            }
            //Debug.Log("Variable changed: " + name + "=" + value);
        }
        private void VariablesToStory(Story story)
        {
            foreach (KeyValuePair<string, Ink.Runtime.Object> variable in variables)
            {
                story.variablesState.SetGlobal(variable.Key, variable.Value);
            }
        }
    }
}

