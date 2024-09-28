using System;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace UnityPS
{
	// Token: 0x02000011 RID: 17
	public interface IFileSystem
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000073 RID: 115
		string PersistentDataPath { get; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000074 RID: 116
		int ActiveBlockCount { get; }

		// Token: 0x06000075 RID: 117
		Task<Stream> Open(string path, FileAccess access, FileMode mode);

		// Token: 0x06000076 RID: 118
		void Touch(string path);

		// Token: 0x06000077 RID: 119
		IFormatter BuildBinaryFormatter();

		// Token: 0x06000078 RID: 120
		void Delete(string path);

		// Token: 0x06000079 RID: 121
		Task<bool> Exists(string path);

		// Token: 0x0600007A RID: 122
		DateTime GetLastWriteTime(string path);

		// Token: 0x0600007B RID: 123
		void MakeDirectories(string path);

		// Token: 0x0600007C RID: 124
		string[] GetDirectories(string path);

		// Token: 0x0600007D RID: 125
		string[] GetFiles(string path, string search);

		// Token: 0x0600007E RID: 126
		Task StartWriteBlock();

		// Token: 0x0600007F RID: 127
		Task EndWriteBlock();

		// Token: 0x06000080 RID: 128
		IFileSystem GetUnderlyingSystem();
	}
}
