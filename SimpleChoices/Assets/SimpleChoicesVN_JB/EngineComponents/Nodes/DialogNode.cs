using System.Collections;
using UnityEngine;

namespace SimpleChoicesVN_JB
{
    [NodeTint("#CCFFCC")]
    public class DialogNode : StoryNode
    {
        public SC_Character selectedCharacter;
        public SC_CharacterExpression characterMood;
        [TextArea] public string dialogText;

        private StoryGraph parentGraph;

        protected override void Init() {
            parentGraph = graph as StoryGraph;
            if (selectedCharacter == null)
            {
                selectedCharacter = parentGraph.defaultCharacter;
                characterMood = parentGraph.defaultExpression;
            }
        }
    }
}