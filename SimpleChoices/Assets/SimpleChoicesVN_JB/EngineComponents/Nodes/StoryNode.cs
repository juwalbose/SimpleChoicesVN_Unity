using System;
using UnityEngine;
using XNode;

namespace SimpleChoicesVN_JB
{
	public class StoryNode : Node
	{

		[Input] public Empty enter;
		[Output(connectionType = ConnectionType.Override)] public Empty exit;

		public virtual void MoveNext()
		{
			StoryGraph fmGraph = graph as StoryGraph;

			if (fmGraph.current != this)
			{
				Debug.LogWarning("Node isn't active");
				return;
			}

			NodePort exitPort = GetOutputPort("exit");

			if (!exitPort.IsConnected)
			{
				Debug.LogWarning("Node isn't connected");
				return;
			}

			StoryNode node = exitPort.Connection.node as StoryNode;
			node.OnEnter();
		}

		/*
		public void MovePrevious()
		{
			StoryGraph fmGraph = graph as StoryGraph;

			if (fmGraph.current != this)
			{
				Debug.LogWarning("Node isn't active");
				return;
			}

			NodePort enterPort = GetInputPort("enter");

			if (!enterPort.IsConnected)
			{
				Debug.LogWarning("Node isn't connected");
				return;
			}

			for (int i = 0; i < enterPort.ConnectionCount; i++)
			{
				NodePort connection = enterPort.GetConnection(i);
				(connection.node as StoryNode).OnEnter();
			}
		}*/

		public virtual void OnEnter()
		{
			StoryGraph fmGraph = graph as StoryGraph;
			fmGraph.current = this;
		}

		public override object GetValue(NodePort port)
		{
			return null;
		}

		[Serializable]
		public class Empty { }
	}
}