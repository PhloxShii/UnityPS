using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000003 RID: 3
public class ShowButtonPressed : MonoBehaviour
{
	// Token: 0x06000004 RID: 4 RVA: 0x000021B8 File Offset: 0x000003B8
	private void Start()
	{
		this.m_ButtonPressed = base.GetComponent<Text>();
		for (int i = 330; i <= 349; i++)
		{
			this.m_ButtonCodes.Add((KeyCode)i);
		}
	}

	// Token: 0x06000005 RID: 5 RVA: 0x000021F4 File Offset: 0x000003F4
	private void Update()
	{
		this.m_ButtonPressed.text = "No Button Pressed";
		for (int i = 0; i < this.m_ButtonCodes.Count; i++)
		{
			if (Input.GetKey(this.m_ButtonCodes[i]))
			{
				this.m_ButtonPressed.text = this.m_ButtonCodes[i].ToString();
				return;
			}
		}
	}

	// Token: 0x04000007 RID: 7
	private Text m_ButtonPressed;

	// Token: 0x04000008 RID: 8
	private List<KeyCode> m_ButtonCodes = new List<KeyCode>();
}
