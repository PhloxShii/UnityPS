using System;
using UnityEngine.EventSystems;

// Token: 0x02000006 RID: 6
public class MockDebugConsole : IDebugConsole
{
	// Token: 0x06000013 RID: 19 RVA: 0x00002282 File Offset: 0x00000482
	public void Initialise()
	{
	}

	// Token: 0x06000014 RID: 20 RVA: 0x00002282 File Offset: 0x00000482
	public void Open()
	{
	}

	// Token: 0x06000015 RID: 21 RVA: 0x00002282 File Offset: 0x00000482
	public void Close()
	{
	}

	// Token: 0x06000016 RID: 22 RVA: 0x00002282 File Offset: 0x00000482
	public void Submit()
	{
	}

	// Token: 0x06000017 RID: 23 RVA: 0x00002282 File Offset: 0x00000482
	public void Move(AxisEventData moveEvent)
	{
	}

	// Token: 0x06000018 RID: 24 RVA: 0x00002282 File Offset: 0x00000482
	public void AddDebugInput(DebugInput input)
	{
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00002282 File Offset: 0x00000482
	public void AddDebugCommand(string command, Action<string> action)
	{
	}

	// Token: 0x17000005 RID: 5
	// (get) Token: 0x0600001A RID: 26 RVA: 0x00002284 File Offset: 0x00000484
	public bool Active
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000006 RID: 6
	// (get) Token: 0x0600001B RID: 27 RVA: 0x00002284 File Offset: 0x00000484
	public bool CanOpen
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000007 RID: 7
	// (get) Token: 0x0600001C RID: 28 RVA: 0x00002287 File Offset: 0x00000487
	public DebugInput StartHorizontalLayout
	{
		get
		{
			return null;
		}
	}

	// Token: 0x17000008 RID: 8
	// (get) Token: 0x0600001D RID: 29 RVA: 0x00002287 File Offset: 0x00000487
	public DebugInput EndHorizontalLayout
	{
		get
		{
			return null;
		}
	}
}
