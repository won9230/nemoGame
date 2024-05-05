using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CubeColor
{
	public Color mainColor;
	public Color lineColor;
	[Tooltip("���� ���� ���� ������ MainColor�� ������ ������")]
	public Color uiCubeColor;
	public CubeColorType color = CubeColorType.Normal;
}
// CubeColorType enum�� PlayerManager�� ����
