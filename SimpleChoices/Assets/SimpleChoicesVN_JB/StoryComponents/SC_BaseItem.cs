using UnityEngine;

namespace SimpleChoicesVN_JB
{
	[CreateAssetMenu(menuName = "SimpleChoicesVN/BaseItem")]
	public class SC_BaseItem : ScriptableObject
	{
		public Color color;
		public string fullName;
		public string cfName;
		public string aka;
		public string imagePath;
	}
}