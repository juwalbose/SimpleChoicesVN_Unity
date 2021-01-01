using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace SimpleChoicesVN_JB
{
    [NodeTint("#CCFFCC")]
    public class ChoiceNode : StoryNode
    {
        [Output(instancePortList = true)] public List<string> answers = new List<string>();
        [TextArea] public string choiceText;

        private StoryGraph parentGraph;

        protected override void Init()
        {
            parentGraph = graph as StoryGraph;
            
        }

        public void SelectChoice(int index)
        {
            NodePort port = null;
            if (answers.Count == 0)
            {
                port = GetOutputPort("output");
            }
            else
            {
                if (answers.Count <= index) return;
                port = GetOutputPort("answers " + index);
            }

            if (port == null) return;
            for (int i = 0; i < port.ConnectionCount; i++)
            {
                NodePort connection = port.GetConnection(i);
                (connection.node as StoryNode).OnEnter();
            }
        }
    }
}