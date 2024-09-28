using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityPS
{
	// Token: 0x02000015 RID: 21
	[AddComponentMenu("UI/Gradient Image")]
	public class GradientColorImage : Image
	{
		// Token: 0x0600009F RID: 159 RVA: 0x000031D4 File Offset: 0x000013D4
		protected override void OnPopulateMesh(VertexHelper helper)
		{
			base.OnPopulateMesh(helper);
			List<UIVertex> list = new List<UIVertex>();
			helper.GetUIVertexStream(list);
			float num = float.MaxValue;
			float num2 = float.MaxValue;
			float num3 = float.MinValue;
			float num4 = float.MinValue;
			for (int i = 0; i < list.Count; i++)
			{
				UIVertex uivertex = list[i];
				if (uivertex.position.x < num)
				{
					num = uivertex.position.x;
				}
				else if (uivertex.position.x > num3)
				{
					num3 = uivertex.position.x;
				}
				if (uivertex.position.y < num2)
				{
					num2 = uivertex.position.y;
				}
				else if (uivertex.position.y > num4)
				{
					num4 = uivertex.position.y;
				}
			}
			Vector3 v;
			v.x = num;
			v.y = num4;
			v.z = 0f;
			Vector3 v2;
			v2.x = num3;
			v2.y = num4;
			v2.z = 0f;
			Vector3 v3;
			v3.x = num;
			v3.y = num2;
			v3.z = 0f;
			Vector3 v4;
			v4.x = num3;
			v4.y = num2;
			v4.z = 0f;
			for (int j = 0; j < list.Count; j++)
			{
				UIVertex uivertex2 = list[j];
				Vector3 position = uivertex2.position;
				Vector3 vector = GradientColorImage.BaryCentric(v4, v, v2, position);
				if (vector.x >= 0f && vector.y >= 0f && vector.z >= 0f)
				{
					uivertex2.color = GradientColorImage.LerpColorTriangle32(this.BottomRightColor, this.TopLeftColor, this.TopRightColor, vector);
				}
				else
				{
					Vector3 weights = GradientColorImage.BaryCentric(v4, v, v3, position);
					uivertex2.color = GradientColorImage.LerpColorTriangle32(this.BottomRightColor, this.TopLeftColor, this.BottomLeftColor, weights);
				}
				list[j] = uivertex2;
			}
			helper.Clear();
			helper.AddUIVertexTriangleStream(list);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00003408 File Offset: 0x00001608
		public static Vector3 BaryCentric(Vector3 v1, Vector3 v2, Vector3 v3, Vector3 p)
		{
			Vector3 vector;
			vector.x = ((v2.y - v3.y) * (p.x - v3.x) + (v3.x - v2.x) * (p.y - v3.y)) / ((v2.y - v3.y) * (v1.x - v3.x) + (v3.x - v2.x) * (v1.y - v3.y));
			vector.y = ((v3.y - v1.y) * (p.x - v3.x) + (v1.x - v3.x) * (p.y - v3.y)) / ((v2.y - v3.y) * (v1.x - v3.x) + (v3.x - v2.x) * (v1.y - v3.y));
			vector.z = 1f - vector.x - vector.y;
			return vector;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000351C File Offset: 0x0000171C
		public static Color32 LerpColorTriangle32(Color32 c1, Color32 c2, Color32 c3, Vector3 weights)
		{
			Color32 result = Color.black;
			float num = (weights.x + weights.y + weights.z) * 255f;
			result.a = (byte)(((float)c1.a * weights.x + (float)c2.a * weights.y + (float)c3.a * weights.z) / num * 255f);
			result.r = (byte)(((float)c1.r * weights.x + (float)c2.r * weights.y + (float)c3.r * weights.z) / num * 255f);
			result.g = (byte)(((float)c1.g * weights.x + (float)c2.g * weights.y + (float)c3.g * weights.z) / num * 255f);
			result.b = (byte)(((float)c1.b * weights.x + (float)c2.b * weights.y + (float)c3.b * weights.z) / num * 255f);
			return result;
		}

		// Token: 0x0400002E RID: 46
		public Color TopLeftColor;

		// Token: 0x0400002F RID: 47
		public Color BottomLeftColor;

		// Token: 0x04000030 RID: 48
		public Color BottomRightColor;

		// Token: 0x04000031 RID: 49
		public Color TopRightColor;
	}
}
