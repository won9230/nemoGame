using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject canvas;

	public static GameManager instance;

	private void Awake()
	{
		#region �̱���
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			if(instance == null)
			{
				Destroy(gameObject);
				Debug.Log($"�̱��� �������� ���Ͽ�{gameObject.name}�� ���� �Ǿ����ϴ�.");
			}
		}
		#endregion

		DontDestroyOnLoad(gameObject);
	}
	private void Start()
	{
		Application.targetFrameRate = 30;
	}


}
