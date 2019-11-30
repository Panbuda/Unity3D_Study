#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
namespace ZFramework
{
	//引用菜单项
	public partial class EditorUtilExample
	{
		[MenuItem("ZFramework/Example/AutoUseMenu")]
#if UNITY_EDITOR
		static void MenuClicked()
		{
			EditorUtil.ExcuteMenu("ZFramework/Example/CopyText");
		}
#endif
	}
}
