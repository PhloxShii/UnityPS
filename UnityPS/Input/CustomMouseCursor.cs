using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityPS.Input
{
	// Token: 0x02000026 RID: 38
	public class CustomMouseCursor : MonoBehaviour
	{
		// Token: 0x060000E5 RID: 229 RVA: 0x00004165 File Offset: 0x00002365
		public void EnableCustomCursor()
		{
			this.m_CurrentFrame = 0;
			this.m_Enabled = true;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00004175 File Offset: 0x00002375
		public void DisableCustomCursor()
		{
			Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
			this.m_Enabled = false;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000418C File Offset: 0x0000238C
		private void ApplyFrame(int idx)
		{
			if (idx < this.MouseCursors.Count)
			{
				Vector2 hotspot;
				hotspot.x = this.MouseCursors[idx].bounds.size.x * 0.5f;
				hotspot.y = this.MouseCursors[idx].bounds.size.y * 0.5f;
				Cursor.SetCursor(this.MouseCursors[idx].texture, hotspot, CursorMode.Auto);
			}
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00004218 File Offset: 0x00002418
		private void Update()
		{
			if (this.m_Enabled)
			{
				this.m_AccumulatedDT += Time.deltaTime;
				if (this.m_AccumulatedDT > this.FrameStepSeconds)
				{
					this.m_CurrentFrame++;
					if (this.m_CurrentFrame >= this.MouseCursors.Count)
					{
						this.m_CurrentFrame = 0;
					}
					this.ApplyFrame(this.m_CurrentFrame);
					this.m_AccumulatedDT = 0f;
				}
			}
		}

		// Token: 0x0400004B RID: 75
		public List<Sprite> MouseCursors;

		// Token: 0x0400004C RID: 76
		public float FrameStepSeconds;

		// Token: 0x0400004D RID: 77
		private int m_CurrentFrame;

		// Token: 0x0400004E RID: 78
		private bool m_Enabled;

		// Token: 0x0400004F RID: 79
		private float m_AccumulatedDT;
	}
}
