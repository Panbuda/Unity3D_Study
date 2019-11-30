#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
namespace ZFramework
{
	public class EditorUtil
	{
		//引用菜单项
#if UNITY_EDITOR
		public static void ExcuteMenu(string item)
		{
			EditorApplication.ExecuteMenuItem(item);
		}
#endif
	}
}

