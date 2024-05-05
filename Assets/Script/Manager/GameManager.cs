using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject canvas;

	public static GameManager instance;

	private void Awake()
	{
		#region 싱글톤
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
				Debug.Log($"싱그톤 패턴으로 인하여{gameObject.name}가 삭제 되었습니다.");
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
