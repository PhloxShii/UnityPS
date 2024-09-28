using System;
using System.Diagnostics;
using UnityEngine;

namespace UnityPS
{
	// Token: 0x02000017 RID: 23
	[Serializable]
	public class Logger
	{
		// Token: 0x060000A6 RID: 166 RVA: 0x000036B7 File Offset: 0x000018B7
		public Logger(bool enabled = true) : this("Logger", null, enabled)
		{
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x000036C6 File Offset: 0x000018C6
		public Logger(string name, Action<object> f = null, bool enabled = true)
		{
			this.Enabled = enabled;
			this.Name = name;
			this._logger = (f ?? new Action<object>(Debug.Log));
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x000036F3 File Offset: 0x000018F3
		// (set) Token: 0x060000A9 RID: 169 RVA: 0x000036FB File Offset: 0x000018FB
		public bool Enabled { get; set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000AA RID: 170 RVA: 0x00003704 File Offset: 0x00001904
		public string Name { get; }

		// Token: 0x060000AB RID: 171 RVA: 0x0000370C File Offset: 0x0000190C
		public void Log(object s, bool logger_prefix = true)
		{
			if (this.Enabled)
			{
				this._logger(logger_prefix ? string.Format("[{0}] {1}", this.Name, s ?? "Null") : s);
			}
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00002282 File Offset: 0x00000482
		[Conditional("UNITY_EDITOR")]
		[Conditional("ENABLE_LOGGING")]
		public static void GlobalLog(object s)
		{
		}

		// Token: 0x04000034 RID: 52
		private const string DEFAULT_NAME = "Logger";

		// Token: 0x04000035 RID: 53
		private const string NULL = "Null";

		// Token: 0x04000036 RID: 54
		private readonly Action<object> _logger;
	}
}
