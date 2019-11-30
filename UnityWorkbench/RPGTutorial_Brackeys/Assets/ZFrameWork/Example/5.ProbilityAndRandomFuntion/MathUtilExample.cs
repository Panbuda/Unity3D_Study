#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
namespace ZFramework
{
	public partial class MathUtilExample
	{
		[MenuItem("ZFramework/Example/ProbilityAndRandomFuntion")]
		static void MenuItemClicked()
		{
			Debug.Log(MathUtil.Percent(20));
			Debug.Log(MathUtil.RandomValueFromValues<int>(2, 5, 8, 10));
		}
	}
}

