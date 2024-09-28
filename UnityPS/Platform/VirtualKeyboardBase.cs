using System;

namespace UnityPS.Platform
{
	// Token: 0x02000024 RID: 36
	public abstract class VirtualKeyboardBase
	{
		// Token: 0x060000DD RID: 221
		public abstract void Initialize();

		// Token: 0x060000DE RID: 222
		protected abstract void ShowNative(string title, string defaultText, uint maxLength);

		// Token: 0x060000DF RID: 223 RVA: 0x00004110 File Offset: 0x00002310
		public void Show(string title, string defaultText, uint maxLength, VirtualKeyboardBase.OnVirtualKeyboardInputCallback callback)
		{
			if (this.m_Callback != null)
			{
				throw new Exception("virtual keyboard is already active");
			}
			this.m_Callback = callback;
			this.ShowNative(title, defaultText, maxLength);
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00004136 File Offset: 0x00002336
		protected void SendResult(string result)
		{
			VirtualKeyboardBase.OnVirtualKeyboardInputCallback callback = this.m_Callback;
			if (callback != null)
			{
				callback(result);
			}
			this.m_Callback = null;
		}

		// Token: 0x0400004A RID: 74
		protected VirtualKeyboardBase.OnVirtualKeyboardInputCallback m_Callback;

		// Token: 0x02000037 RID: 55
		// (Invoke) Token: 0x0600010B RID: 267
		public delegate void OnVirtualKeyboardInputCallback(string result);
	}
}
