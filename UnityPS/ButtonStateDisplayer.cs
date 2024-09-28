using System;
using UnityEngine;
using UnityEngine.Events;
using UnityPS;

// Token: 0x02000002 RID: 2
[RequireComponent(typeof(ButtonSelectionState))]
public class ButtonStateDisplayer : MonoBehaviour
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	private void Start()
	{
		this.m_ButtonSelectionState = base.GetComponent<ButtonSelectionState>();
		this.m_ButtonSelectionState.ButtonSelectionStateChanged.AddListener(new UnityAction<ButtonSelectionState.ButtonSelectionStateEnum>(this.SelectionStateChanged));
		this.SelectionStateChanged(this.m_ButtonSelectionState.CurrentSelectionState);
	}

	// Token: 0x06000002 RID: 2 RVA: 0x0000208C File Offset: 0x0000028C
	private void SelectionStateChanged(ButtonSelectionState.ButtonSelectionStateEnum selectionState)
	{
		for (int i = 0; i < this.DisabledGameObjects.Length; i++)
		{
			this.DisabledGameObjects[i].SetActive(false);
		}
		for (int j = 0; j < this.HighlightedGameObjects.Length; j++)
		{
			this.HighlightedGameObjects[j].SetActive(false);
		}
		for (int k = 0; k < this.NormalGameObjects.Length; k++)
		{
			this.NormalGameObjects[k].SetActive(false);
		}
		for (int l = 0; l < this.PressedGameObjects.Length; l++)
		{
			this.PressedGameObjects[l].SetActive(false);
		}
		for (int m = 0; m < this.SelectedGameObjects.Length; m++)
		{
			this.SelectedGameObjects[m].SetActive(false);
		}
		GameObject[] array = null;
		switch (selectionState)
		{
		case ButtonSelectionState.ButtonSelectionStateEnum.Normal:
			array = this.NormalGameObjects;
			break;
		case ButtonSelectionState.ButtonSelectionStateEnum.Highlighted:
			array = this.HighlightedGameObjects;
			break;
		case ButtonSelectionState.ButtonSelectionStateEnum.Pressed:
			array = this.PressedGameObjects;
			break;
		case ButtonSelectionState.ButtonSelectionStateEnum.Selected:
			array = this.SelectedGameObjects;
			break;
		case ButtonSelectionState.ButtonSelectionStateEnum.Disabled:
			array = this.DisabledGameObjects;
			break;
		}
		for (int n = 0; n < array.Length; n++)
		{
			array[n].SetActive(true);
		}
	}

	// Token: 0x04000001 RID: 1
	public GameObject[] DisabledGameObjects;

	// Token: 0x04000002 RID: 2
	public GameObject[] HighlightedGameObjects;

	// Token: 0x04000003 RID: 3
	public GameObject[] NormalGameObjects;

	// Token: 0x04000004 RID: 4
	public GameObject[] PressedGameObjects;

	// Token: 0x04000005 RID: 5
	public GameObject[] SelectedGameObjects;

	// Token: 0x04000006 RID: 6
	private ButtonSelectionState m_ButtonSelectionState;
}
