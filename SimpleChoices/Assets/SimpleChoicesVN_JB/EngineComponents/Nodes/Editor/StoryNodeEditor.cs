using System.Collections;
using System.Collections.Generic;
using XNodeEditor;
using UnityEngine;
using SimpleChoicesVN_JB;

namespace SimpleChoicesVN_JB_Editor
{
	[CustomNodeEditor(typeof(StoryNode))]
	public class StoryNodeEditor : NodeEditor
	{

		public override void OnHeaderGUI()
		{
			GUI.color = Color.white;
			StoryNode node = target as StoryNode;
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
			StoryNode node = target as StoryNode;
			//if (node.graph is ChapterGraph)
			//{
				StoryGraph graph = node.graph as StoryGraph;
				//if (GUILayout.Button("MovePrev Node")) node.MovePrevious();
				if (GUILayout.Button("MoveNext Node")) node.MoveNext();
				if (GUILayout.Button("Continue Graph")) graph.Continue();
				if (GUILayout.Button("Set as current")) graph.current = node;
			//}


		}
	}
}