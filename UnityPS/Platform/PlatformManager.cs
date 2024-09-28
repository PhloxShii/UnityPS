using System;
using UnityEngine;

namespace UnityPS.Platform
{
	// Token: 0x02000021 RID: 33
	public class PlatformManager : MonoBehaviour
	{
		// Token: 0x060000D6 RID: 214 RVA: 0x000040BC File Offset: 0x000022BC
		private void Awake()
		{
			if (!PlatformManager.m_Initialised)
			{
				PlatformManager.FileSystem = new DesktopFileSystem();
				PlatformManager.UserAccount = new UserAccount();
				PlatformManager.VirtualKeyboard = new VirtualKeyboard();
				PlatformManager.UserAccount.Initialize();
				PlatformManager.VirtualKeyboard.Initialize();
				PlatformManager.m_Initialised = true;
			}
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00004108 File Offset: 0x00002308
		private void Update()
		{
			bool initialised = PlatformManager.m_Initialised;
		}

		// Token: 0x04000046 RID: 70
		private static bool m_Initialised;

		// Token: 0x04000047 RID: 71
		public static UserAccount UserAccount;

		// Token: 0x04000048 RID: 72
		public static VirtualKeyboard VirtualKeyboard;

		// Token: 0x04000049 RID: 73
		public static IFileSystem FileSystem;
	}
}
