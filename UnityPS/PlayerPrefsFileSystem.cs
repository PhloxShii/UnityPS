using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace UnityPS
{
	// Token: 0x02000012 RID: 18
	public class PlayerPrefsFileSystem : CustomStreamFileSystem
	{
		public override string PersistentDataPath => Application.persistentDataPath;

		protected override void Create(string path)
		{
			// Implementation
		}

		protected override Stream GetStreamForPath(string path, FileAccess access)
		{
			// Implementation
			return null; // Replace with actual implementation
		}

		public override void Delete(string path)
		{
			// Implementation
		}

		protected override bool ExistsInternal(string path)
		{
			// Implementation
			return false; // Replace with actual implementation
		}

		public override DateTime GetLastWriteTime(string path)
		{
			// Implementation
			return DateTime.MinValue; // Replace with actual implementation
		}

		public override void MakeDirectories(string path)
		{
			// Implementation
		}

		public override string[] GetDirectories(string path)
		{
			// Implementation
			return new string[0]; // Replace with actual implementation
		}

		public override string[] GetFiles(string path, string search)
		{
			// Implementation
			return new string[0]; // Replace with actual implementation
		}
	}
}
