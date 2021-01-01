using UnityEngine;

namespace SimpleChoicesVN_JB
{
	[CreateAssetMenu(menuName = "SimpleChoicesVN/ParsingDataStore")]
	public class SC_ParsingDataStore : ScriptableObject
	{
		static NamedString location = new NamedString("location", "|LOCATION|");
		static NamedString choice = new NamedString("choice","|CHOICE|");
		static NamedString branch = new NamedString("branch","|GOTO|");
		static NamedString check = new NamedString("check","|IF|");
		static NamedString label = new NamedString("label","|LABEL");
		static NamedString item = new NamedString("item","|ITEM|");

		[SerializeField]
		public NamedString[] directiveEnum= { location, choice,branch,check,label,item};
		public string directiveDelimiter = "|";
		public string variableTag="$";
		public string variationTag = "_";
		public string separationTag = ":";
		public string thoughtTag = "!";
		public string expSeparationTag = "*";
		public string inventoryTag = "INV";
	}
}