using UnityEngine;

namespace ZFramework
{
	public class MathUtil
	{
		//概率函数
		public static bool Percent(int percent)
		{
			return Random.Range(0, 100) <= percent;
		}
		//随机函数
		public static T RandomValueFromValues<T>(params T[] values)
		{
			return values[Random.Range(0, values.Length)];
		}
	}
}

