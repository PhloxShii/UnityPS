using System;

namespace UnityPS.Platform
{
	// Token: 0x02000025 RID: 37
	public class VirtualKeyboard : VirtualKeyboardBase
	{
		// Token: 0x060000E2 RID: 226 RVA: 0x00002282 File Offset: 0x00000482
		public override void Initialize()
		{
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00004151 File Offset: 0x00002351
		protected override void ShowNative(string title, string defaultText, uint maxLength)
		{
			throw new NotImplementedException("virtual keyboard not implemented for platform");
		}
	}
}
