using System.Collections;
using UnityEngine;

namespace SimpleChoicesVN_JB
{
    [NodeTint("#22FFCC")]
    public class LocationNode : StoryNode
    {
        
        private StoryGraph parentGraph;

        public SC_Location newLocation;
        
        protected override void Init()
        {
            parentGraph = graph as StoryGraph;
        }

        public override void MoveNext()
        {
            parentGraph.currentLocation = newLocation;
            base.MoveNext();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            MoveNext();
        }
    }
}