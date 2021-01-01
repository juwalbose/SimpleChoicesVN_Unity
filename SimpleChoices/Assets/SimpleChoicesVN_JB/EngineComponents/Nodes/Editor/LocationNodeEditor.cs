using UnityEditor;
using XNodeEditor;
using UnityEngine;
using SimpleChoicesVN_JB;

namespace SimpleChoicesVN_JB_Editor
{
	[CustomNodeEditor(typeof(LocationNode))]
	public class LocationNodeEditor : NodeEditor
	{

		public override void OnHeaderGUI()
		{
			GUI.color = Color.white;
			LocationNode node = target as LocationNode;
			//if (node.graph is ChapterGraph)
			//{
			StoryGraph graph = node.graph as StoryGraph;
			if (graph.current == node) GUI.color = Color.blue;
			//}

			string title = target.name;
			GUILayout.Label(title, NodeEditorResources.styles.nodeHeader, GUILayout.Height(30));
			GUI.color = Color.white;
		}

		

	}
}