using System;
using System.IO;
using JetBrains.Annotations;

namespace UnityPS
{
	// Token: 0x02000013 RID: 19
	public class XorFileStream : Stream
	{
		// Token: 0x0600008D RID: 141 RVA: 0x00002FF5 File Offset: 0x000011F5
		public XorFileStream([NotNull] string path, FileMode mode, FileAccess access, byte privateKey = 40)
		{
			this.m_Key = privateKey;
			this.m_FileStream = new FileStream(path, mode, access);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00003014 File Offset: 0x00001214
		private void PerformXor(ref byte[] array, int offset, int count)
		{
			for (int i = offset; i < offset + count; i++)
			{
				array[i] ^= this.m_Key;
			}
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000303F File Offset: 0x0000123F
		public override void Flush()
		{
			this.m_FileStream.Flush();
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0000304C File Offset: 0x0000124C
		public override int Read(byte[] array, int offset, int count)
		{
			int result = this.m_FileStream.Read(array, offset, count);
			this.PerformXor(ref array, offset, count);
			return result;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00003066 File Offset: 0x00001266
		public override void Write(byte[] array, int offset, int count)
		{
			this.PerformXor(ref array, offset, count);
			this.m_FileStream.Write(array, offset, count);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00003080 File Offset: 0x00001280
		public override int ReadByte()
		{
			return (int)((byte)(this.m_FileStream.ReadByte() ^ (int)this.m_Key));
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00003095 File Offset: 0x00001295
		public override long Seek(long offset, SeekOrigin origin)
		{
			return this.m_FileStream.Seek(offset, origin);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x000030A4 File Offset: 0x000012A4
		public override void SetLength(long value)
		{
			this.m_FileStream.SetLength(value);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x000030B2 File Offset: 0x000012B2
		public override void WriteByte(byte value)
		{
			this.m_FileStream.WriteByte((byte)(value ^ this.m_Key));
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000096 RID: 150 RVA: 0x000030C8 File Offset: 0x000012C8
		public override bool CanRead
		{
			get
			{
				return this.m_FileStream.CanRead;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000097 RID: 151 RVA: 0x000030D5 File Offset: 0x000012D5
		public override bool CanSeek
		{
			get
			{
				return this.m_FileStream.CanSeek;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000098 RID: 152 RVA: 0x000030E2 File Offset: 0x000012E2
		public override bool CanWrite
		{
			get
			{
				return this.m_FileStream.CanWrite;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000099 RID: 153 RVA: 0x000030EF File Offset: 0x000012EF
		public override long Length
		{
			get
			{
				return this.m_FileStream.Length;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600009A RID: 154 RVA: 0x000030FC File Offset: 0x000012FC
		// (set) Token: 0x0600009B RID: 155 RVA: 0x00003109 File Offset: 0x00001309
		public override long Position
		{
			get
			{
				return this.m_FileStream.Position;
			}
			set
			{
				this.m_FileStream.Position = value;
			}
		}

		// Token: 0x0400002C RID: 44
		private FileStream m_FileStream;

		// Token: 0x0400002D RID: 45
		private byte m_Key;
	}
}
