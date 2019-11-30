#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
namespace ZFramework
{
	public class ResolutionCheckExample
	{
		[MenuItem("ZFramework/Example/CheckResolutionRatio")]
#if UNITY_EDITOR
		static void MenuClicked()
		{
			Debug.Log(ResolutionCheck.CheckResolutionRatio());
		}
#endif
	}
}
