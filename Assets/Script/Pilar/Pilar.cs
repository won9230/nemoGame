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
	}

	//�÷��̾� �� ����
	public void ChangeColor(GameObject _gameObject, Color _lineColor, Color _mainColor)
	{
		PlayerManager playerManager = _gameObject.GetComponent<PlayerManager>();
		playerManager.playerBody.color = _mainColor;
		playerManager.spriteRenderer.color = _lineColor;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			ChangeColor(collision.gameObject, pilar_CubeColor.lineColor, pilar_CubeColor.mainColor);
		}
	}
}
