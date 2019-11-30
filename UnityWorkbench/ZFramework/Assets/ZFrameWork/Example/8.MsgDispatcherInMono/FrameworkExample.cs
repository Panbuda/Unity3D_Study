using UnityEngine;

namespace ZFramework
{
	public partial class FrameworkExample : ZMonoBehaviour
	{
#if UNITY_EDITOR
		[UnityEditor.MenuItem("ZFramework/Example/MsgDispatcherInMono")]
		static void MenuItemClicked()
		{
			new GameObject().AddComponent<FrameworkExample>();
			UnityEditor.EditorApplication.isPlaying = true;
		}
#endif
		private void Start()
		{
			RegistMsg("test1", _ => { Debug.Log("test1"); });
			RegistMsg("test2", _ => { Debug.Log("test2"); });
			RegistMsg("test3", _ => { Debug.Log("test3"); });
			RegistMsg("test4", _ => { Debug.Log("test4"); });
			SendMsg("test1", "data");
			UnregistMsgAll("test1");
			SendMsg("test1", "data");
		}
	}
}
