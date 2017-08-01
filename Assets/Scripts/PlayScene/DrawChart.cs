using UnityEngine;
using UnityEngine.UI;

public class DrawChart : Graphic
{
  const int VerticesCount = 5;

  protected override void OnPopulateMesh(VertexHelper vh)
  {
    float graphHeight = rectTransform.rect.height; // グラフの高さ
    float centerX = 0; // グラフの中心（x）
    float centerY = graphHeight * -0.05f; // グラフの中心（y）
    float length = graphHeight / 2 - centerY; // 一辺の長さ

    vh.Clear();

    var v = UIVertex.simpleVert;
    v.color = color;
    v.position = new Vector3(centerX, centerY);
    vh.AddVert(v);

    for (int i = 0; i < VerticesCount; i++)
    {
      float rad = (90f - (360f / (float)VerticesCount) * i) * Mathf.Deg2Rad;
      float x = centerX + Mathf.Cos(rad) * length;
      float y = centerY + Mathf.Sin(rad) * length;
      v.position = new Vector3(x, y);
      vh.AddVert(v);
      vh.AddTriangle(
        0,
        i + 1,
        i == VerticesCount - 1 ? 1 : i + 2
      );

    }
  }
}
