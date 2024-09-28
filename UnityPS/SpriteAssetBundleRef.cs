using System;
using UnityEngine;

namespace UnityPS
{
	// Token: 0x02000009 RID: 9
	[Serializable]
	public class SpriteAssetBundleRef
	{
		// Token: 0x0600002C RID: 44 RVA: 0x000024EF File Offset: 0x000006EF
		public bool HasImage()
		{
			return !string.IsNullOrEmpty(this.AssetName);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000024FF File Offset: 0x000006FF
		public Sprite Load(AssetBundle assetBundle)
		{
			return assetBundle.LoadAsset<Sprite>(this.AssetName);
		}

		// Token: 0x04000014 RID: 20
		[HideInInspector]
		public string AssetName;

		// Token: 0x04000015 RID: 21
		[HideInInspector]
		public string AssetDatabaseGUID;

		// Token: 0x04000016 RID: 22
		[HideInInspector]
		public string AssetBundleName;
	}
}
