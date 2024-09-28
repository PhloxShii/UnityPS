using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using UnityEngine;

namespace UnityPS.Platform
{
	// Token: 0x02000020 RID: 32
	public class DesktopFileSystem : IFileSystem
	{
		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x00003F18 File Offset: 0x00002118
		// (set) Token: 0x060000C7 RID: 199 RVA: 0x00003F20 File Offset: 0x00002120
		public int ActiveBlockCount { get; private set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000C8 RID: 200 RVA: 0x00003F29 File Offset: 0x00002129
		public string PersistentDataPath
		{
			get
			{
				return Application.persistentDataPath;
			}
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00003F30 File Offset: 0x00002130
		public Task<Stream> Open(string path, FileAccess access, FileMode mode)
		{
			return Task.Factory.StartNew(() => (Stream)new FileStream(path, mode, access));
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00002E24 File Offset: 0x00001024
		public void Touch(string path)
		{
			using (File.Open(path, FileMode.OpenOrCreate, FileAccess.Read)) { }
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00002E2B File Offset: 0x0000102B
		public IFormatter BuildBinaryFormatter()
		{
			return new BinaryFormatter();
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00003FBC File Offset: 0x000021BC
		public void Delete(string path)
		{
			File.Delete(path);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00003FC4 File Offset: 0x000021C4
		public Task<bool> Exists(string path)
		{
			return Task.Factory.StartNew(() => File.Exists(path));
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00004009 File Offset: 0x00002209
		public DateTime GetLastWriteTime(string path)
		{
			return File.GetLastWriteTime(path);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00004011 File Offset: 0x00002211
		public void MakeDirectories(string path)
		{
			Directory.CreateDirectory(path);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000401A File Offset: 0x0000221A
		public string[] GetDirectories(string path)
		{
			return Directory.GetDirectories(path);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00004022 File Offset: 0x00002222
		public string[] GetFiles(string path, string search)
		{
			return Directory.GetFiles(path, search);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00002E2B File Offset: 0x0000102B
		public IFileSystem GetUnderlyingSystem()
		{
			return this;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000402C File Offset: 0x0000222C
		public Task StartWriteBlock()
		{
			return Task.Factory.StartNew(() => { });
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00004074 File Offset: 0x00002274
		public Task EndWriteBlock()
		{
			return Task.Factory.StartNew(() => { });
		}
	}
}
