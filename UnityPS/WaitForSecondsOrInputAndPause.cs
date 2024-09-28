using System;
using UnityEngine;

namespace UnityPS
{
	// Token: 0x0200001B RID: 27
	public class WaitForSecondsOrInputAndPause : CustomYieldInstruction
	{
		// Token: 0x060000B2 RID: 178 RVA: 0x00003799 File Offset: 0x00001999
		public WaitForSecondsOrInputAndPause(float seconds, Func<bool> onInput)
		{
			this.waitTime = seconds;
			this.m_OnInput = onInput;
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x000037AF File Offset: 0x000019AF
		public override bool keepWaiting
		{
			get
			{
				if (!PauseManager.IsPaused)
				{
					this.waitTime -= Time.deltaTime;
					return this.waitTime > 0f && !this.m_OnInput();
				}
				return true;
			}
		}

		// Token: 0x0400003C RID: 60
		public float waitTime;

		// Token: 0x0400003D RID: 61
		private Func<bool> m_OnInput;
	}
}
