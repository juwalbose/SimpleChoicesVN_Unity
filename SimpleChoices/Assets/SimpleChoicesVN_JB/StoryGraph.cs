using System;
using UnityEngine;
using XNode;

namespace SimpleChoicesVN_JB
{
	[CreateAssetMenu(fileName = "New Story Graph", menuName = "SimpleChoicesVN/Story Graph")]
	public class StoryGraph : NodeGraph
	{

		// The current "active" node
		public StoryNode current;

		public string storyName;
		public SC_Character[] characters;
		public SC_Location[] locations;
		public SC_InventoryItem[] inventoryItems;
		public SC_CharacterExpression[] characterExpressions;

        internal void AssignStrVar(string variableName, string strRHS)
        {
			for (int i = 0; i < storyVariableStore.stringVariables.Length; i++)
			{
				if (storyVariableStore.stringVariables[i].variableName == variableName) storyVariableStore.stringVariables[i].value = strRHS;
			}
		}

        internal void AssignIntVar(string variableName, string op, int intRHS)
        {
			bool found = false;
			for (int i = 0; i < storyVariableStore.integerVariables.Length; i++)
			{
				if (storyVariableStore.integerVariables[i].variableName == variableName)
				{
					found = true;
					switch (op)
					{
						case "+":
							storyVariableStore.integerVariables[i].value += intRHS;
							break;
						case "-":
							storyVariableStore.integerVariables[i].value -= intRHS;
							break;
					}
				}
			}
			if (!found)
			{
				Debug.LogWarning("No such variable" + variableName);
			}
		}

        internal void AssignBoolVar(string variableName, bool flag)
        {
			for (int i = 0; i < storyVariableStore.booleanVariables.Length; i++)
			{
				if (storyVariableStore.booleanVariables[i].variableName == variableName)  storyVariableStore.booleanVariables[i].value = flag;
			}
		}

        public SC_StoryVariableStore storyVariableStore;
		public SC_ParsingDataStore parsingDataStore;

		public SC_CharacterExpression defaultExpression;
		public SC_Character defaultCharacter;

		public SC_Location currentLocation;


		internal void CollectInventoryItem(SC_InventoryItem newItem)
        {
            for(int i = 0; i < inventoryItems.Length; i++)
            {
				if (inventoryItems[i] == newItem) inventoryItems[i].collected = true;
			}
        }

        internal bool CheckInventoryItem(SC_InventoryItem checkItem, bool flag)
        {
			for (int i = 0; i < inventoryItems.Length; i++)
			{
				if (inventoryItems[i] == checkItem) return (inventoryItems[i].collected == flag);
			}
			return false;
		}

        internal bool CheckBoolVar(string variableName, bool flag)
        {
			
			for (int i = 0; i < storyVariableStore.booleanVariables.Length; i++)
			{
				if (storyVariableStore.booleanVariables[i].variableName == variableName) return (storyVariableStore.booleanVariables[i].value == flag);
			}
			Debug.LogWarning("No such variable" + variableName);
			return false;
		}

        internal bool CheckIntVar(string variableName, string op, int intRHS)
        {
			bool found = false;
			int val = 0;
			for (int i = 0; i < storyVariableStore.integerVariables.Length; i++)
			{
				if (storyVariableStore.integerVariables[i].variableName == variableName)
                {
					found = true;
					val = storyVariableStore.integerVariables[i].value;

				}
			}
			if (!found)
			{
				Debug.LogWarning("No such variable" + variableName);
				return false;
			}
			//string[] intOptions = new string[] { ">", "<", "=" };
			switch (op)
            {
				case ">":
					return (val > intRHS);
					break;
				case "<":
					return (val < intRHS);
					break;
				case "=":
					return (val == intRHS);
					break;
			}
			Debug.LogWarning("Wrong operator: " + op);
			return false;
		}

		internal bool CheckStrVar(string variableName, string strRHS)
        {
			for (int i = 0; i < storyVariableStore.stringVariables.Length; i++)
			{
				if (storyVariableStore.stringVariables[i].variableName == variableName) return (storyVariableStore.stringVariables[i].value == strRHS);
			}
			Debug.LogWarning("No such variable" + variableName);
			return false;
		}
        
        /*
		  this.currentChapter=file.currentChapter;
            this.currentSequence=file.currentSequence-1;
            this.inventory=file.inventory;
		 */

        public void Continue()
		{
			current.MoveNext();
		}
	}
}