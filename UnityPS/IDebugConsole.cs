using System;
using UnityEngine.EventSystems;

// Token: 0x02000004 RID: 4
public interface IDebugConsole
{
	// Token: 0x06000007 RID: 7
	void Initialise();

	// Token: 0x06000008 RID: 8
	void Open();

	// Token: 0x06000009 RID: 9
	void Close();

	// Token: 0x0600000A RID: 10
	void Submit();

	// Token: 0x0600000B RID: 11
	void Move(AxisEventData moveEvent);

	// Token: 0x0600000C RID: 12
	void AddDebugInput(DebugInput input);

	// Token: 0x0600000D RID: 13
	void AddDebugCommand(string command, Action<string> action);

	// Token: 0x17000001 RID: 1
	// (get) Token: 0x0600000E RID: 14
	bool Active { get; }

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x0600000F RID: 15
	bool CanOpen { get; }

	// Token: 0x17000003 RID: 3
	// (get) Token: 0x06000010 RID: 16
	DebugInput StartHorizontalLayout { get; }

	// Token: 0x17000004 RID: 4
	// (get) Token: 0x06000011 RID: 17
	DebugInput EndHorizontalLayout { get; }
}
