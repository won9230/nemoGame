using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Pilar : Pilar
{
	public Color pilar_color = Color.red;

	private void Start()
	{
		pilar_CubeColor.color = CubeColorType.Red;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			ChangeColor(collision.gameObject, pilar_CubeColor.lineColor, pilar_CubeColor.mainColor);
		}
	}
}
