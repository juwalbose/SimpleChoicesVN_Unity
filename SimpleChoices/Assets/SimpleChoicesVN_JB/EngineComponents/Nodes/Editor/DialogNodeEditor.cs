using UnityEditor;
using XNodeEditor;
using UnityEngine;
using SimpleChoicesVN_JB;

namespace SimpleChoicesVN_JB_Editor
{
	[CustomNodeEditor(typeof(DialogNode))]
	public class DialogNodeEditor : NodeEditor
	{

		public override void OnHeaderGUI()
		{
			GUI.color = Color.white;
			DialogNode node = target as DialogNode;
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
			DialogNode node = target as DialogNode;
			StoryGraph graph = node.graph as StoryGraph;
			if (GUILayout.Button("MoveNext Node")) node.MoveNext();
		}

		public override int GetWidth()
		{
			return 300;
		}


		public override Color GetTint()
		{
			DialogNode node = target as DialogNode;
			if (node.selectedCharacter == null) return base.GetTint();
			else
			{
				Color col = node.selectedCharacter.color;
				col.a = 1;
				return col;
			}
		}
	}
}