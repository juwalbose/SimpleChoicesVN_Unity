using System;
using System.Collections;
using UnityEngine;
using XNode;

namespace SimpleChoicesVN_JB
{
  
    public class CheckNode : StoryNode
    {
        [Output] public Empty pass;
        [Output] public Empty fail;
        
        private StoryGraph parentGraph;

        public SC_InventoryItem checkItem;
        [TextArea] public string variableName;

        protected override void Init()
        {
            parentGraph = graph as StoryGraph;
        }

        public override void OnEnter()
        {
            base.OnEnter();
        }

        public void UpdateInventoryCheck(bool flag)
        {
            
            ProceedWithResult(parentGraph.CheckInventoryItem(checkItem,flag));
        }

        public void UpdateBoolCheck(bool flag)
        {
            ProceedWithResult(parentGraph.CheckBoolVar(variableName, flag));
        }

        public void UpdateIntCheck(string op, int intRHS)
        {
            ProceedWithResult(parentGraph.CheckIntVar(variableName, op, intRHS));
        }

        public void UpdateStrCheck(string strRHS)
        {
            ProceedWithResult(parentGraph.CheckStrVar(variableName, strRHS));
        }

        void ProceedWithResult(bool success)
        {
            if (parentGraph.current != this)
            {
                return;
            }

                //Trigger next nodes
                NodePort port;
            if (success) port = GetOutputPort("pass");
            else port = GetOutputPort("fail");
            if (port == null) return;
            for (int i = 0; i < port.ConnectionCount; i++)
            {
                NodePort connection = port.GetConnection(i);
                (connection.node as StoryNode).OnEnter();
            }
        }
    }
}