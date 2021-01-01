using XNodeEditor;
using SimpleChoicesVN_JB;

namespace SimpleChoicesVN_JB_Editor
{
	[CustomNodeGraphEditor(typeof(StoryGraph))]
	public class StoryGraphEditor : NodeGraphEditor
	{

		/// <summary> 
		/// Overriding GetNodeMenuName lets you control if and how nodes are categorized.
		/// In this example we are sorting out all node types that are not in the XNode.Examples namespace.
		/// </summary>
		public override string GetNodeMenuName(System.Type type)
		{
			if (type.Namespace == "SimpleChoicesVN_JB")
			{
				return base.GetNodeMenuName(type).Replace("SimpleChoicesVN_JB/", "");
			}
			else return null;
		}
	}
}