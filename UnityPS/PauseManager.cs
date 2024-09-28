using System;

namespace UnityPS
{
	// Token: 0x02000018 RID: 24
	public static class PauseManager
	{
		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000AD RID: 173 RVA: 0x00003741 File Offset: 0x00001941
		public static bool IsPaused
		{
			get
			{
				return PauseManager.Paused || PauseManager.InputUnavailable;
			}
		}

		// Token: 0x04000039 RID: 57
		public static bool Paused;

		// Token: 0x0400003A RID: 58
		public static bool InputUnavailable;
	}
}
