using System;
using System.Collections.Generic;

namespace UnityPS.Pool
{
	// Token: 0x0200001E RID: 30
	public class Pool<T> where T : class
	{
		// Token: 0x060000BC RID: 188 RVA: 0x00003E04 File Offset: 0x00002004
		public Pool(Func<T> ctor, Action<T> free, int defaultSize, Action onFull = null)
		{
			this.m_Free = free;
			this.m_Full = onFull;
			this.m_Pool = new List<PoolHandle<T>>(defaultSize);
			for (int i = 0; i < defaultSize; i++)
			{
				PoolHandle<T> item = new PoolHandle<T>(ctor());
				this.m_Pool.Add(item);
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00003E56 File Offset: 0x00002056
		public PoolHandle<T> Allocate()
		{
			PoolHandle<T> poolHandle = this.NextFree();
			poolHandle.Allocate();
			return poolHandle;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00003E64 File Offset: 0x00002064
		public void Release(PoolHandle<T> t)
		{
			this.m_Free(t.Ref);
			t.Release();
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00003E80 File Offset: 0x00002080
		private PoolHandle<T> NextFree()
		{
			for (int i = 0; i < this.m_Pool.Count; i++)
			{
				if (!this.m_Pool[i].Allocated)
				{
					return this.m_Pool[i];
				}
			}
			Action full = this.m_Full;
			if (full != null)
			{
				full();
			}
			throw new InvalidOperationException("Pool Maxmium Size Reached");
		}

		// Token: 0x04000040 RID: 64
		private List<PoolHandle<T>> m_Pool;

		// Token: 0x04000041 RID: 65
		private Action<T> m_Free;

		// Token: 0x04000042 RID: 66
		private Action m_Full;
	}
}
