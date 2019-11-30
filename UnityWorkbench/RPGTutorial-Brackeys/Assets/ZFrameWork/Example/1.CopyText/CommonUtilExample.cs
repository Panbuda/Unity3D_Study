#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ZFramework {
	public partial class CommonUtilExample
	{
		[MenuItem("ZFramework/Example/CopyText")]
#if UNITY_EDITOR
		private static void MenuClicked()
		{
			CommonUtil.CopyString("ZFramework_" + System.DateTime.Now.ToString("yyyyMMdd_HH"));
		}
#endif
	}
}

