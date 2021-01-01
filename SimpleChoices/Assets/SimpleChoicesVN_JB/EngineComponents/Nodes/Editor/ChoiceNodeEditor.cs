using UnityEditor;
using XNodeEditor;
using UnityEngine;
using XNode;
using SimpleChoicesVN_JB;

namespace SimpleChoicesVN_JB_Editor
{
	[CustomNodeEditor(typeof(ChoiceNode))]
	public class ChoiceNodeEditor : NodeEditor
	{

		public override void OnHeaderGUI()
		{
			GUI.color = Color.white;
			ChoiceNode node = target as ChoiceNode;
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
			base.OnBodyGUI();
			ChoiceNode node = target as ChoiceNode;
			
			StoryGraph graph = node.graph as StoryGraph;
			
			for (int i = 0; i < node.answers.Count; i++)
			{
				if (GUILayout.Button("Choice "+i)) node.SelectChoice(i);
			}


		}

		public override int GetWidth()
        {
            return 300;
        }
    }
}