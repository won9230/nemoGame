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
			Debug.Log($"{gameObject.name}�� pilat_CubeColor�� Normal�Դϴ� Ȯ���� �ּ���");
		}
		if(pilar_CubeColor.uiCubeColor == new Color(0, 0, 0, 0))
		{
			pilar_CubeColor.uiCubeColor = pilar_CubeColor.mainColor;
		}
	}

	//�÷��̾� �� ����
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
