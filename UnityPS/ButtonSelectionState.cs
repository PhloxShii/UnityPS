using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UnityPS
{
	// Token: 0x0200000A RID: 10
	public class ButtonSelectionState : Button
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600002F RID: 47 RVA: 0x0000250D File Offset: 0x0000070D
		// (set) Token: 0x06000030 RID: 48 RVA: 0x00002515 File Offset: 0x00000715
		public ButtonSelectionState.ButtonSelectionStateEnum CurrentSelectionState { get; set; }

		// Token: 0x06000031 RID: 49 RVA: 0x0000251E File Offset: 0x0000071E
		private ButtonSelectionState.ButtonSelectionStateEnum ConvertSelectionState(Selectable.SelectionState selectionState)
		{
			switch (selectionState)
			{
			case Selectable.SelectionState.Normal:
				return ButtonSelectionState.ButtonSelectionStateEnum.Normal;
			case Selectable.SelectionState.Highlighted:
				return ButtonSelectionState.ButtonSelectionStateEnum.Highlighted;
			case Selectable.SelectionState.Pressed:
				return ButtonSelectionState.ButtonSelectionStateEnum.Pressed;
			case Selectable.SelectionState.Selected:
				return ButtonSelectionState.ButtonSelectionStateEnum.Selected;
			case Selectable.SelectionState.Disabled:
				return ButtonSelectionState.ButtonSelectionStateEnum.Disabled;
			default:
				return ButtonSelectionState.ButtonSelectionStateEnum.Normal;
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002547 File Offset: 0x00000747
		protected override void Start()
		{
			base.Start();
			if (this.ButtonSelectionStateChanged == null)
			{
				this.ButtonSelectionStateChanged = new ButtonSelectionState.SelectionStateEvent();
			}
			this.CurrentSelectionState = this.ConvertSelectionState(base.currentSelectionState);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002574 File Offset: 0x00000774
		private void Update()
		{
			ButtonSelectionState.ButtonSelectionStateEnum buttonSelectionStateEnum = this.ConvertSelectionState(base.currentSelectionState);
			if (this.CurrentSelectionState != buttonSelectionStateEnum)
			{
				this.CurrentSelectionState = buttonSelectionStateEnum;
				this.ButtonSelectionStateChanged.Invoke(this.CurrentSelectionState);
			}
		}

		// Token: 0x04000018 RID: 24
		public ButtonSelectionState.SelectionStateEvent ButtonSelectionStateChanged = new ButtonSelectionState.SelectionStateEvent();

		// Token: 0x02000028 RID: 40
		public enum ButtonSelectionStateEnum
		{
			// Token: 0x04000056 RID: 86
			Normal,
			// Token: 0x04000057 RID: 87
			Highlighted,
			// Token: 0x04000058 RID: 88
			Pressed,
			// Token: 0x04000059 RID: 89
			Selected,
			// Token: 0x0400005A RID: 90
			Disabled
		}

		// Token: 0x02000029 RID: 41
		public class SelectionStateEvent : UnityEvent<ButtonSelectionState.ButtonSelectionStateEnum>
		{
		}
	}
}
