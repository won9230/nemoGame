using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilar : MonoBehaviour
{
	public CubeColor pilar_CubeColor = new CubeColor();

	private void Start()
	{
		if(pilar_CubeColor.color == CubeColorType.Normal)
		{
			Debug.Log($"{gameObject.name}의 pilat_CubeColor가 Normal입니다 확인해 주세요");
		}
		if(pilar_CubeColor.uiCubeColor == new Color(0, 0, 0, 0))
		{
			pilar_CubeColor.uiCubeColor = pilar_CubeColor.mainColor;
		}
	}

	//플레이어 색 변경
	//public void ChangeColor(GameObject _gameObject, Color _lineColor, Color _mainColor)
	//{
	//	PlayerManager playerManager = _gameObject.GetComponent<PlayerManager>();
	//	playerManager.playerBody.color = _mainColor;
	//	playerManager.spriteRenderer.color = _lineColor;
	//}



	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			//ChangeColor(collision.gameObject, pilar_CubeColor.lineColor, pilar_CubeColor.mainColor);
			PlayerManager playerManager = collision.GetComponent<PlayerManager>();
			playerManager.InQueueCube(pilar_CubeColor);
			UIManager.instance.MakeCubeUI(playerManager.cubePrefab, pilar_CubeColor);
		}
	}
}
