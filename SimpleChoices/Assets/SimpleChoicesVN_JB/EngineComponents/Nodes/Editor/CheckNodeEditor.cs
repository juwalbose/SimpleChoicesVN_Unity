using UnityEditor;
using XNodeEditor;
using UnityEngine;
using SimpleChoicesVN_JB;

namespace SimpleChoicesVN_JB_Editor
{
	[CustomNodeEditor(typeof(CheckNode))]
	public class CheckNodeEditor : NodeEditor
	{
		int selectedInv = 0;
		int selectedBool = 0;
		int selectedInt = 0;
		string strRHS;
		int intRHS = 0;
		private bool invGroupEnabled = true;
		bool boolGroupEnabled = false;
		bool intGroupEnabled = false;
		bool strGroupEnabled = false;
		public override void OnHeaderGUI()
		{
			GUI.color = Color.white;
			CheckNode node = target as CheckNode;
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
			//base.OnBodyGUI();
			CheckNode node = target as CheckNode;
			NodeEditorGUILayout.PortField(node.GetInputPort("enter"));
			//EditorGUILayout.Space();
			NodeEditorGUILayout.PortField(target.GetOutputPort("pass"));
			NodeEditorGUILayout.PortField(target.GetOutputPort("fail"));
			StoryGraph graph = node.graph as StoryGraph;

			string[] options = new string[] { "Check Inventory", "Check Bool Var", "Check Int Var", "Check Str Var" };
			string[] boolOptions = new string[] { "True", "False"};
			string[] intOptions = new string[] { ">", "<", "=" };
			invGroupEnabled = EditorGUILayout.BeginToggleGroup(options[0], invGroupEnabled);
			NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("checkItem"), GUIContent.none);
			selectedInv = GUILayout.SelectionGrid(selectedInv, boolOptions, 1, EditorStyles.radioButton);
			EditorGUILayout.EndToggleGroup();
			
			if (!invGroupEnabled)
            {
				NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("variableName"), GUIContent.none);
				boolGroupEnabled = EditorGUILayout.BeginToggleGroup(options[1], boolGroupEnabled);
				selectedBool = GUILayout.SelectionGrid(selectedBool, boolOptions, 1, EditorStyles.radioButton);
				EditorGUILayout.EndToggleGroup();
			}
			
			if (!invGroupEnabled && !boolGroupEnabled)
			{
				
				intGroupEnabled = EditorGUILayout.BeginToggleGroup(options[2], intGroupEnabled);
				selectedInt = GUILayout.SelectionGrid(selectedInt, intOptions, 1, EditorStyles.radioButton);
				intRHS = int.Parse(GUILayout.TextArea(intRHS.ToString()));
				EditorGUILayout.EndToggleGroup();
			}
			if (!invGroupEnabled && !boolGroupEnabled && !intGroupEnabled)
			{
				strGroupEnabled = EditorGUILayout.BeginToggleGroup(options[3], strGroupEnabled);
				strRHS = GUILayout.TextArea(strRHS);
			   EditorGUILayout.EndToggleGroup();
			}

            if (invGroupEnabled)
            {
                if (selectedInv == 0)
                {
					node.UpdateInventoryCheck(true);
                }
                else
                {
					node.UpdateInventoryCheck(false);
				}
				
            }else if (boolGroupEnabled)
			{
				if (selectedInv == 0)
				{
					node.UpdateBoolCheck(true);
				}
				else
				{
					node.UpdateBoolCheck(false);
				}
			}
			else if (intGroupEnabled)
			{
				node.UpdateIntCheck(intOptions[selectedInt],intRHS);
			}
			else if (strGroupEnabled)
			{
				node.UpdateStrCheck(strRHS);
			}

			
			

			serializedObject.ApplyModifiedProperties();

		}

		public override int GetWidth()
		{
			return 300;
		}

	}
}