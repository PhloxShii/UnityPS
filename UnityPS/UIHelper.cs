using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityPS
{
	// Token: 0x0200001D RID: 29
	public class UIHelper
	{
		// Token: 0x060000B6 RID: 182 RVA: 0x00003814 File Offset: 0x00001A14
		public static void ScrollItemIntoView(ScrollRect scrollRect, RectTransform item)
		{
			RectTransform content = scrollRect.content;
			Vector2 size = scrollRect.viewport.rect.size;
			Vector2 b = content.sizeDelta - size;
			Vector2 vector = default(Vector2);
			vector.x = Mathf.Abs(item.position.x - content.position.x);
			vector.y = Mathf.Abs(item.position.y - content.position.y);
			vector.x = Mathf.Max(0f, vector.x - size.x * 0.5f);
			vector.y = Mathf.Max(0f, vector.y - size.y * 0.5f);
			Vector2 vector2 = Vector2.one - vector / b;
			if (scrollRect.horizontal)
			{
				scrollRect.horizontalNormalizedPosition = Mathf.Clamp(vector2.x, 0f, 1f);
			}
			if (scrollRect.vertical)
			{
				scrollRect.verticalNormalizedPosition = Mathf.Clamp(vector2.y, 0f, 1f);
			}
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000393C File Offset: 0x00001B3C
		public static void LerpItemIntoView(ScrollRect scrollRect, RectTransform item, Vector2 offset = default(Vector2), float lerpTime = 0.25f)
		{
			RectTransform content = scrollRect.content;
			Vector2 size = scrollRect.viewport.rect.size;
			Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(null, item.position);
			Vector2 vector;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(content, screenPoint, null, out vector);
			Vector2 a = new Vector2
			{
				x = Mathf.Abs(vector.x),
				y = Mathf.Abs(vector.y) - item.rect.height / 2f
			} + offset;
			Vector2 sizeDelta = content.sizeDelta;
			sizeDelta.y -= item.rect.height;
			Vector2 vector2 = Vector2.one - a / sizeDelta;
			if (scrollRect.horizontal)
			{
				scrollRect.horizontalNormalizedPosition = Mathf.Lerp(scrollRect.horizontalNormalizedPosition, Mathf.Clamp(vector2.x, 0f, 1f), Time.deltaTime / lerpTime);
			}
			if (scrollRect.vertical)
			{
				scrollRect.verticalNormalizedPosition = Mathf.Lerp(scrollRect.verticalNormalizedPosition, Mathf.Clamp(vector2.y, 0f, 1f), Time.deltaTime / lerpTime);
			}
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00003A68 File Offset: 0x00001C68
		public static void ScrollItemIntoViewNew(ScrollRect scrollRect, RectTransform item, Vector2 oldNormalizedPosition, Vector2 offset = default(Vector2), float topClamp = 0f, Vector2 scrollDeadzoneSize = default(Vector2))
		{
			RectTransform content = scrollRect.content;
			Vector2 size = scrollRect.viewport.rect.size;
			Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(null, item.position);
			Vector2 vector;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(content, screenPoint, null, out vector);
			Vector2 vector2 = default(Vector2);
			vector2.x = Mathf.Abs(vector.x);
			vector2.y = Mathf.Abs(vector.y);
			vector2 += offset;
			if (vector2.y <= topClamp)
			{
				vector2.y = 0f;
			}
			vector2 -= size / 2f;
			Vector2 vector3 = (content.sizeDelta - size) * (Vector2.one - oldNormalizedPosition);
			if (vector2.y > vector3.y + scrollDeadzoneSize.y)
			{
				vector2.y -= scrollDeadzoneSize.y;
			}
			else if (vector2.y < vector3.y - scrollDeadzoneSize.y)
			{
				vector2.y += scrollDeadzoneSize.y;
			}
			else
			{
				vector2 = vector3;
			}
			Vector2 vector4 = Vector2.one - vector2 / (content.sizeDelta - size);
			if (scrollRect.horizontal)
			{
				scrollRect.horizontalNormalizedPosition = Mathf.Clamp(vector4.x, 0f, 1f);
			}
			if (scrollRect.vertical)
			{
				scrollRect.verticalNormalizedPosition = Mathf.Clamp(vector4.y, 0f, 1f);
			}
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00003BEC File Offset: 0x00001DEC
		public static void LerpItemIntoViewNew(ScrollRect scrollRect, RectTransform item, Vector2 oldNormalizedPosition, float startTime, Vector2 offset = default(Vector2), float topClamp = 0f, float lerpTime = 0.5f, Vector2 scrollDeadzoneSize = default(Vector2))
		{
			RectTransform content = scrollRect.content;
			Vector2 size = scrollRect.viewport.rect.size;
			Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(null, item.position);
			Vector2 vector;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(content, screenPoint, null, out vector);
			Vector2 vector2 = default(Vector2);
			vector2.x = Mathf.Abs(vector.x);
			vector2.y = Mathf.Abs(vector.y);
			vector2 += offset;
			if (vector2.y <= topClamp)
			{
				vector2.y = 0f;
			}
			vector2 -= size / 2f;
			Vector2 vector3 = (content.sizeDelta - size) * (Vector2.one - oldNormalizedPosition);
			if (vector2.y > vector3.y + scrollDeadzoneSize.y)
			{
				vector2.y -= scrollDeadzoneSize.y;
			}
			else if (vector2.y < vector3.y - scrollDeadzoneSize.y)
			{
				vector2.y += scrollDeadzoneSize.y;
			}
			else
			{
				vector2 = vector3;
			}
			Vector2 vector4 = Vector2.one - vector2 / (content.sizeDelta - size);
			float num = Time.time - startTime;
			float num2 = Mathf.Min(1f, num / lerpTime) - 1f;
			num2 = -(num2 * num2 * num2 * num2) + 1f;
			if (scrollRect.horizontal)
			{
				scrollRect.horizontalNormalizedPosition = Mathf.Lerp(oldNormalizedPosition.x, Mathf.Clamp(vector4.x, 0f, 1f), num2);
			}
			if (scrollRect.vertical)
			{
				scrollRect.verticalNormalizedPosition = Mathf.Lerp(oldNormalizedPosition.y, Mathf.Clamp(vector4.y, 0f, 1f), num2);
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00003DC0 File Offset: 0x00001FC0
		public static void SetExplicitNavigation(Selectable selectable, Selectable up, Selectable down, Selectable left, Selectable right)
		{
			Navigation navigation = selectable.navigation;
			navigation.mode = Navigation.Mode.Explicit;
			navigation.selectOnUp = up;
			navigation.selectOnDown = down;
			navigation.selectOnLeft = left;
			navigation.selectOnRight = right;
			selectable.navigation = navigation;
		}
	}
}
