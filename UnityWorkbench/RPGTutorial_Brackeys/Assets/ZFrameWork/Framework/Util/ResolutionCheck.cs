using UnityEngine;

namespace ZFramework
{
	public enum ResolutionRatio
	{
		R16_9,
		R16_10,
		R4_3,
		OTHER
	}
	public class ResolutionCheck
	{
		public static ResolutionRatio CheckResolutionRatio()
		{
			var ratio = (float)Screen.width / Screen.height;
			if (Mathf.Abs(ratio - (float)16 / 9) < 0.01)
				return ResolutionRatio.R16_9;
			else if (Mathf.Abs(ratio - (float)16 / 10) < 0.01)
				return ResolutionRatio.R16_10;
			else if (Mathf.Abs(ratio - (float)4 / 3) < 0.01)
				return ResolutionRatio.R4_3;
			else
				return ResolutionRatio.OTHER;
		}
	}
}

