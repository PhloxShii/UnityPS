using System;
using UnityEngine.EventSystems;

// Token: 0x02000005 RID: 5
public class DebugInput
{
	// Token: 0x04000009 RID: 9
	public bool Focusable = true;

	// Token: 0x0400000A RID: 10
	public string Name;

	// Token: 0x0400000B RID: 11
	public Action OnReset;

	// Token: 0x0400000C RID: 12
	public Action OnCreate;

	// Token: 0x0400000D RID: 13
	public Action OnAction;

	// Token: 0x0400000E RID: 14
	public Func<MoveDirection, bool> OnMove;
}
