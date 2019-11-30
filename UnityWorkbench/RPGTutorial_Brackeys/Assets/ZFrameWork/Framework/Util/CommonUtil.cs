using UnityEngine;
using System.Diagnostics;
using System;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ZFramework
{
	public class CommonUtil
	{
		//复制文本到剪贴板
		public static void CopyString(string m)
		{
			GUIUtility.systemCopyBuffer = m;
		}
	}
}

