using System.Collections;
using UnityEngine;

namespace SimpleChoicesVN_JB
{
    [NodeTint("#22FFCC")]
    public class ItemNode : StoryNode
    {

        private StoryGraph parentGraph;

        public SC_InventoryItem newItem;

        protected override void Init()
        {
            parentGraph = graph as StoryGraph;
        }

        public override void OnEnter()
        {
            parentGraph.CollectInventoryItem(newItem);
            base.OnEnter();
        }
    }
}