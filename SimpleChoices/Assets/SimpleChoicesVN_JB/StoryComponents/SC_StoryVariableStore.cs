using UnityEngine;

namespace SimpleChoicesVN_JB
{
	[CreateAssetMenu(menuName = "SimpleChoicesVN/StoryVariableStore")]
	public class SC_StoryVariableStore : ScriptableObject
	{
		[SerializeField]
		public NamedBoolean[] booleanVariables;
		[SerializeField]
		public NamedString[] stringVariables;
		[SerializeField]
		public NamedInteger[] integerVariables;
	}
	[System.Serializable]
	public class NamedBoolean
    {
		public string variableName;
		public bool value;
    }
	[System.Serializable]
	public class NamedString
	{
		public string variableName;
		public string value;

        public NamedString(string v1, string v2)
        {
            this.variableName = v1;
            this.value = v2;
        }
    }
	[System.Serializable]
	public class NamedInteger
	{
		public string variableName;
		public int value;
	}
}