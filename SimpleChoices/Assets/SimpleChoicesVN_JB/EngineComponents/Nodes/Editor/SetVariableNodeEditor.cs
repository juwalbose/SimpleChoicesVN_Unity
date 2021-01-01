using UnityEditor;
using XNodeEditor;
using UnityEngine;
using SimpleChoicesVN_JB;

namespace SimpleChoicesVN_JB_Editor
{
	[CustomNodeEditor(typeof(SetVariableNode))]
	public class SetVariableNodeEditor : NodeEditor
	{
		int firstSelection=0;
		int intRHS = 0;
		string strRHS;
		int selectedBool;
		int selectedInt;

		public override void OnHeaderGUI()
		{
			GUI.color = Color.white;
			SetVariableNode node = target as SetVariableNode;
			//if (node.graph is ChapterGraph)
			//{
			StoryGraph graph = node.graph as StoryGraph;
			if (graph.current == node) GUI.color = Color.blue;
			//}

			string title = target.name;
			GUILayout.Label(title, NodeEditorResources.styles.nodeHeader, GUILayout.Height(30));
			GUI.color = Color.white;
		}

		public override void OnBodyGUI()
		{
			serializedObject.Update();
			base.OnBodyGUI();
			SetVariableNode node = target as SetVariableNode;
			StoryGraph graph = node.graph as StoryGraph;
			string[] options = new string[] { "Int", "Bool", "Str" };
			firstSelection = GUILayout.SelectionGrid(firstSelection, options, 4, EditorStyles.radioButton);
            if (firstSelection == 0)
            {
				string[] intOptions = new string[] { "+", "-" };
				selectedInt = GUILayout.SelectionGrid(selectedInt, intOptions, 1, EditorStyles.radioButton);
				intRHS = int.Parse(GUILayout.TextArea(intRHS.ToString()));
				node.UpdateIntVar(intOptions[selectedInt],intRHS);
			}
			else if (firstSelection == 2)
			{
				strRHS = GUILayout.TextArea(strRHS);
				node.UpdateStrVar(strRHS);
			}
			else if (firstSelection == 1)
			{
				string[] boolOptions = new string[] { "True", "False" };
				selectedBool = GUILayout.SelectionGrid(selectedBool, boolOptions, 1, EditorStyles.radioButton);
				if (selectedBool == 0)
				{
					node.UpdateBoolVar(true);
				}
				else
				{
					node.UpdateBoolVar(false);
				}
			}
		}

		public override int GetWidth()
		{
			return 300;
		}

	}
}