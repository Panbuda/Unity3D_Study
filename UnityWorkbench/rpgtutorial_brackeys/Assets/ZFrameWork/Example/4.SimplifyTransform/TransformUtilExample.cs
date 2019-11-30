using UnityEngine;
namespace ZFramework
{
	public class TransformUtilExample
	{
#if UNITY_EDITOR
		[UnityEditor.MenuItem("ZFramework/Example/SimplifyTransform")]
		static void MenuItemClicked()
		{
			Transform testTr = new GameObject().transform;
			TransformUtil.SetLocalPosXY(testTr, 5, 6);
		}
#endif
	}
}

