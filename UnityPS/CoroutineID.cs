using System;

namespace UnityPS
{
	// Token: 0x0200000D RID: 13
	public struct CoroutineID : IEquatable<CoroutineID>
	{
		// Token: 0x06000036 RID: 54 RVA: 0x000025E5 File Offset: 0x000007E5
		public CoroutineID(ulong id)
		{
			this.ID = id;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000025EE File Offset: 0x000007EE
		public override bool Equals(object a)
		{
			return a is CoroutineID && this.Equals((CoroutineID)a);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002606 File Offset: 0x00000806
		public bool Equals(CoroutineID a)
		{
			return a.ID == this.ID;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002616 File Offset: 0x00000816
		public override int GetHashCode()
		{
			return this.ID.GetHashCode();
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002623 File Offset: 0x00000823
		public static bool operator ==(CoroutineID a, CoroutineID b)
		{
			return a.ID == b.ID;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002633 File Offset: 0x00000833
		public static bool operator !=(CoroutineID a, CoroutineID b)
		{
			return a.ID != b.ID;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002646 File Offset: 0x00000846
		public static CoroutineID operator ++(CoroutineID a)
		{
			a.ID += 1UL;
			return a;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002656 File Offset: 0x00000856
		public override string ToString()
		{
			return "CoroutineID - " + this.ID.ToString();
		}

		// Token: 0x0400001D RID: 29
		private ulong ID;

		// Token: 0x0400001E RID: 30
		public static CoroutineID InvalidCoroutineID = new CoroutineID(0UL);
	}
}
