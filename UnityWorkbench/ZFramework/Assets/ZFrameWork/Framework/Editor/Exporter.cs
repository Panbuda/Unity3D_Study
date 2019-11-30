using UnityEditor;
using UnityEngine;

namespace ZFramework
{
	public class Exporter
	{
		[MenuItem("ZFramework/Framework/Editor/OutputZFramework %e")]
		static void MenuClicked()
		{
			string docName = "ZFramework_" + System.DateTime.Now.ToString("yyyyMMdd_HH") + ".unitypackage";
			ExportPackage("Assets/ZFramework", "D:/CoderLife/Unity3D_Study/ZFramework/" + docName);
			RunBat("UnityGitPush", docName);
		}
		public static void ExportPackage(string assetURL, string fileURL)
		{
			AssetDatabase.ExportPackage(assetURL, fileURL, ExportPackageOptions.Recurse);
		}
		public static void OpenFileMenu(string fileURL)
		{
			Application.OpenURL(fileURL);
		}
		//调用批处理文件
		private static System.Diagnostics.Process CreateShellExProcess(string cmd, string args, string workingDir = "")
		{
			var pStartInfo = new System.Diagnostics.ProcessStartInfo(cmd);
			pStartInfo.Arguments = args;
			pStartInfo.CreateNoWindow = false;
			pStartInfo.UseShellExecute = true;
			pStartInfo.RedirectStandardError = false;
			pStartInfo.RedirectStandardInput = false;
			pStartInfo.RedirectStandardOutput = false;
			if (!string.IsNullOrEmpty(workingDir))
				pStartInfo.WorkingDirectory = workingDir;
			return System.Diagnostics.Process.Start(pStartInfo);
		}

		private static void RunBat(string batfile, string args, string workingDir = "")
		{
			var p = CreateShellExProcess(batfile, args, workingDir);
			p.Close();
		}
	}
}

