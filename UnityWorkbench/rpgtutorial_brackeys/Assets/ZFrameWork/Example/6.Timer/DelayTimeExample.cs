#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace ZFramework
{
	public class DelayTimeExample : ZMonoBehaviour
	{
		[MenuItem("ZFramework/Example/Timer")]
#if UNITY_EDITOR
		private static void MenuClicked()
		{
			EditorApplication.isPlaying = true;
			new GameObject().AddComponent<DelayTimeExample>();
		}

		static void TestFunc()
		{
			Debug.Log("Test is succeeded!");
		}
#endif
		private void Start()
		{
			Delay(5, TestFunc);
		}
	}
}