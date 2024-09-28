using System;
using UnityEngine;
using UnityEngine.Events;
using UnityPS;

// Token: 0x02000008 RID: 8
[RequireComponent(typeof(ButtonSelectionState))]
public class ToggleButtonStateDisplayer : MonoBehaviour
{
	// Token: 0x06000024 RID: 36 RVA: 0x000022DE File Offset: 0x000004DE
	public void MakeNormal()
	{
		this.activeSet = this.normalSet;
		this.SelectionStateChanged(ButtonSelectionState.ButtonSelectionStateEnum.Normal);
	}

	// Token: 0x06000025 RID: 37 RVA: 0x000022F3 File Offset: 0x000004F3
	public void MakePressed()
	{
		this.activeSet = this.selectedSet;
		this.SelectionStateChanged(ButtonSelectionState.ButtonSelectionStateEnum.Pressed);
	}

	// Token: 0x06000026 RID: 38 RVA: 0x00002308 File Offset: 0x00000508
	public void MakePressed(bool makeHighlighted)
	{
		this.activeSet = this.selectedSet;
		if (makeHighlighted)
		{
			this.SelectionStateChanged(ButtonSelectionState.ButtonSelectionStateEnum.Highlighted);
			return;
		}
		this.SelectionStateChanged(ButtonSelectionState.ButtonSelectionStateEnum.Selected);
	}

	// Token: 0x06000027 RID: 39 RVA: 0x00002328 File Offset: 0x00000528
	private void Awake()
	{
		this.m_ButtonSelectionState = base.GetComponent<ButtonSelectionState>();
		this.m_ButtonSelectionState.ButtonSelectionStateChanged.AddListener(new UnityAction<ButtonSelectionState.ButtonSelectionStateEnum>(this.SelectionStateChanged));
		this.SelectionStateChanged(this.m_ButtonSelectionState.CurrentSelectionState);
		this.activeSet = this.normalSet;
	}

	// Token: 0x06000028 RID: 40 RVA: 0x0000237C File Offset: 0x0000057C
	private void DisableAllObjects(ToggleButtonStateDisplayer.StateObjectSet set)
	{
		for (int i = 0; i < set.DisabledGameObjects.Length; i++)
		{
			set.DisabledGameObjects[i].SetActive(false);
		}
		for (int j = 0; j < set.HighlightedGameObjects.Length; j++)
		{
			set.HighlightedGameObjects[j].SetActive(false);
		}
		for (int k = 0; k < set.NormalGameObjects.Length; k++)
		{
			set.NormalGameObjects[k].SetActive(false);
		}
		for (int l = 0; l < set.PressedGameObjects.Length; l++)
		{
			set.PressedGameObjects[l].SetActive(false);
		}
		for (int m = 0; m < set.SelectedGameObjects.Length; m++)
		{
			set.SelectedGameObjects[m].SetActive(false);
		}
	}

	// Token: 0x06000029 RID: 41 RVA: 0x00002434 File Offset: 0x00000634
	private void RefreshActiveSet(ButtonSelectionState.ButtonSelectionStateEnum selectionState)
	{
		if (this.activeSet == null)
		{
			this.activeSet = this.normalSet;
		}
		GameObject[] array = null;
		switch (selectionState)
		{
		case ButtonSelectionState.ButtonSelectionStateEnum.Normal:
			array = this.activeSet.NormalGameObjects;
			break;
		case ButtonSelectionState.ButtonSelectionStateEnum.Highlighted:
			array = this.activeSet.HighlightedGameObjects;
			break;
		case ButtonSelectionState.ButtonSelectionStateEnum.Pressed:
			array = this.activeSet.PressedGameObjects;
			break;
		case ButtonSelectionState.ButtonSelectionStateEnum.Selected:
			array = this.activeSet.SelectedGameObjects;
			break;
		case ButtonSelectionState.ButtonSelectionStateEnum.Disabled:
			array = this.activeSet.DisabledGameObjects;
			break;
		}
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(true);
		}
	}

	// Token: 0x0600002A RID: 42 RVA: 0x000024CE File Offset: 0x000006CE
	private void SelectionStateChanged(ButtonSelectionState.ButtonSelectionStateEnum selectionState)
	{
		this.DisableAllObjects(this.normalSet);
		this.DisableAllObjects(this.selectedSet);
		this.RefreshActiveSet(selectionState);
	}

	// Token: 0x04000010 RID: 16
	public ToggleButtonStateDisplayer.StateObjectSet normalSet;

	// Token: 0x04000011 RID: 17
	public ToggleButtonStateDisplayer.StateObjectSet selectedSet;

	// Token: 0x04000012 RID: 18
	private ToggleButtonStateDisplayer.StateObjectSet activeSet;

	// Token: 0x04000013 RID: 19
	private ButtonSelectionState m_ButtonSelectionState;

	// Token: 0x02000027 RID: 39
	[Serializable]
	public class StateObjectSet
	{
		// Token: 0x04000050 RID: 80
		public GameObject[] DisabledGameObjects;

		// Token: 0x04000051 RID: 81
		public GameObject[] HighlightedGameObjects;

		// Token: 0x04000052 RID: 82
		public GameObject[] NormalGameObjects;

		// Token: 0x04000053 RID: 83
		public GameObject[] PressedGameObjects;

		// Token: 0x04000054 RID: 84
		public GameObject[] SelectedGameObjects;
	}
}
