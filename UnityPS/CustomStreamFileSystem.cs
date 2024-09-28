using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace UnityPS
{
	// Token: 0x02000010 RID: 16
	public abstract class CustomStreamFileSystem : IFileSystem
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000061 RID: 97
		public abstract string PersistentDataPath { get; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000062 RID: 98 RVA: 0x00002D7D File Offset: 0x00000F7D
		// (set) Token: 0x06000063 RID: 99 RVA: 0x00002D85 File Offset: 0x00000F85
		public int ActiveBlockCount { get; private set; }

		// Token: 0x06000064 RID: 100
		protected abstract void Create(string path);

		// Token: 0x06000065 RID: 101
		protected abstract Stream GetStreamForPath(string path, FileAccess access);

		// Token: 0x06000066 RID: 102
		public abstract void Delete(string path);

		// Token: 0x06000067 RID: 103
		protected abstract bool ExistsInternal(string path);

		// Token: 0x06000068 RID: 104
		public abstract DateTime GetLastWriteTime(string path);

		// Token: 0x06000069 RID: 105
		public abstract void MakeDirectories(string path);

		// Token: 0x0600006A RID: 106
		public abstract string[] GetDirectories(string path);

		// Token: 0x0600006B RID: 107
		public abstract string[] GetFiles(string path, string search);

		// Token: 0x0600006C RID: 108 RVA: 0x00002D90 File Offset: 0x00000F90
		public Task<Stream> Open(string path, FileAccess access, FileMode mode)
		{
			return Task.Factory.StartNew(() =>
			{
				Stream str = null;
				bool exists = ExistsInternal(path);

				if (exists)
				{
					switch (mode)
					{
						case FileMode.CreateNew:
							throw new IOException("Attempting to Open " + path + " as FileMode.CreateNew but it already existed.");
						case FileMode.Create:
						case FileMode.Truncate:
							Create(path);
							str = GetStreamForPath(path, access);
							break;
						case FileMode.Open:
						case FileMode.OpenOrCreate:
							str = GetStreamForPath(path, access);
							str.Seek(0L, SeekOrigin.Begin);
							break;
						case FileMode.Append:
							str = GetStreamForPath(path, access);
							str.Seek(0L, SeekOrigin.End);
							break;
					}
				}
				else
				{
					switch (mode)
					{
						case FileMode.CreateNew:
						case FileMode.Create:
						case FileMode.OpenOrCreate:
						case FileMode.Append:
							Create(path);
							str = GetStreamForPath(path, access);
							break;
						case FileMode.Open:
						case FileMode.Truncate:
							throw new FileNotFoundException(string.Format("Attempting to Open {0} as {1} but it doesn't exist.'", path, mode));
					}
				}
				return str;
			});
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00002DF0 File Offset: 0x00000FF0
		public Task<bool> Exists(string path)
		{
			return Task.Factory.StartNew(() => ExistsInternal(path));
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00002E24 File Offset: 0x00001024
		public void Touch(string path)
		{
			using (Open(path, FileAccess.Read, FileMode.OpenOrCreate).Result)
			{
				// Do nothing, just open and close the file
			}
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00002E2B File Offset: 0x0000102B
		public IFormatter BuildBinaryFormatter()
		{
			return new BinaryFormatter();
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00002E30 File Offset: 0x00001030
		public IFileSystem GetUnderlyingSystem()
		{
			return this;
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00002E78 File Offset: 0x00001078
		public virtual Task StartWriteBlock()
		{
			return Task.Factory.StartNew(() => ActiveBlockCount++);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00002E9C File Offset: 0x0000109C
		public virtual Task EndWriteBlock()
		{
			return Task.Factory.StartNew(() => ActiveBlockCount--);
		}
	}
}
