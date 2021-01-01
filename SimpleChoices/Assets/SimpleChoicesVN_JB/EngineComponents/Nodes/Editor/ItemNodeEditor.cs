using UnityEditor;
using XNodeEditor;
using UnityEngine;
using SimpleChoicesVN_JB;

namespace SimpleChoicesVN_JB_Editor
{
	[CustomNodeEditor(typeof(ItemNode))]
	public class ItemNodeEditor : NodeEditor
	{

		public override void OnHeaderGUI()
		{
			GUI.color = Color.white;
			ItemNode node = target as ItemNode;
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
			ItemNode node = target as ItemNode;
			StoryGraph graph = node.graph as StoryGraph;
			if (GUILayout.Button("MoveNext Node")) node.MoveNext();
		}

	}
}