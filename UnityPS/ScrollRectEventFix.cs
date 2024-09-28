using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000007 RID: 7
public class ScrollRectEventFix : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler, IScrollHandler
{
	// Token: 0x0600001F RID: 31 RVA: 0x00002292 File Offset: 0x00000492
	public void OnBeginDrag(PointerEventData eventData)
	{
		ScrollRect scrollRect = this.scrollRect;
		if (scrollRect == null)
		{
			return;
		}
		scrollRect.OnBeginDrag(eventData);
	}

	// Token: 0x06000020 RID: 32 RVA: 0x000022A5 File Offset: 0x000004A5
	public void OnDrag(PointerEventData eventData)
	{
		ScrollRect scrollRect = this.scrollRect;
		if (scrollRect == null)
		{
			return;
		}
		scrollRect.OnDrag(eventData);
	}

	// Token: 0x06000021 RID: 33 RVA: 0x000022B8 File Offset: 0x000004B8
	public void OnEndDrag(PointerEventData eventData)
	{
		ScrollRect scrollRect = this.scrollRect;
		if (scrollRect == null)
		{
			return;
		}
		scrollRect.OnEndDrag(eventData);
	}

	// Token: 0x06000022 RID: 34 RVA: 0x000022CB File Offset: 0x000004CB
	public void OnScroll(PointerEventData data)
	{
		ScrollRect scrollRect = this.scrollRect;
		if (scrollRect == null)
		{
			return;
		}
		scrollRect.OnScroll(data);
	}

	// Token: 0x0400000F RID: 15
	public ScrollRect scrollRect;
}
