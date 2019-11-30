using UnityEngine;

namespace ZFramework
{
	//简化Transform的操作
	public class TransformUtil
	{
		public static void SetLocalPosX(Transform tr, float x)
		{
			var localPos = tr.localPosition;
			localPos.x = x;
			tr.localPosition = localPos;
		}
		public static void SetLocalPosY(Transform tr, float x)
		{
			var localPos = tr.localPosition;
			localPos.y = x;
			tr.localPosition = localPos;
		}
		public static void SetLocalPosZ(Transform tr, float x)
		{
			var localPos = tr.localPosition;
			localPos.z = x;
			tr.localPosition = localPos;
		}
		public static void SetLocalPosXY(Transform tr, float x, float y)
		{
			var localPos = tr.localPosition;
			localPos.x = x;
			localPos.y = y;
			tr.localPosition = localPos;
		}
		public static void SetLocalPosXZ(Transform tr, float x, float z)
		{
			var localPos = tr.localPosition;
			localPos.x = x;
			localPos.z = z;
			tr.localPosition = localPos;
		}
		public static void SetLocalPosYZ(Transform tr, float y, float z)
		{
			var localPos = tr.localPosition;
			localPos.z = z;
			localPos.y = y;
			tr.localPosition = localPos;
		}
	}
}

