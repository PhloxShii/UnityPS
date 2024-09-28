using System;
using UnityEngine;

namespace UnityPS
{
	// Token: 0x0200001C RID: 28
	public class WaitForInputAndPause : CustomYieldInstruction
	{
		// Token: 0x060000B4 RID: 180 RVA: 0x000037E9 File Offset: 0x000019E9
		public WaitForInputAndPause(Func<bool> onInput)
		{
			this.m_OnInput = onInput;
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x000037F8 File Offset: 0x000019F8
		public override bool keepWaiting
		{
			get
			{
				return PauseManager.IsPaused || !this.m_OnInput();
			}
		}

		// Token: 0x0400003E RID: 62
		public float waitTime;

		// Token: 0x0400003F RID: 63
		private Func<bool> m_OnInput;
	}
}
