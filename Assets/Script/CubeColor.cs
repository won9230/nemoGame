using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CubeColor
{
	public Color mainColor;
	public Color lineColor;
	[Tooltip("따로 설정 하지 않으면 MainColor의 색으로 설정됨")]
	public Color uiCubeColor;
	public CubeColorType color = CubeColorType.Normal;
}
// CubeColorType enum은 PlayerManager에 있음
