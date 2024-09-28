using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityPS.Pool;

namespace UnityPS
{
	// Token: 0x0200000E RID: 14
	public class CoroutineManager : MonoBehaviour
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600003F RID: 63 RVA: 0x0000267B File Offset: 0x0000087B
		// (set) Token: 0x06000040 RID: 64 RVA: 0x00002682 File Offset: 0x00000882
		private static CoroutineManager Instance { get; set; }

		// Token: 0x06000041 RID: 65 RVA: 0x0000268A File Offset: 0x0000088A
		private void OnEnable()
		{
			if (CoroutineManager.Instance != null && CoroutineManager.Instance != this)
			{
				Debug.Log("multiple coroutinemanager instances");
			}
			CoroutineManager.Instance = this;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000026B6 File Offset: 0x000008B6
		private void OnDisable()
		{
			if (CoroutineManager.Instance == this)
			{
				CoroutineManager.Instance = null;
				CoroutineManager.Coroutines.Clear();
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000026D8 File Offset: 0x000008D8
		public static bool IsCoroutineActive(CoroutineID id)
		{
			PoolHandle<CoroutineManager.CoroutineInfo> poolHandle;
			if (CoroutineManager.Coroutines.TryGetValue(id, out poolHandle))
			{
				return poolHandle.Ref.Coroutine.Ref.Target != null;
			}
			return false;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002710 File Offset: 0x00000910
		public static CoroutineID AllocateCoroutine(CoroutineFlags flags)
		{
			PoolHandle<CoroutineManager.CoroutineInfo> poolHandle = CoroutineManager.CreateCoroutineInfo(flags);
			CoroutineManager.Coroutines.Add(poolHandle.Ref.ID, poolHandle);
			return poolHandle.Ref.ID;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002748 File Offset: 0x00000948
		public static CoroutineID StartCoroutine(Func<CoroutineID, IEnumerator> coroutine, CoroutineFlags flags)
		{
			PoolHandle<CoroutineManager.CoroutineInfo> poolHandle = CoroutineManager.CreateCoroutineInfo(flags);
			CoroutineManager.Coroutines.Add(poolHandle.Ref.ID, poolHandle);
			return CoroutineManager.StartCoroutine(poolHandle.Ref.ID, coroutine(poolHandle.Ref.ID));
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002794 File Offset: 0x00000994
		public static CoroutineID StartCoroutine(CoroutineID id, IEnumerator coroutine)
		{
			if (CoroutineManager.Instance != null)
			{
				PoolHandle<CoroutineManager.CoroutineInfo> poolHandle;
				if (CoroutineManager.Coroutines.TryGetValue(id, out poolHandle))
				{
					poolHandle.Ref.Coroutine.Ref.Target = coroutine;
					IEnumerator routine = poolHandle.Ref.Coroutine.Ref.Target as IEnumerator;
					if (routine != null)
					{
						CoroutineManager.Instance.StartCoroutine(routine);
						return poolHandle.Ref.ID;
					}
				}
			}
			return CoroutineID.InvalidCoroutineID;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002810 File Offset: 0x00000A10
		public static Coroutine StartCoroutineEx(Func<CoroutineID, IEnumerator> coroutine, CoroutineFlags flags)
		{
			PoolHandle<CoroutineManager.CoroutineInfo> poolHandle = CoroutineManager.CreateCoroutineInfo(flags);
			CoroutineManager.Coroutines.Add(poolHandle.Ref.ID, poolHandle);
			return CoroutineManager.StartCoroutineEx(poolHandle.Ref.ID, coroutine(poolHandle.Ref.ID));
		}

		// Token: 0x06000048 RID: 72 RVA: 0x0000285C File Offset: 0x00000A5C
		public static Coroutine StartCoroutineEx(CoroutineID id, IEnumerator coroutine)
		{
			if (CoroutineManager.Instance != null)
			{
				PoolHandle<CoroutineManager.CoroutineInfo> poolHandle;
				if (CoroutineManager.Coroutines.TryGetValue(id, out poolHandle))
				{
					poolHandle.Ref.Coroutine.Ref.Target = coroutine;
					IEnumerator routine = poolHandle.Ref.Coroutine.Ref.Target as IEnumerator;
					if (routine != null)
					{
						return CoroutineManager.Instance.StartCoroutine(routine);
					}
				}
			}
			return null;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x000028C4 File Offset: 0x00000AC4
		private static PoolHandle<CoroutineManager.CoroutineInfo> CreateCoroutineInfo(CoroutineFlags flags)
		{
			CoroutineID id = CoroutineManager.GenerateID();
			PoolHandle<WeakReference> coroutine = CoroutineManager.Instance.m_WeakReferences.Allocate();
			PoolHandle<CoroutineManager.CoroutineInfo> poolHandle = CoroutineManager.Instance.m_CorouteInfos.Allocate();
			poolHandle.Ref.Coroutine = coroutine;
			poolHandle.Ref.ID = id;
			poolHandle.Ref.Flags = flags;
			return poolHandle;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x0000291C File Offset: 0x00000B1C
		public static bool UnregisterCoroutine(CoroutineID id)
		{
			PoolHandle<CoroutineManager.CoroutineInfo> poolHandle;
			if (CoroutineManager.Coroutines.TryGetValue(id, out poolHandle))
			{
				CoroutineManager.Coroutines.Remove(id);
				CoroutineManager.Instance.m_WeakReferences.Release(poolHandle.Ref.Coroutine);
				CoroutineManager.Instance.m_CorouteInfos.Release(poolHandle);
				return true;
			}
			return false;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002974 File Offset: 0x00000B74
		public static bool StopCoroutine(CoroutineID id)
		{
			PoolHandle<CoroutineManager.CoroutineInfo> info;
			if (CoroutineManager.Coroutines.TryGetValue(id, out info))
			{
				CoroutineManager.StopCoroutine(info);
				return true;
			}
			return false;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x0000299C File Offset: 0x00000B9C
		public static void StopCoroutinesWithAllFlags(CoroutineFlags flags)
		{
			CoroutineManager.s_processList.Clear();
			foreach (PoolHandle<CoroutineManager.CoroutineInfo> poolHandle in CoroutineManager.Coroutines.Values)
			{
				if ((poolHandle.Ref.Flags & flags) == flags)
				{
					CoroutineManager.s_processList.Add(poolHandle);
				}
			}
			foreach (PoolHandle<CoroutineManager.CoroutineInfo> info in CoroutineManager.s_processList)
			{
				CoroutineManager.StopCoroutine(info);
			}
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002A50 File Offset: 0x00000C50
		public static void StopCoroutinesWithAnyFlag(CoroutineFlags flags)
		{
			CoroutineManager.s_processList.Clear();
			foreach (PoolHandle<CoroutineManager.CoroutineInfo> poolHandle in CoroutineManager.Coroutines.Values)
			{
				if ((poolHandle.Ref.Flags & flags) != CoroutineFlags.None)
				{
					CoroutineManager.s_processList.Add(poolHandle);
				}
			}
			foreach (PoolHandle<CoroutineManager.CoroutineInfo> info in CoroutineManager.s_processList)
			{
				CoroutineManager.StopCoroutine(info);
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002B04 File Offset: 0x00000D04
		private static void StopCoroutine(PoolHandle<CoroutineManager.CoroutineInfo> info)
		{
			if (CoroutineManager.Instance != null)
			{
				IEnumerator routine = info.Ref.Coroutine.Ref.Target as IEnumerator;
				if (routine != null)
				{
					CoroutineManager.Instance.StopCoroutine(routine);
				}
				CoroutineManager.Coroutines.Remove(info.Ref.ID);
				CoroutineManager.Instance.m_WeakReferences.Release(info.Ref.Coroutine);
				CoroutineManager.Instance.m_CorouteInfos.Release(info);
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002B82 File Offset: 0x00000D82
		private static CoroutineID GenerateID()
		{
			CoroutineID nextID = CoroutineManager.NextID;
			CoroutineManager.NextID = ++nextID;
			return nextID;
		}

		// Token: 0x0400001F RID: 31
		private const int MaxCoroutines = 50;

		// Token: 0x04000020 RID: 32
		private Pool<WeakReference> m_WeakReferences = new Pool<WeakReference>(() => new WeakReference(null), delegate(WeakReference reference)
		{
			reference.Target = null;
		}, 50, null);

		// Token: 0x04000021 RID: 33
		private Pool<CoroutineManager.CoroutineInfo> m_CorouteInfos = new Pool<CoroutineManager.CoroutineInfo>(() => new CoroutineManager.CoroutineInfo(), delegate(CoroutineManager.CoroutineInfo info)
		{
			info.Coroutine = null;
			info.Flags = CoroutineFlags.None;
			info.ID = CoroutineID.InvalidCoroutineID;
		}, 50, null);

		// Token: 0x04000022 RID: 34
		private static CoroutineID NextID = new CoroutineID(1UL);

		// Token: 0x04000023 RID: 35
		private static Dictionary<CoroutineID, PoolHandle<CoroutineManager.CoroutineInfo>> Coroutines = new Dictionary<CoroutineID, PoolHandle<CoroutineManager.CoroutineInfo>>();

		// Token: 0x04000025 RID: 37
		private static List<PoolHandle<CoroutineManager.CoroutineInfo>> s_processList = new List<PoolHandle<CoroutineManager.CoroutineInfo>>();

		// Token: 0x0200002A RID: 42
		private class CoroutineInfo
		{
			// Token: 0x0400005B RID: 91
			public CoroutineID ID;

			// Token: 0x0400005C RID: 92
			public CoroutineFlags Flags;

			// Token: 0x0400005D RID: 93
			public PoolHandle<WeakReference> Coroutine; // Change this line
		}
	}
}
