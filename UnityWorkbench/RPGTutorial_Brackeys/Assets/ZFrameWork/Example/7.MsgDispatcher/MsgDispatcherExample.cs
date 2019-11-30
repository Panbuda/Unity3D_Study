namespace ZFramework
{
	public partial class MsgDispatcherExample
	{
#if UNITY_EDITOR
		[UnityEditor.MenuItem("ZFramework/Example/MsgDispatcher")]
		static void MenuItemClicked()
		{
			MsgDispatcher.Register("test", testFunc);
			MsgDispatcher.Register("test", testFunc);
			MsgDispatcher.SendMsg("test", "test1");
			MsgDispatcher.UnRegister("test", testFunc);
			MsgDispatcher.SendMsg("test", "test2");
			MsgDispatcher.UnRegisterAll("test");
		}

		static void testFunc(object s)
		{
			UnityEngine.Debug.Log("SimpleMsgDispatcher is succeed! data: " + s);
		}
#endif
	}
}


