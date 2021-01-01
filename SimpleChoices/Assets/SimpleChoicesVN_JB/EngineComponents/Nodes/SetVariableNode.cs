using System;
using System.Collections;
using UnityEngine;

namespace SimpleChoicesVN_JB
{
    [NodeTint("#8844CC")]
    public class SetVariableNode : StoryNode
    {

        private StoryGraph parentGraph;
        [TextArea] public string variableName;

        protected override void Init()
        {
            parentGraph = graph as StoryGraph;
        }

        public void UpdateStrVar(string strRHS)
        {
            parentGraph.AssignStrVar(variableName,strRHS);
            MoveNext();
        }

        public void UpdateIntVar(string op, int intRHS)
        {
            parentGraph.AssignIntVar(variableName, op,intRHS);
            MoveNext();
        }

        public void UpdateBoolVar(bool flag)
        {
            parentGraph.AssignBoolVar(variableName, flag);
            MoveNext();
        }
    }
}