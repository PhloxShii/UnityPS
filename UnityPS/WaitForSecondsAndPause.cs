using System;
using UnityEngine;

namespace UnityPS
{
	// Token: 0x0200001A RID: 26
	public class WaitForSecondsAndPause : CustomYieldInstruction
	{
		// Token: 0x060000B0 RID: 176 RVA: 0x00003760 File Offset: 0x00001960
		public WaitForSecondsAndPause(float seconds)
		{
			this.waitTime = seconds;
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x0000376F File Offset: 0x0000196F
		public override bool keepWaiting
		{
			get
			{
				if (!PauseManager.IsPaused)
				{
					this.waitTime -= Time.deltaTime;
					return this.waitTime > 0f;
				}
				return true;
			}
		}

		// Token: 0x0400003B RID: 59
		public float waitTime;
	}
}
