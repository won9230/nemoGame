using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilar : MonoBehaviour
{
	public CubeColor pilar_CubeColor = new CubeColor();

	//플레이어 색 변경
	public void ChangeColor(GameObject _gameObject, Color _lineColor, Color _mainColor)
	{
		PlayerManager playerManager = _gameObject.GetComponent<PlayerManager>();
		playerManager.playerBody.color = _mainColor;
		playerManager.spriteRenderer.color = _lineColor;
	}
}
