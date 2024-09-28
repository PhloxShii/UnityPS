using System;
using UnityEngine;

namespace UnityPS
{
	// Token: 0x02000019 RID: 25
	public class WaitForPause : CustomYieldInstruction
	{
		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000AE RID: 174 RVA: 0x00003751 File Offset: 0x00001951
		public override bool keepWaiting
		{
			get
			{
				return PauseManager.IsPaused;
			}
		}
	}
}
