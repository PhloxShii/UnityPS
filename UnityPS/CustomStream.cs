using System;
using System.IO;
using System.Text;

namespace UnityPS
{
	// Token: 0x0200000F RID: 15
	public class CustomStream : Stream
	{
		// Token: 0x06000052 RID: 82 RVA: 0x00002C61 File Offset: 0x00000E61
		public override void Flush()
		{
			this.m_Memory.Flush();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002C6E File Offset: 0x00000E6E
		public override int Read(byte[] buffer, int offset, int count)
		{
			return this.m_Memory.Read(buffer, offset, count);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002C7E File Offset: 0x00000E7E
		public override long Seek(long offset, SeekOrigin origin)
		{
			if (origin == SeekOrigin.Begin)
			{
				return this.m_Memory.Seek(offset + this.m_SeekOffset, origin);
			}
			return this.m_Memory.Seek(offset, origin);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002CA9 File Offset: 0x00000EA9
		public override void SetLength(long value)
		{
			this.m_Memory.SetLength(value + this.m_SeekOffset);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002CBE File Offset: 0x00000EBE
		public override void Write(byte[] buffer, int offset, int count)
		{
			this.m_Memory.Write(buffer, offset, count);
			this.m_Changed = true;
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00002CD5 File Offset: 0x00000ED5
		public override bool CanRead
		{
			get
			{
				return this.m_Memory.CanRead;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00002CE2 File Offset: 0x00000EE2
		public override bool CanSeek
		{
			get
			{
				return this.m_Memory.CanSeek;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00002CEF File Offset: 0x00000EEF
		public override bool CanWrite
		{
			get
			{
				return this.m_Memory.CanWrite;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00002CFC File Offset: 0x00000EFC
		public override long Length
		{
			get
			{
				return this.m_Memory.Length;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00002D09 File Offset: 0x00000F09
		// (set) Token: 0x0600005C RID: 92 RVA: 0x00002D16 File Offset: 0x00000F16
		public override long Position
		{
			get
			{
				return this.m_Memory.Position;
			}
			set
			{
				this.m_Memory.Position = value;
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00002D24 File Offset: 0x00000F24
		public override string ToString()
		{
			return Encoding.UTF8.GetString(this.m_Memory.GetBuffer(), 0, (int)this.m_Memory.Length);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00002D48 File Offset: 0x00000F48
		public override int ReadByte()
		{
			return this.m_Memory.ReadByte();
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00002D55 File Offset: 0x00000F55
		public override void WriteByte(byte value)
		{
			this.m_Memory.WriteByte(value);
			this.m_Changed = true;
		}

		// Token: 0x04000026 RID: 38
		protected readonly MemoryStream m_Memory = new MemoryStream();

		// Token: 0x04000027 RID: 39
		protected bool m_Changed;

		// Token: 0x04000028 RID: 40
		protected bool m_Writeable;

		// Token: 0x04000029 RID: 41
		protected bool m_Readable;

		// Token: 0x0400002A RID: 42
		private long m_SeekOffset;
	}
}
