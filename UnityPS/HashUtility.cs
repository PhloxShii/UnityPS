using System;
using System.Text;

namespace UnityPS
{
	// Token: 0x02000016 RID: 22
	public class HashUtility
	{
		// Token: 0x060000A3 RID: 163 RVA: 0x00003648 File Offset: 0x00001848
		public static uint FNV_1a(string targetString)
		{
			uint num = 2166136261U;
			for (int i = 0; i < targetString.Length; i++)
			{
				num ^= (uint)targetString[i];
				num *= 16777619U;
			}
			return num;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00003680 File Offset: 0x00001880
		public static uint FNV_1a(StringBuilder targetString)
		{
			uint num = 2166136261U;
			for (int i = 0; i < targetString.Length; i++)
			{
				num ^= (uint)targetString[i];
				num *= 16777619U;
			}
			return num;
		}

		// Token: 0x04000032 RID: 50
		private const uint k_FNV_1_32BitOffset = 2166136261U;

		// Token: 0x04000033 RID: 51
		private const uint k_FNV_1_Prime = 16777619U;
	}
}
