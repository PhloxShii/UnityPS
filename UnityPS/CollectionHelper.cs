using System;
using System.Collections.Generic;

namespace UnityPS
{
	// Token: 0x0200000B RID: 11
	public static class CollectionHelper
	{
		// Token: 0x06000035 RID: 53 RVA: 0x000025C4 File Offset: 0x000007C4
		public static void Skip<T>(int count, ref IEnumerator<T> enumerator)
		{
			for (int i = 0; i < count; i++)
			{
				enumerator.MoveNext();
			}
		}
	}
}
