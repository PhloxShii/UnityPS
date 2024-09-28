using System;
using UnityEngine;

namespace UnityPS
{
	// Token: 0x02000014 RID: 20
	public static class GameObjectHelpers
	{
		// Token: 0x0600009C RID: 156 RVA: 0x00003118 File Offset: 0x00001318
		public static void DestroyChildren(this GameObject go)
		{
			for (int i = 0; i < go.transform.childCount; i++)
			{
				GameObject gameObject = go.transform.GetChild(i).gameObject;
				gameObject.SetActive(false);
				UnityEngine.Object.Destroy(gameObject);
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00003158 File Offset: 0x00001358
		public static void DestroyChildIfOnlyChild(this GameObject go)
		{
			if (go.transform.childCount == 1)
			{
				go.DestroyChildren();
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00003170 File Offset: 0x00001370
		public static int ChildCountRecursive(this GameObject go)
		{
			if (go == null || go.transform == null)
			{
				return 0;
			}
			int num = go.transform.childCount;
			for (int i = 0; i < go.transform.childCount; i++)
			{
				num += go.transform.GetChild(i).gameObject.ChildCountRecursive();
			}
			return num;
		}
	}
}
