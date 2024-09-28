using System;

namespace UnityPS.Pool
{
	// Token: 0x0200001F RID: 31
	public class PoolHandle<T> where T : class
	{
		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x00003EDE File Offset: 0x000020DE
		// (set) Token: 0x060000C1 RID: 193 RVA: 0x00003EE6 File Offset: 0x000020E6
		public bool Allocated { get; private set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x00003EEF File Offset: 0x000020EF
		public T Ref { get; }

		// Token: 0x060000C3 RID: 195 RVA: 0x00003EF7 File Offset: 0x000020F7
		public PoolHandle(T t)
		{
			this.Ref = t;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00003F06 File Offset: 0x00002106
		public void Release()
		{
			this.Allocated = false;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00003F0F File Offset: 0x0000210F
		public void Allocate()
		{
			this.Allocated = true;
		}
	}
}
